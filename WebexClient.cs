using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebexSDK.Controllers;
using WebexSDK.Models;

namespace WebexSDK
{
	public class WebexClient
	{
		internal const string BASE_ADRESS = "https://webexapis.com/v1/";
		
		public readonly CallControls call;
		public readonly PeopleControls people;
		public readonly WebhooksControls webhooks;
		public readonly ClientSocketControls clientSocket;
		internal readonly string token;
		
		public WebexClient(string bearer)
		{
			token = bearer;
			call = new CallControls(this);
			people = new PeopleControls(this);
			webhooks = new WebhooksControls(this);
			clientSocket = new ClientSocketControls();
		}
		
		internal async Task<T> Send<T>(string operation, object body)
		{
			var content = await PostRest(operation, JsonConvert.SerializeObject(body));
			var obj = JsonConvert.DeserializeObject<T>(content);
			if (obj == null)
				throw new Exception("Failed to deserialize response");
			
			return obj;
		}
		
		internal async Task<bool> Send(string operation, object body)
		{
			try
			{
				await PostRest(operation, JsonConvert.SerializeObject(body));
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		internal async Task<bool> Delete(string operation)
		{
			try
			{
				await DeleteRest(operation);
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		internal async Task<T> Request<T>(string operation)
		{
			var content = await GetRest(operation);
			var obj = JsonConvert.DeserializeObject<T>(content);
			if (obj == null)
				throw new Exception("Failed to deserialize response");
			
			return obj;
		}
		
		internal async Task<T[]> RequestArray<T>(string operation, string arrayName = "items")
		{
			var content = await GetRest(operation);
			var jo = Newtonsoft.Json.Linq.JObject.Parse(content);
			var items = jo[arrayName];
			
			if (items == null || items.Type != Newtonsoft.Json.Linq.JTokenType.Array)
				return Array.Empty<T>();
			
			return items.ToObject<T[]>() ?? Array.Empty<T>();
		}
		
		private async Task<string> GetRest(string operation)
		{
			var http = GetHttpClient();
			var response = await http.GetAsync(operation);
			if (!response.IsSuccessStatusCode)
				throw new HttpRequestException(
					"Failed to retrieve data from Webex API: " +
					$"{response.StatusCode} - {response.ReasonPhrase}"
				);
			
			return await response.Content.ReadAsStringAsync();
		}
		
		private async Task<string> PostRest(string operation, string json)
		{
			var http = GetHttpClient();
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await http.PostAsync(operation, content);
			if (!response.IsSuccessStatusCode)
				throw new HttpRequestException(
					"Failed to retrieve data from Webex API: " +
					$"{response.StatusCode} - {response.ReasonPhrase}"
				);
			
			return await response.Content.ReadAsStringAsync();
		}
		
		private async Task<bool> DeleteRest(string operation)
		{
			var http = GetHttpClient();
			var response = await http.DeleteAsync(operation);
			return response.IsSuccessStatusCode;
		}
		
		private HttpClient GetHttpClient()
		{
			if (token == null)
				throw new ArgumentNullException(nameof(token), "Bearer token cannot be null");
			
			var http = new HttpClient();
			http.BaseAddress = new Uri("https://webexapis.com/v1/");
			http.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json")
			);
			
			http.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", token);
			return http;
		}
		
		public static async Task<AccessToken> GetAccessToken(
			string code,
			string clientId,
			string clientSecret,
			string redirectUri
		)
		{
			if (string.IsNullOrWhiteSpace(code))
				throw new ArgumentException("Code cannot be null or empty", nameof (code));
			
			using (var http = new HttpClient())
			{
				http.BaseAddress = new Uri(BASE_ADRESS);
				http.DefaultRequestHeaders.Accept.Add(
					new MediaTypeWithQualityHeaderValue("application/json")
				);
				var form = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("grant_type", "authorization_code"),
					new KeyValuePair<string, string>("client_id", clientId),
					new KeyValuePair<string, string>("client_secret", clientSecret),
					new KeyValuePair<string, string>(nameof (code), code),
					new KeyValuePair<string, string>("redirect_uri", redirectUri)
				});
				var response = await http.PostAsync("access_token", form);
				if (!response.IsSuccessStatusCode)
					throw new HttpRequestException(
						"Failed to retrieve access token from Webex: " +
						$"{response.StatusCode} - {response.ReasonPhrase}"
					);
				var result = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<AccessToken>(result);
			}
		}
	}
}