using GraphQL.Types;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Schema
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}
