using HotChocolate.Types;

namespace Application.QueryTypes
{
    public class LabelQueryType : ObjectType<AssessmentQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<AssessmentQuery> descriptor)
        {
            base.Configure(descriptor);

            descriptor
              .Field(f => f.GetLabels());
        }
    }
}
