using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Schema
{
    public class MusicTicketsSchema : GraphQL.Types.Schema
    {
        public MusicTicketsSchema(MusicTicketsQuery query, IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
    }
}
