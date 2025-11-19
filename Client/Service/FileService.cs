using System.Net.Http.Json;

namespace Client.Service
{
    public class FileService : IFileService
    {
        private HttpClient http;

        public FileService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<(bool success, string info)> SendFile(string filename, Stream s)

        {

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(s), "file", filename);

            var response = await http.PostAsync($"{Server.Url}/files/upload", content);

            string key = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, key);
            }

            return (false, response.ReasonPhrase);

        }

        public async Task<List<string>> GetAllKeys()
        {
            var keys = await http.GetFromJsonAsync<List<string>>($"{Server.Url}/files/getall");

            return keys;
        }

        public string ConvertToUrl(string key) => $"{Server.Url}/files/{key}";

        public async Task<(bool success, string info)> DeleteFile(string filename)
        {

            var httpResp = await http.DeleteAsync($"{Server.Url}/files/{filename}");
            if (httpResp.IsSuccessStatusCode)
            {
                return (true, "File deleted");
            }
            return (false, httpResp.ReasonPhrase);

        }
    }
}
