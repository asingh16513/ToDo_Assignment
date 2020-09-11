using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helper
{
    /// <summary>
    /// Generic command for request which do not have any arguments.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmptyQuery<T> : IRequest<T>
    {
    }
}
