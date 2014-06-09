﻿using System;
using System.Text;

using System.Net;
using System.IO;

namespace KanColle {
	public class KanColleProxy {
		private static string HEADER_REFERER =		"{0}kcs/mainD2.swf?api_token={1}/[[DYNAMIC]]/1";
		private static string HEADER_USER_AGENT =	"Mozilla/5.0 (Windows NT 6.1; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0";
		private static string HEADER_ACCEPT =		"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
		private static string HEADER_CONTENT_TYPE = "application/x-www-form-urlencoded";

		public const string DEFAULT_GET = "api_token={0}&api_verno=1";

		private readonly string USER_API_TOKEN;
		private readonly string USER_SERVER;

		public KanColleProxy (string api_token, string server) {
			this.USER_API_TOKEN = api_token;
			this.USER_SERVER = server;
		}

		public KanColleProxy (string input) {
			string[] tokens = input.Split(new string[] { "kcs/mainD2.swf?api_token=" }, StringSplitOptions.None);
			this.USER_SERVER = tokens[0];
			this.USER_API_TOKEN = tokens[1];
		}

		public string proxy (string context, string parameter = DEFAULT_GET) {
			Uri uri = new Uri(this.USER_SERVER + "kcsapi/" + context);
			string referer = string.Format(HEADER_REFERER, this.USER_SERVER, this.USER_API_TOKEN);
			HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
			parameter = String.Format(parameter, this.USER_API_TOKEN);
			byte[] bytearray = Encoding.ASCII.GetBytes(parameter);

			// For debug.
			/*
			Console.WriteLine(context);
			Console.WriteLine(uri);
			Console.WriteLine(parameter);
			*/

			// Set headers and method.
			request.Method = "POST";
			request.Referer = string.Format(HEADER_REFERER, this.USER_SERVER, this.USER_API_TOKEN);
			request.UserAgent = HEADER_USER_AGENT;
			request.Accept = HEADER_ACCEPT;
			request.ContentType = HEADER_CONTENT_TYPE;
			request.ContentLength = bytearray.Length;
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.KeepAlive = true;

			// Get stream, write, flush and close.
			Stream requestStream = request.GetRequestStream();
			requestStream.Write(bytearray, 0, bytearray.Length);
			requestStream.Flush();
			requestStream.Close();

			// Get the response, status, etc.
			HttpWebResponse response = (HttpWebResponse) request.GetResponse();
			HttpStatusCode status = response.StatusCode;
			if (status != HttpStatusCode.OK) {
				Console.WriteLine(status);
				// To implement: Throw an exception here
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

		public string proxyWithFileWrite (string path, string context, string parameter = DEFAULT_GET) {
			string output = proxy(context, parameter);

			StreamWriter fileStream = new StreamWriter(path, false, Encoding.UTF8);
			fileStream.WriteLine(output);
			fileStream.Flush();
			fileStream.Close();

			return output;
		}
	}
}