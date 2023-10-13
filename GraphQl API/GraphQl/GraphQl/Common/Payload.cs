using GraphQl.Common.Exceptions;
using System.Collections.Generic;
namespace GraphQl.Common
{
    public class Payload
    {
        protected Payload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
    }
}
