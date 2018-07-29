using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class DepartureService
    {
        readonly string url = "http://localhost:52729/api/departures";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Departure>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Departure>>(result);
        }

        public async Task<Departure> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Departure>(result);
        }

        public async Task Create(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Departure Departure)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Departure), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Departure.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
