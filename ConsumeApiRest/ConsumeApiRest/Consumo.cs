using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Transactions;

using ConsumeApiRest.Http;
using System.Web;


namespace ConsumeApiRest
{
    public class Consumo
    {

        public List<DTO.clsLoginSB1> ListLoginSB1 { get; set; }

        public string RutaUrlLoginSB1 = "https://charlie.sap.topmanage.cloud/b1s/v1/Login";

        public string RutaUrlPartnersSB1 = "https://charlie.sap.topmanage.cloud/b1s/v1/BusinessPartners";

        public List<DTO.dtoRegistrados> ListApi { get; set; }

        public List<DTO.dtoProductos> ListProducts { get; set; }

        public string TokenAuth;

        public string RutaUrl = "http://localhost/apidemo1/api/Registrados";

        public string RutaUrlPost = "http://localhost/apidemo1/api/Registrados";

        //public string RutaUrlPostToken = "http://localhost/apitoken1/api/Token/Authenticate";

        //public string RutaUrlgetAuth = "http://localhost/apitoken1/api/Productos";

        public string RutaUrlPostToken = "http://localhost:37803/api/Token/Authenticate";

        public string RutaUrlgetAuth = "http://localhost:37803/api/Productos";


        public string RutaUrlPostToken2 = "http://ec2-18-224-23-166.us-east-2.compute.amazonaws.com/tuti-handheld/api/v1/admin/login/";
        public string RutaUrlgetAuth2 = "http://ec2-18-224-23-166.us-east-2.compute.amazonaws.com/tuti-handheld/api/v1/dispo/all/";


        public List<DTO.dtoRegistrados> InsRegistro { get; set; }

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

                    //ApiSaB1();

                    //Console.WriteLine("INICIO get Api Auth.....");
                    //GetApiSB1();

                    //GetApi();

                    //Console.WriteLine("INICIO PROCESO POST.....");

                    //PostApi();

                    //Console.WriteLine("INICIO Post Token Login.....");



                    //PostTokenApi();

                    // Console.WriteLine("INICIO get Api Auth.....");

                    //GetApiAuth();

                    /************************************/

                    //GetApiAuth2();

                    PostTokenApi2();

                    System.Threading.Thread.Sleep(360000);

                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(15000);
                }
            }

        }

        public async void ApiSaB1()
        {

            //http://www.binaryintellect.net/articles/0f52c5bf-b7a4-4720-9572-6159b1804d1d.aspx

            //ListLoginSB1 = new List<DTO.clsLoginSB1>();

            var uriLoginSB1 = new Uri(RutaUrlLoginSB1);

            DTO.clsPostLogin PostLogin = new DTO.clsPostLogin();
            PostLogin.CompanyDB = "GRAIMP_GFPAC_UAT";
            PostLogin.UserName = "adminsistemas@grafimpac.com";
            PostLogin.Password = "K3oB4ws5nXpU";

            var json = JsonConvert.SerializeObject(PostLogin);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseLoginSB1 = null;

            responseLoginSB1 = await _client.PostAsync(uriLoginSB1, content);

            if (responseLoginSB1.IsSuccessStatusCode)
            {
                var contentSession = await responseLoginSB1.Content.ReadAsStringAsync();

                var objListLoginSB1 = JsonConvert.DeserializeObject<DTO.clsLoginSB1>(contentSession);

                TokenAuth = objListLoginSB1.SessionId;

                Console.WriteLine(objListLoginSB1.SessionId);

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("B1SESSION" , TokenAuth);

                //_client.DefaultRequestHeaders.Add("Cookie", "B1SESSION=" + TokenAuth + ";Path=/b1s/v1; HttpOnly;");
                //_client.DefaultRequestHeaders.Add("Cookie", "ROUTEID=" + ".node2" + ";Path=/;");

                var uri = new Uri(RutaUrlPartnersSB1);

                var responsegetAuth = await _client.GetAsync(uri);

                if (responsegetAuth.IsSuccessStatusCode)
                {
                    Console.WriteLine("Lectura ok SB1");
                }


            }
        }

        public async void GetApiSB1()
        {

           
            var uri = new Uri(RutaUrlPartnersSB1);

            if (string.IsNullOrEmpty(TokenAuth))
            {
                Console.WriteLine("No existe session ID aun");

            }
            else
            {

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("B1SESSION", TokenAuth);

                //_client.DefaultRequestHeaders.Add("B1SESSION", TokenAuth);
                //_client.DefaultRequestHeaders.Add("ROUTEID", ".node2");

                var responsegetAuth = await _client.GetAsync(uri);

                if (responsegetAuth.IsSuccessStatusCode)
                {
                    Console.WriteLine("Lectura ok SB1");
                }
                else
                {
                    Console.WriteLine("No autorizada");
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

            InsRegistro = new List<DTO.dtoRegistrados>();

            var uri = new Uri(RestServices.RutaUrlPost2);
            var uri2 = new Uri(RestServices.RutaUrlPost2 + "/Registrados2");

            DTO.clsPostRegistrado ItemApi = new DTO.clsPostRegistrado();
            
            DTO.clsPostRegistrado ItemApi2 = new DTO.clsPostRegistrado();
            
            //Cabecera
            ItemApi.identificacion = "0924258130001";
            ItemApi.nombres = "Api Rest -- AIFA-4";
            ItemApi.apellidos = "Consume";
            ItemApi.nombresCompletos = "Api rest Consume -- AIFA-4";

            //Detalle
            ItemApi2.identificacion = "0924258130001";

            var json = JsonConvert.SerializeObject(ItemApi);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responsePostCabecera = null;
            HttpResponseMessage responsePostDetalle = null;

            using (TransactionScope trans = new TransactionScope())
            {

                responsePostCabecera = await _client.PostAsync(uri, content);

                if (responsePostCabecera.IsSuccessStatusCode)
                {
                    Console.WriteLine("Se registro el dato");

                    var contentPost = await responsePostCabecera.Content.ReadAsStringAsync();

                    InsRegistro = JsonConvert.DeserializeObject<List<DTO.dtoRegistrados>>(contentPost);

                    if (InsRegistro.Count > 0)
                    {
                        for (int z=0; z < InsRegistro.Count; z++)
                        {
                            var IdRegistrado = InsRegistro[z].idRegistrado;

                            ItemApi2.nombres = IdRegistrado;

                            var jsonDetalle = JsonConvert.SerializeObject(ItemApi2);

                            var contentDetalle = new StringContent(jsonDetalle, Encoding.UTF8, "application/json");

                            responsePostDetalle = await _client.PostAsync(uri2, contentDetalle);
                        }

                    }

                    if (responsePostDetalle.IsSuccessStatusCode)
                    {
                        trans.Complete();
                    }

                }

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


        public async void PostTokenApi2()
        {

            var uri = new Uri(RutaUrlPostToken2);

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("usuario", "admin"),
                new KeyValuePair<string, string>("clave", "bonsai")
            });


            HttpResponseMessage responseTokenAuth = null;

            responseTokenAuth = await _client.PostAsync(uri, formContent);

            if (responseTokenAuth.IsSuccessStatusCode)
            {
                TokenAuth = responseTokenAuth.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                Console.WriteLine(TokenAuth);

            }

        }

        public async void GetApiAuth2()
        {

         
            var uri = new Uri(RutaUrlgetAuth2);

            _client.DefaultRequestHeaders.Add("Authorization", "1d8515315664de983adac5b5b3c19dc98a39fbaafd31a09ebdeb26201682e002948525367446b6240fb50e8f2d2497edb190d9a31f824ea10f710a15ea2fd81d");


            var responsegetAuth = await _client.GetAsync(uri);

                if (responsegetAuth.IsSuccessStatusCode)
                {
                    var content = await responsegetAuth.Content.ReadAsStringAsync();

                        Console.WriteLine("Authorizado");
                 }
                else
                {
                    Console.WriteLine("No Authorizado");
                }

            }

    }
}
