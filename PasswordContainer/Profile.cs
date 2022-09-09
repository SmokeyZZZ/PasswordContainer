using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordContainer
{
    class Profile
    {
        private string _serviceName, _password;
        public Profile(string serviceName, string password)
        {
            _serviceName = serviceName;
            _password = password;
        }
        public string ServiceName { get => _serviceName; }
        public string Password { get => _password; }
        

    }
}
