using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Services.NetworkServices.CarDetails
{
    public class CarDetailsService : BaseService, ICarDetailsService
    {
        public async Task<LotDetails> FetchCarDetailsByLotNumber(string lot_id)
        {
            try
            {
                string r = EmpTrack.Constants.APIsConstant.FetchLotDetails + lot_id;
                var responseJson = await client.GetAsync(r);
                string json = await responseJson.Content.ReadAsStringAsync();
                if (!json.Equals(null)) //only parse json if it contains data
                {
                    var lotresponse = JsonConvert.DeserializeObject<Services.Models.LotDetails>(json);
                    return lotresponse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FetchMeditationBaseOn Id", ex.Message);
            }

            return null;
        }

        public async Task<LotList> FetchLotListByBuyerID(string buyer_id)
        {
            try
            {
                string r = EmpTrack.Constants.APIsConstant.FetchLotList + buyer_id;
                var responseJson = await client.GetAsync(r);
                string json = await responseJson.Content.ReadAsStringAsync();
                if (!json.Equals(null)) //only parse json if it contains data
                {
                    var lotresponse = JsonConvert.DeserializeObject<Services.Models.LotList>(json);
                    return lotresponse;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FetchMeditationBaseOn Id", ex.Message);
            }

            return null;
        }
    }
}
