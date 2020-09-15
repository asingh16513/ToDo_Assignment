using Domain.Models;
using HotChocolate.Types;

namespace Domain.GraphQlModels
{
    public class LabelType : ObjectType<Label>
    {
        protected override void Configure(IObjectTypeDescriptor<Label> label)
        {
            base.Configure(label);
            label.Field(a => a.Id).Type<IdType>();
            label.Field(a => a.Name).Type<StringType>();
        }
    }
}
