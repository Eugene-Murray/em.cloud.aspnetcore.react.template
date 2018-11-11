using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Schema
{
    public class MusicTicketsSchema : GraphQL.Types.Schema
    {
        public MusicTicketsSchema(OrdersQuery query, OrdersMutation mutation, OrdersSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
