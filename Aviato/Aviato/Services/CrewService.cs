using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class CrewService
    {
        readonly string url = "http://localhost:52729/api/crew";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Crew>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Crew>>(result);
        }

        public async Task<Crew> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Crew>(result);
        }

        public async Task Create(Crew Crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Crew Crew)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Crew), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Crew.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
