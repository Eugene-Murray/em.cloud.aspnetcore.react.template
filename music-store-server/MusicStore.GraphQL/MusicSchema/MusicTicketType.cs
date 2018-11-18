using GraphQL.Types;
using MusicStore.GraphQL.Models;
using MusicStore.GraphQL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.MusicSchema
{
    public class MusicTicketType : ObjectGraphType<MusicTicket>
    {
        public MusicTicketType(IMusicTicketService musicTicket)
        {
            Field(o => o.Id);
            Field(o => o.sku);
            Field(o => o.Title);
            Field(o => o.Description);
            Field(o => o.VenuSize);
            Field(o => o.Price);
            Field(o => o.CurrencyId);
            Field(o => o.CurrencyFormat);
            Field(o => o.IsFreeShipping);
        }
    }
}
