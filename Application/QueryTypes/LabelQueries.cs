using Domain.GraphQlModels;
using HotChocolate.Types.Relay;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.QueryTypes
{
    public class LabelQueries
    {
        private ILabelDBManager _labelservice;
        public LabelQueries(ILabelDBManager labelDBManager)
        {
            _labelservice = labelDBManager;
        }
        [UsePaging(SchemaType = typeof(LabelType))]
        public async Task<List<Domain.Models.Label>> GetLabels() => await _labelservice.GetLabels();
    }
}
