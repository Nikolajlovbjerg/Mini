using Core;
using System.Net.Http.Json;


namespace Client.Services;

public class AnmodningService
{
    private readonly HttpClient _http;

    public AnmodningService(HttpClient http)
    {
        _http = http;
    }

    public async Task CreateRequest(Anmodning a)
    {
        await _http.PostAsJsonAsync("api/anmodning", a);
    }

    public async Task Accept(int id)
    {
        await _http.PutAsync($"api/anmodning/{id}/accept", null);
    }

    public async Task Reject(int id)
    {
        await _http.PutAsync($"api/anmodning/{id}/reject", null);
    }
}
