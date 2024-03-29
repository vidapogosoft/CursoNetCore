﻿using System;
using System.Collections.Generic;
using System.Text;


using CoreModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreApiClient
{
    public partial class ApiClient
    {

        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint)
        {

            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }

            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();

        }


        private async Task<T> GetAsync<T>(Uri requestUrl)
        {

            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);

        }

        //private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content)
        //{

        //    var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));

        //    response.EnsureSuccessStatusCode();

        //    var data = await response.Content.ReadAsStringAsync();

        //    return JsonConvert.DeserializeObject<Message<T>>(data);

        //}

        private async Task<bool> PostAsync<T>(Uri requestUrl, T content)
        {
            bool exito = false;

            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                
                exito = true;

            }

            return exito;
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }


        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }

    }
}
