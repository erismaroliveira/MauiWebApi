using MauiWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiWebApi.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string userName, string password);
    }
}
