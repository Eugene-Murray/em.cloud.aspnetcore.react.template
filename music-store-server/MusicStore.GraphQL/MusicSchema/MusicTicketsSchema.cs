using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.GraphQL.MusicSchema
{
    public class MusicTicketsSchema : Schema
    {
        public MusicTicketsSchema(MusicTicketsQuery query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
