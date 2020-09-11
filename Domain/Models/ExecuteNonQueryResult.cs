using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExecuteNonQueryResult<T>
    {
        public int CommandResult { get; set; }

        public T Output { get; set; }
    }
}
