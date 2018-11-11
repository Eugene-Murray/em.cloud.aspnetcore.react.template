using GraphQL.Types;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MusicStore.Services;

namespace MusicStore.Schema
{
    public class MusicStoreQuery : ObjectGraphType<object>
    {
        public MusicStoreQuery(IOrderService orders, IMusicTicketService musicTicketService)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => orders.GetOrdersAsync()
            );
            Field<ListGraphType<MusicTicketType>>(
                "musicTickets",
                resolve: context => musicTicketService.GetMusicTicketsAsync()
            );
        }
    }
}
