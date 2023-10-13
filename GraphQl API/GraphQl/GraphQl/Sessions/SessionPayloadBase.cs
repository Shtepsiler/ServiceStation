using GraphQl.Common.Exceptions;
using GraphQl.Common;
using GraphQl.Data;

namespace GraphQl.Sessions
{
    public class SessionPayloadBase : Payload
    {
        protected SessionPayloadBase(Session session)
        {
            Session = session;
        }

        protected SessionPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Session? Session { get; }
    }
}
