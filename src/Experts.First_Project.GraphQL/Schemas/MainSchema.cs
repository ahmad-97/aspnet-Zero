using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Experts.First_Project.Queries.Container;
using System;

namespace Experts.First_Project.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}