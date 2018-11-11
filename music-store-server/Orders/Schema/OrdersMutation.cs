﻿using GraphQL;
using GraphQL.Types;
using MusicStore.Models;
using MusicStore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Schema
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrderService orders)
        {
            Name = "Mutation";
            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>> { Name = "order" }),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderCreateInput>("order");
                    var id = Guid.NewGuid().ToString();
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created, orderInput.CustomerId, id);
                    return orders.CreateAsync(order);
                }
            );

            FieldAsync<OrderType>(
                "startOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "orderId" }),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<string>("orderId");
                    return await context.TryAsyncResolve(
                        async c => await orders.StartAsync(orderId));
                }
            );
        }
    }
}
