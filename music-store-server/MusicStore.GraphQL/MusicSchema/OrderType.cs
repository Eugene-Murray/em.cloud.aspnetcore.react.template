using GraphQL.Types;
using MusicStore.GraphQL.Models;
using MusicStore.GraphQL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.MusicSchema
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customers)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field(o => o.Description);
            Field<CustomerType>("customer",
                resolve: context => customers.GetCustomerByIdAsync(context.Source.CustomerId));
            Field(o => o.Created);
            Field<OrderStatusesEnum>("status",
                resolve: context => context.Source.Status);
        }
    }
}
