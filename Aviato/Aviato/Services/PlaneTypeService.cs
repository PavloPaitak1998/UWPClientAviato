using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class PlaneTypeService
    {
        readonly string url = "http://localhost:52729/api/planetypes";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<PlaneType>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<PlaneType>>(result);
        }

        public async Task<PlaneType> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<PlaneType>(result);
        }

        public async Task Create(PlaneType PlaneType)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(PlaneType), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(PlaneType PlaneType)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(PlaneType), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + PlaneType.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
