using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace GrafOfOphilir.Class
{
    /// <summary>
    /// Инкапсуляция 
    /// </summary>
    public class HttpReader
    {
        /// <summary>
        /// Абстракция над некоторыми Web запросами
        /// </summary>
        public HttpReader()
        {

        }

        /// <summary>
        /// Get запрос по url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="responceJson">Результат запроса</param>
        /// <returns>true/false</returns>
        public bool Get<T>(string url, out T responceObject) where T:class,new()
        {
            var success = true;

            var httpClient = new HttpClient();
            var responce = httpClient.GetAsync(url).Result;
            var content = responce.Content.ReadAsStringAsync().Result;

            try
            {
                responceObject = JsonConvert.DeserializeObject<T>(content);
            }
            catch(Exception ex)
            {
                responceObject = null;
                success = false;

                var method = System.Reflection.MethodInfo.GetCurrentMethod().Name;
                Log.Error(ex,$"Произошла непредвиденная ошибка в методе {method}");
            }

            return success;
        }
    }
}
