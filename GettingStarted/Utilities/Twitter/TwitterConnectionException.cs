using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities.Twitter
{
    class TwitterConnectionException : System.Exception
    {
        public TwitterConnectionException() : base() { }
        public TwitterConnectionException(string message) : base(message) { }
        public TwitterConnectionException(string message, System.Exception inner) : base(message, inner) { }

        protected TwitterConnectionException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}
