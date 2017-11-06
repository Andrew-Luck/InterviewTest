using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Makuru.ThickClient.DataAccess
{
    public class BaseDataAccessor
    {
        private string baseUri = string.Empty;
        protected string Resource { get; set; }

        public BaseDataAccessor(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public TModel GetData<TModel>(IList<string> parameters = null)
        {
            var uri = createUri(parameters);
            var apiResult = Get(uri);
            var item = ProcessResponse<TModel>(apiResult);

            return item;
        }

        private bool Post(Uri uri, dynamic model)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(model));
            request.Content.Headers.ContentType.MediaType = "application/json";
            var response = client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

            return true;
        }

        public bool Insert(dynamic model)
        {
            var uri = createUri();
            var result = Post(uri, model);
            return result;
        }

        private string Get(Uri uri)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = client.SendAsync(request).Result;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new EntryPointNotFoundException();

            var jsonResult = response.Content.ReadAsStringAsync().Result;

            return jsonResult;
        }

        private Uri createUri(IList<string> parameters = null)
        {
            var commpiledUri = string.Format("{0}{1}", baseUri, Resource);

            if (parameters == null)
                return new Uri(commpiledUri);

            foreach (var parameter in parameters)
                commpiledUri = string.Format("{0}/{1}", commpiledUri, parameter);

            return new Uri(commpiledUri);
        }

        private TModel ProcessResponse<TModel>(string apiResult)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(apiResult);
            return result;
        }
    }
}
