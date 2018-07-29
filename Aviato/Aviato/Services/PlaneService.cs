using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class PlaneService
    {
        readonly string url = "http://localhost:52729/api/planes";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Plane>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Plane>>(result);
        }

        public async Task<Plane> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Plane>(result);
        }

        public async Task Create(Plane Plane)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Plane), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Plane Plane)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Plane), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Plane.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
