using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebMotorsProject.Domain.Externals.Interface;

namespace WebMotorsProject.Domain.Externals
{
    public class GenericsExternalServices<T> : IGenericsExternalServices<T>
    {
        private string _queryParam;

        public string QueryParam
        {
            set { _queryParam = value; }
        }

        private string _uri;

        public string Uri
        {
            set { _uri = value; }
        }

        public GenericsExternalServices()
        {
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<T> Find()
        {
            List<T> result = new List<T>();
            using (var httpClient = new HttpClient())
            {
                UriBuilder uri = new UriBuilder(_uri);
                uri.Query = _queryParam;
                using (var response = httpClient.GetAsync(uri.Uri).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<T>>(apiResponse);
                }
            }
            return result;
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
