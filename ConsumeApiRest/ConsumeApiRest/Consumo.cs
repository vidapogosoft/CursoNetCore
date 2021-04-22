using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumeApiRest
{
    public class Consumo
    {
        public List<DTO.dtoRegistrados> ListApi { get; set; }

        public List<DTO.dtoProductos> ListProducts { get; set; }

        public string TokenAuth;

        public string RutaUrl = "http://localhost/apidemo1/api/Registrados";

        public string RutaUrlPost = "http://localhost/apidemo1/api/Registrados";

        public string RutaUrlPostToken = "http://localhost/apitoken1/api/Token/Authenticate";

        public string RutaUrlgetAuth = "http://localhost/apitoken1/api/Productos";

        HttpClient _client; 

        public Consumo()
        {
            _client = new HttpClient();

        }


        public void ConsumoApi()
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("**************************************" + DateTime.Now.ToLongTimeString());
                    Console.WriteLine("INICIO PROCESO GET.....");

                    GetApi();

                    Console.WriteLine("INICIO PROCESO POST.....");

                    PostApi();

                    Console.WriteLine("INICIO Post Token Login.....");

                    PostTokenApi();

                    Console.WriteLine("INICIO get Api Auth.....");

                    GetApiAuth();

                    System.Threading.Thread.Sleep(5000);

                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }

        }

        public async void GetApi()
        {
            ListApi = new List<DTO.dtoRegistrados>();

            var uri = new Uri(RutaUrlPost);

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                ListApi = JsonConvert.DeserializeObject<List<DTO.dtoRegistrados>>(content);
            }

            if (ListApi.Count > 0)
            {
                Console.WriteLine(ListApi.Count);
            }
        }

        public async void PostApi()
        {

            var uri = new Uri(RutaUrl);

            DTO.clsPostRegistrado ItemApi = new DTO.clsPostRegistrado();

            ItemApi.identificacion = "0924258130001";
            ItemApi.nombres = "Api Rest";
            ItemApi.apellidos = "Consume";
            ItemApi.nombresCompletos = "Api rest Consume";

            var json = JsonConvert.SerializeObject(ItemApi);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responsePost = null;

            responsePost = await _client.PostAsync(uri, content);

            if (responsePost.IsSuccessStatusCode)
            {
                Console.WriteLine("Se registro el dato");
            }

        }

        public async void PostTokenApi()
        {

            var uri = new Uri(RutaUrlPostToken);

            DTO.TokenAuth auth = new DTO.TokenAuth();

            auth.Username = "demo";
            auth.Password = "123456";

            var json = JsonConvert.SerializeObject(auth);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseTokenAuth = null;

            responseTokenAuth = await _client.PostAsync(uri, content);

            if (responseTokenAuth.IsSuccessStatusCode)
            {
                TokenAuth = responseTokenAuth.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                Console.WriteLine(TokenAuth);

            }

         }

        public async void GetApiAuth()
        {

            ListProducts = new List<DTO.dtoProductos>();

            var uri = new Uri(RutaUrlgetAuth);


            if (string.IsNullOrEmpty(TokenAuth))
            {
                Console.WriteLine("No existe token aun");

            }
            else
            {

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenAuth);

                var responsegetAuth = await _client.GetAsync(uri);

                if (responsegetAuth.IsSuccessStatusCode)
                {
                    var content = await responsegetAuth.Content.ReadAsStringAsync();

                    ListProducts = JsonConvert.DeserializeObject<List<DTO.dtoProductos>>(content);
                }

                if (ListProducts.Count > 0)
                {
                    Console.WriteLine(ListProducts.Count);
                }
                else
                {
                    Console.WriteLine("No Authorizado");
                }

            }

        }

    }
}
