using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenApi.Auth
{
    public interface IJwtAuthenticationService
    {

        string Authenticate(string username, string password);

    }
}
