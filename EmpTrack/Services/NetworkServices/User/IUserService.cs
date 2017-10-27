using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.NetworkServices.User
{
    public interface IUserService
    {
        Task<EmpResponse> SaveEmpDetails(Dictionary<string, object> parameters); //Post new employee details on the server
    }
}
