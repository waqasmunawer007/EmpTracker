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
            try
            {
                string r = EmpTrack.Constants.APIsConstant.FetchClientDetails + clientid;
                var responseJson = await client.GetAsync(r);
                string json = await responseJson.Content.ReadAsStringAsync();
                if(!json.Equals(null)) //only parse json if it contains data
                {
                    if(json.Contains("true"))
                    {
                        var lotresponse = JsonConvert.DeserializeObject<Services.Models.ClientDetails>(json);
                        return lotresponse;
                    }
                    else if (json.Contains("false"))
                    {
                        Services.Models.ClientDetails clientDetail = new Services.Models.ClientDetails();
                        clientDetail.Status = false;
                        return clientDetail;
                    }
                }
            }
            catch
            {
                Debug.WriteLine("Bad Request");
            }
            return null;
        }
    }
}
