using HotChocolate.Types;

namespace Application.QueryTypes
{
    public class LabelQueryType : ObjectType<LabelQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<LabelQueries> descriptor)
        {
            base.Configure(descriptor);

            descriptor
              .Field(f => f.GetLabels());
        }
    }
}
