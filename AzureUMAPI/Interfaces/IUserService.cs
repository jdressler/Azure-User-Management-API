using AzureUMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureUMAPI.Interfaces
{
    public interface IUserService
    {
        Task<UsersResponse> GetAllUsers(string token);

    }
}
