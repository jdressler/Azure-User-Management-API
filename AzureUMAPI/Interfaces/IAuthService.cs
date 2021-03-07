using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureUMAPI.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetAccessToken();
    }
}
