using Orders.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace Orders.Services
{
    public class MusicTicketEventService : IMusicTicketEventService
    {
        private readonly ISubject<MusicTicketEvent> _eventStream = new ReplaySubject<MusicTicketEvent>(1);

        public MusicTicketEventService()
        {
            AllEvents = new ConcurrentStack<MusicTicketEvent>();
        }

        public ConcurrentStack<MusicTicketEvent> AllEvents { get; }

        public void AddError(Exception exception)
        {
            _eventStream.OnError(exception);
        }

        public MusicTicketEvent AddEvent(MusicTicketEvent musicTicketEvent)
        {
            AllEvents.Push(musicTicketEvent);
            _eventStream.OnNext(musicTicketEvent);
            return musicTicketEvent;
        }

        public IObservable<MusicTicketEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }

    public interface IMusicTicketEventService
    {
        ConcurrentStack<MusicTicketEvent> AllEvents { get; }
        void AddError(Exception exception);
        MusicTicketEvent AddEvent(MusicTicketEvent orderEvent);
        IObservable<MusicTicketEvent> EventStream();
    }
}
