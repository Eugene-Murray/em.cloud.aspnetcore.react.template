using GraphQL.Types;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MusicStore.GraphQL.Services;

namespace MusicStore.GraphQL.MusicSchema
{
    public class MusicTicketsQuery : ObjectGraphType<object>
    {
        public MusicTicketsQuery(IMusicTicketService musicTicketService)
        {
            Name = "Query";
            Field<ListGraphType<MusicTicketType>>(
                "musicTickets",
                resolve: context => musicTicketService.GetMusicTicketsAsync()
            );
        }
    }
}
