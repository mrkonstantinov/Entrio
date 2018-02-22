using System;

namespace Entrio.Common.Exceptions
{
    public class EntrioException : Exception
    {
        public string Code { get; }

        public EntrioException()
        {
        }

        public EntrioException(string code)
        {
            Code = code;
        }

        public EntrioException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public EntrioException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public EntrioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public EntrioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}