using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class StewardessService
    {
        readonly string url = "http://localhost:52729/api/stewardesses";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Stewardess>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Stewardess>>(result);
        }

        public async Task<Stewardess> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Stewardess>(result);
        }

        public async Task Create(Stewardess Stewardess)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Stewardess), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Stewardess Stewardess)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Stewardess), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Stewardess.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
