﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Models
{
    public class Customer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; set; }
    }
}
