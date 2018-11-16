using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FleetManagementWebService.TokenService;

namespace FleetManagementWebService.Interfaces
{
    public interface IToken
    {
        TokenObject GetToken();
    }
}
