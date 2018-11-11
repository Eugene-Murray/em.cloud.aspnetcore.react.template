using System;
using System.Collections.Generic;
using System.Text;
using MusicStore.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Services
{
    public class MusicTicketService : IMusicTicketService
    {
        private IList<MusicTicket> _musicTickets;

        public MusicTicketService()
        {
            _musicTickets = new List<MusicTicket>();
            _musicTickets.Add(new MusicTicket(1, "38529866740_2f1f79bf29_z", "Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur.", "Small", 10.9, "GBP", "£", true));
            _musicTickets.Add(new MusicTicket(2, "40588551610_05d596e62a_z", "Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur.", "Small", 10.9, "GBP", "£", true));
            _musicTickets.Add(new MusicTicket(3, "42083612055_9401bf139d_z", "Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur.", "Small", 10.9, "GBP", "£", true));
            _musicTickets.Add(new MusicTicket(4, "32564696410_cb8c7d2bcf_z", "Lorem ipsum", "Lorem ipsum dolor sit amet, consectetur.", "Small", 10.9, "GBP", "£", true));
        }

        private MusicTicket GetById(string id)
        {
            var musicTicket = _musicTickets.SingleOrDefault(o => Equals(o.Id, id));
            if (musicTicket == null)
            {
                throw new ArgumentException(string.Format("Music Ticket ID '{0}' is invalid", id));
            }
            return musicTicket;
        }

        public Task<MusicTicket> GetMusicTicketByIdAsync(string id)
        {
            return Task.FromResult(_musicTickets.Single(o => Equals(o.Id, id)));
        }

        public Task<IEnumerable<MusicTicket>> GetMusicTicketsAsync()
        {
            return Task.FromResult(_musicTickets.AsEnumerable());
        }
    }

    public interface IMusicTicketService
    {
        Task<MusicTicket> GetMusicTicketByIdAsync(string id);
        Task<IEnumerable<MusicTicket>> GetMusicTicketsAsync();
    }
}
