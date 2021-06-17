using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using CoreModel;

namespace CoreApiClient
{
    public partial class ApiClient
    {

        public async Task<List<RegistradoModel>> GetRegistrados()
        {

            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Registrados"));

            return await GetAsync<List<RegistradoModel>>(requestUrl);

        }

        public async Task<bool> SaveRegistrado(RegistradoModel registrado)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "Registrados"));

            return await PostAsync<RegistradoModel>(requestUrl, registrado);

        }

    }
}
