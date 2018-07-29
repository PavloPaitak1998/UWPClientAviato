using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class PilotService
    {
        readonly string url = "http://localhost:52729/api/pilots";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Pilot>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Pilot>>(result);
        }

        public async Task<Pilot> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Pilot>(result);
        }

        public async Task Create(Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Pilot Pilot)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Pilot), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Pilot.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
