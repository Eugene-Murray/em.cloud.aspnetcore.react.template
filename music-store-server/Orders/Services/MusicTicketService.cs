using System;
using System.Collections.Generic;
using System.Text;
using Orders.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class MusicTicketService : IMusicTicketService
    {
        private IList<MusicTicket> _musicTickets;
        private readonly IMusicTicketEventService _events;

        public MusicTicketService(IMusicTicketEventService events)
        {
            _musicTickets = new List<MusicTicket>();
            _musicTickets.Add(new MusicTicket("1000", "250 Conference brochures", DateTime.Now, 1, "FAEBD971-CBA5-4CED-8AD5-CC0B8D4B7827"));
            _musicTickets.Add(new MusicTicket("2000", "250 T-shirts", DateTime.Now.AddHours(1), 2, "F43A4F9D-7AE9-4A19-93D9-2018387D5378"));
            _musicTickets.Add(new MusicTicket("3000", "500 Stickers", DateTime.Now.AddHours(2), 3, "2D542571-EF99-4786-AEB5-C997D82E57C7"));
            _musicTickets.Add(new MusicTicket("4000", "10 Posters", DateTime.Now.AddHours(2), 4, "2D542572-EF99-4786-AEB5-C997D82E57C7"));
            this._events = events;
        }

        private MusicTicket GetById(string id)
        {
            var musicTicket = _musicTickets.SingleOrDefault(o => Equals(o.Id, id));
            if (musicTicket == null)
            {
                throw new ArgumentException(string.Format("Order ID '{0}' is invalid", id));
            }
            return musicTicket;
        }


        public Task<Order> CreateAsync(MusicTicket musicTicket)
        {
            _musicTicket.Add(order);
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.CREATED,DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_musicTicket.Single(o => Equals(o.Id, id)));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_musicTicket.AsEnumerable());
        }

        public Task<Order> StartAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Start();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatuses.PROCESSING, DateTime.Now);
            _events.AddEvent(orderEvent);
            return Task.FromResult(order);
        }
    }

    public interface IMusicTicketService
    {
        Task<MusicTicket> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<MusicTicket> CreateAsync(MusicTicket order);
        Task<MusicTicket> StartAsync(string orderId);
    }
}
