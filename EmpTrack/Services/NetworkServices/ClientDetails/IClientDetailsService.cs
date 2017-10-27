using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.NetworkServices.ClientDetails
{
    public interface IClientDetailsService
    {
        Task<Services.Models.ClientDetails> FetchClientDetails(string clientid);
    }
}
