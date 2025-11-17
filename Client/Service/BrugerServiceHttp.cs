using System.Net.Http.Json;
using Core;



namespace Client.Service
{
    public class BrugerServiceHttp: IBrugerService
    {
        private HttpClient client;

        public BrugerServiceHttp(HttpClient client)
        { 
            this.client = client;
        }

        public async Task<Bruger[]?> GetAll()
        {
            return await client.GetFromJsonAsync<Bruger[]>($"{Server.Url}/bruger");
        }
        public async Task Add(Bruger bruger)
        {
            await client.PostAsJsonAsync($"{Server.Url}/bruger", bruger);
        }

        public async Task DeleteById(int id)
        {
            await client.DeleteAsync($"{Server.Url}/bike/delete?id={id}");
        }

    }
}
