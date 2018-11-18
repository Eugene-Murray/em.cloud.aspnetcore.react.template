using GraphQL.Types;
using MusicStore.GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.MusicSchema
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
