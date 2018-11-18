using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.MusicSchema
{
    public class MusicStoreSchema : Schema
    {
        public MusicStoreSchema(MusicStoreQuery query, OrdersMutation mutation, OrdersSubscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}
