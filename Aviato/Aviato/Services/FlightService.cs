using Aviato.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class FlightService
    {
        readonly string url = "http://localhost:52729/api/flights";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Flight>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Flight>>(result);
        }

        public async Task<Flight> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Flight>(result);
        }

        public async Task Create(Flight flight)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Flight flight)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(flight), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + flight.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }

    }
}
