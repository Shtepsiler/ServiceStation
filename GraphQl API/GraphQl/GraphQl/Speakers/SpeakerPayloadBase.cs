﻿using GraphQl.Common;
using GraphQl.Common.Exceptions;
using GraphQl.Data;

namespace GraphQl.Speakers
{
    public class SpeakerPayloadBase: Payload
    {
        protected SpeakerPayloadBase(Speaker speaker)
        {
            Speaker = speaker;
        }

        protected SpeakerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Speaker? Speaker { get; }
    }
}
