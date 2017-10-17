using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentALanguageTeacher.App_Code
{
    [Serializable]
    public class NewUserException : Exception
    {
        public NewUserException()
            : base() { }

        public NewUserException(string message)
            : base(message) { }

        public NewUserException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NewUserException(string message, Exception innerException)
            : base(message, innerException) { }

        public NewUserException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        //protected NewUserException(SerializationInfo info, StreamingContext context)
        //    : base(info, context) { }
    }
}