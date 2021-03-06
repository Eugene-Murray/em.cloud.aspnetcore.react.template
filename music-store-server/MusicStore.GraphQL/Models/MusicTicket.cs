﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.Models
{
    public class MusicTicket
    {
        public MusicTicket(int id, string SKU, string title, string description, string venuSize, double price, string currencyId, string currencyFormat, bool isFreeShipping)
        {
            Id = id;
            sku = SKU;
            Title = title;
            Description = description;
            VenuSize = venuSize;
            Price = price;
            CurrencyId = currencyId;
            CurrencyFormat = currencyFormat;
            IsFreeShipping = isFreeShipping;
        }

        public int Id { get; }
        public string sku { get; }
        public string  Title { get; }
        public string Description { get; }
        public string VenuSize { get; }
        public double Price { get; }
        public string CurrencyId { get; }
        public string CurrencyFormat { get; }
        public bool IsFreeShipping { get; }
    }
}
