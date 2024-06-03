using MvcConciertosExamen.Models;
using System.Net.Http.Headers;

namespace MvcConciertosExamen.Services
{
    public class ServiceApiConciertos
    {
        private MediaTypeWithQualityHeaderValue header;

        private string UrlApi;
        public ServiceApiConciertos(KeysModel keysModel)
        {
            this.UrlApi = keysModel.ApiConciertos;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }

        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/ConciertosContoller/GetEventos";
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            string request = "api/ConciertosContoller/GetCategorias";
            List<CategoriaEvento> data = await this.CallApiAsync<List<CategoriaEvento>>(request);
            return data;
        }

        public async Task<List<Evento>> GetEventosCategoriaAsync(int idcategoria)
        {
            string request = "api/ConciertosContoller/GetEventosCategoria/" + idcategoria;
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }
    }
}
