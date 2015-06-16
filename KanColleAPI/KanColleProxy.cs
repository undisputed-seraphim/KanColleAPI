using System;
using System.IO;
using System.Net;
using System.Text;

using Newtonsoft.Json;
using KanColle.Member;

namespace KanColle {
	public sealed class KanColleProxy {

		private static string HEADER_REFERER = "{0}kcs/mainD2.swf?api_token={1}/[[DYNAMIC]]/1";
		private static string HEADER_USER_AGENT = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
		private static string HEADER_ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
		private static string HEADER_CONTENT_TYPE = "application/x-www-form-urlencoded";

		public const string DEFAULT_GET = "api_token={0}&api_verno=1";

		public readonly string USER_API_TOKEN;
		public readonly string USER_SERVER;

		public bool debug { get; set; }

		public KanColleProxy(string api_token, string server, bool debug = false) {
			this.USER_API_TOKEN = api_token;
			this.USER_SERVER = server;
			this.debug = debug;
		}

		public KanColleProxy(string input, bool debug = false) {
			string[] tokens = input.Split(new string[] { "kcs/mainD2.swf?api_token=" }, StringSplitOptions.None);
			if (tokens.Length != 2)
				throw new KancolleInvalidAPITokenException("This API token is in an invalid format.");
			this.USER_SERVER = tokens[0];
			this.USER_API_TOKEN = tokens[1];
			this.debug = debug;
		}

		public string proxy(string context, string parameter = DEFAULT_GET) {
#if DEBUG
			Console.WriteLine("API TOKEN: " + this.USER_API_TOKEN);
			Console.WriteLine("SERVER: " + this.USER_SERVER);
#endif

			Uri uri = new Uri(this.USER_SERVER + "kcsapi/" + context);
			string referer = string.Format(HEADER_REFERER, this.USER_SERVER, this.USER_API_TOKEN);
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			parameter = String.Format(parameter, this.USER_API_TOKEN);
			byte[] bytearray = Encoding.ASCII.GetBytes(parameter);

#if DEBUG
			Console.WriteLine("CONTEXT: " + context);
			Console.WriteLine("URI: " + uri);
			Console.WriteLine("PARAMETER: " + parameter);
#endif

			// Set headers and method.
			request.Method = "POST";
			request.Referer = string.Format(HEADER_REFERER, this.USER_SERVER, this.USER_API_TOKEN);
			request.UserAgent = HEADER_USER_AGENT;
			request.Accept = HEADER_ACCEPT;
			request.ContentType = HEADER_CONTENT_TYPE;
			request.ContentLength = bytearray.Length;
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.KeepAlive = true;

#if DEBUG
			Console.WriteLine("");
			Console.WriteLine("REFERER: " + request.Referer);
			Console.WriteLine("CONTENT LENGTH: " + request.ContentLength);
#endif

			// Get stream, write, flush and close.
			bool notSuccessful = true;
			while (notSuccessful) {
				try {
					Stream requestStream = request.GetRequestStream();
					requestStream.Write(bytearray, 0, bytearray.Length);
					requestStream.Flush();
					requestStream.Close();
					notSuccessful = false;
				} catch (WebException error) {
					// Sleep, then continue trying
					Console.WriteLine(error.ToString());
					System.Threading.Thread.Sleep(250);
				}
			}

			// Get the response, status, etc.
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			HttpStatusCode status = response.StatusCode;

#if DEBUG
			Console.WriteLine("HTTP STATUS CODE: " + status);
#endif

			if (status != HttpStatusCode.OK) {
				Console.WriteLine(status);
				// ToDo: Throw an exception here
			}
			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream, Encoding.UTF8, true);
			string output = reader.ReadToEnd().Trim();
			reader.Close();
			responseStream.Close();
			response.Close();

			output = System.Text.RegularExpressions.Regex.Unescape(output).Substring(7);
			// Console.WriteLine(output);
			return output;
		}

		public string proxyWithFileWrite(string path, string context, string parameter = DEFAULT_GET) {
			string output = proxy(context, parameter);

			StreamWriter fileStream = new StreamWriter(path, false, Encoding.UTF8);
			fileStream.WriteLine(output);
			fileStream.Flush();
			fileStream.Close();

			return output;
		}

		#region Convenience methods
		// For getting some of the more important, commonly-used data

		public KanColle.Member.Basic GetBasic() {
			try {
				string json_response = this.proxy(KanColle.Member.Basic.GET);
				KanColleAPI<KanColle.Member.Basic> basic = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Member.Basic>>(json_response);
				return basic.GetData();
			} catch (Exception e) {
#if DEBUG
				Console.WriteLine(e.Message);
#endif
				throw new Exception(e.Message);
			}
		}

		// WARNING: Start2 currently cannot be parsed because the server returns some invalid JSON (there are stray quotation marks
		// in the returned data that causes the parser to panic).
		// Since data in Start2 tend to be static anyway, please find a workaround such as by preloading data manually instead of dynamically.
		public KanColle.Master.Start2 GetStart2() {
			try {
				string json_response = this.proxy(KanColle.Master.Start2.GET);
				KanColleAPI<KanColle.Master.Start2> start2 = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Master.Start2>>(json_response);
				return start2.GetData();
			} catch (Exception e) {
#if DEBUG
				Console.WriteLine(e.Message);
#endif
				throw new Exception(e.Message);
			}
		}

		public KanColle.Member.Port GetPort(string member_id) {
			try {
				string json_response = this.proxy(ApiPort.PORT, ApiPort.port(member_id));
				KanColleAPI<KanColle.Member.Port> port = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Member.Port>>(json_response);
				return port.GetData();
			} catch (Exception e) {
#if DEBUG
				Console.WriteLine(e.Message);
#endif
				throw new Exception(e.Message);
			}
		}

		#endregion

		public static T ParseArbitraryJSON<T>(string filepath) {
			StreamReader reader = new StreamReader(filepath);
			string input = reader.ReadToEnd();
			reader.Close();

			T parsed_json = JsonConvert.DeserializeObject<T>(input);
			return parsed_json;
		}
	}
}