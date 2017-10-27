using EmpTrack.Constants;
using Newtonsoft.Json;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.NetworkServices.User
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// Saves the new emp details on the server.
        /// </summary>
        /// <returns>The emp details.</returns>
        /// <param name="parameters">Parameters.</param>
        public async Task<EmpResponse> SaveEmpDetails(Dictionary<string, object> parameters)
        {
            var content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
            HttpResponseMessage responseJson = await client.PostAsync(APIsConstant.SaveEmpDetailAPI, content);
            var json = await responseJson.Content.ReadAsStringAsync();
            var empResponse = JsonConvert.DeserializeObject<EmpResponse>(json);
            return empResponse;
        }
    }
}
