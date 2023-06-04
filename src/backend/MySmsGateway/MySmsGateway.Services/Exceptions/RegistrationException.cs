using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Services.Exceptions
{
    public class RegistrationException : Exception
    {
        public const string VERIFY_EMAIL = "This email is already registered with us.Please verify your email.";
        public const string ALLREADY_REGISTERED = "This email is already registered with us.";

        public RegistrationException(string message) : base(message)
        {

        }
    }
}
