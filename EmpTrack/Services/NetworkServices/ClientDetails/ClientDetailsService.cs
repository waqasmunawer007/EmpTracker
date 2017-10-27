using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Services.NetworkServices.ClientDetails
{
    class ClientDetailsService : BaseService, IClientDetailsService
    {
        public async Task<Models.ClientDetails> FetchClientDetails(string clientid)
        {
            string r = EmpTrack.Constants.APIsConstant.FetchClientDetails + clientid;
            var responseJson = await client.GetAsync(r);
            string json = await responseJson.Content.ReadAsStringAsync();
            try
            {
                var lotresponse = JsonConvert.DeserializeObject<Services.Models.ClientDetails>(json);
                return lotresponse;
            }
            catch
            {
                Debug.WriteLine("Bad Request");
            }
            return null;
        }
    }
}
