using AppDemoLuigi.Models.ApiExterna;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppDemoLuigi.Services
{
    public class ApiExterna
    {
        private HttpClient client = new HttpClient();
        public ApiExterna()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Endereco> ObterEndereco(string cep)
        {
            try
            {
                var url = $"https://viacep.com.br/ws/{cep}/json/";
                HttpResponseMessage response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || result.IndexOf("Bad Request") != -1 || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                else
                    return JsonConvert.DeserializeObject<Endereco>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
