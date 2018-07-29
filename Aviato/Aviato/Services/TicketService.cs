using Aviato.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Services
{
    public class TicketService
    {
        readonly string url = "http://localhost:52729/api/tickets";
        HttpClient _httpclient = new HttpClient();

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            string result = await _httpclient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Ticket>>(result);
        }

        public async Task<Ticket> Get(int id)
        {
            string result = await _httpclient.GetStringAsync(url + "/" + id);
            return JsonConvert.DeserializeObject<Ticket>(result);
        }

        public async Task Create(Ticket Ticket)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
            await _httpclient.PostAsync(url, stringContent).ConfigureAwait(false);
        }

        public async Task Update(Ticket Ticket)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(Ticket), Encoding.UTF8, "application/json");
            await _httpclient.PutAsync(url + "/" + Ticket.Id, stringContent).ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            await _httpclient.DeleteAsync(url + "/" + id).ConfigureAwait(false);
        }
    }
}
