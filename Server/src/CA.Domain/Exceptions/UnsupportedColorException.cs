using System;

namespace CA.Domain.Exceptions
{
    public class UnsupportedColorException : Exception
    {
        public UnsupportedColorException(string code) : base($"Color \"{code}\" is unsupported.")
        {
        }
    }
}