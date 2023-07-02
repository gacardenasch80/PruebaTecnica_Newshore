using Newtonsoft.Json;
using PruebaTecnica_Newshore.Data.Model;
using PruebaTecnica_Newshore.Service.ExternService.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_Newshore.Service.ExternService
{
    public static class NewshoreRestApi
    {
        /// <summary>
        /// Funcion que consume el Api externo al sistema consulta flights
        /// </summary>
        /// <returns>Lista de flights</returns>
        public static async Task<IEnumerable<NewshoreFlights>> GetFlights(string opcion)
        {
            string url = "https://recruiting-api.newshore.es/api/flights/"+opcion;
            using (var httpClient = new HttpClient())
            {
                var response = await Task.FromResult(httpClient.GetStringAsync(new Uri(url)).Result);
                return JsonConvert.DeserializeObject<IEnumerable<NewshoreFlights>>(response);
            }
        }
    }
}
