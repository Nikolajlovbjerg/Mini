using System.Net.Http.Json;
using Core;
namespace Client.Service
{
    public class AnnonceServiceHttp: IAnnonceService
    {
        private HttpClient client;


        public AnnonceServiceHttp(HttpClient client)
        { 
        this.client = client;
        }

        public async Task<List<Annonce>?> GetAll()
        {
            return await client.GetFromJsonAsync<List<Annonce>?>($"{Server.Url}/api/annoncer");

        }

        public async Task Add(Annonce annonce)  
        {
            await client.PostAsJsonAsync($"{Server.Url}/api/annoncer", annonce);
        }
       

        //public async Task DeleteById(int id)
        //{
        //    await client.DeleteAsync($"{Server.Url}/api/bruger/delete?id={id}");
        //}
    }
}
