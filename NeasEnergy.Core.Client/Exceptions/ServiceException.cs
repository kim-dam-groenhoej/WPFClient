using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeasEnergy.Core.Client.Exceptions
{
    public class ServiceException : Exception
    {
        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public ServiceException(String message)
    : base(message) {
        }
    }
}
