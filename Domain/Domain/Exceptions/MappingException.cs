﻿namespace Domain.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MappingException : Exception
    {
        public MappingException()
        {
        }

        public MappingException(string message)
            : base(message)
        {
        }

        public MappingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected MappingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}