using System;

namespace ReadGosuslugi.Exceptions
{
    public class ManagedExceptionBase : Exception
    {
        public int ResultCode { get; set; } = -1;
    }
}
