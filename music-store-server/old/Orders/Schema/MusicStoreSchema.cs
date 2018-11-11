using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Schema
{
    public class MusicStoreSchema : GraphQL.Types.Schema
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
