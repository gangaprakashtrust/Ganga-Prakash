using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using GangaPrakashAPI.Model;

namespace GangaPrakash.UI
{
    public class WebAPIClient
    {
        public static async Task<T> GetAsync<T>(String Uri, String Path, String AccessToken=null) where T : new()
        {
            T result = new T();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (AccessToken==null)?String.Empty:AccessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = await client.GetAsync(Path);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();
                }
            }
            return result;
        }

        public static async Task<T> GetAsync<T>(String Uri, String Path) where T : new()
        {
            T result = new T();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = await client.GetAsync(Path);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();
                }
            }
            return result;
        }

        public static async Task<T> PostAsync<T>(String Uri, String Path, T result) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync(Path, result);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();
                }
            }
            return result;
        }

        public static async Task<T> PostAsync<T>(String Uri, String Path, T result, String AccessToken = null) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (AccessToken == null) ? String.Empty : AccessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                response = await client.PostAsJsonAsync(Path, result);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();
                }
            }
            return result;
        }
        public static async Task<String> Login(String Uri, String Path, LoginModel loginModel)
        {
            AccessToken result = new AccessToken();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", loginModel.Email),
                    new KeyValuePair<string, string>("password", loginModel.Password)
                };
                var content = new FormUrlEncodedContent(body);
                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(Path, content);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsAsync<AccessToken>();
                    }
                }
                catch(Exception ex)
                {

                }
                
            }
            return result.access_token;
        }
    }
}