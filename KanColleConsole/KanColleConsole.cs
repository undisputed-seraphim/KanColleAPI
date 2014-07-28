using System;
using System.IO;
using System.Text;
using System.Reflection;

using KanColle;
using KanColle.Request;
using Newtonsoft.Json;

namespace KanColleConsole {
	class KanColleConsole {

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			KanColleProxy kcp = new KanColleProxy(full_api_token, true);

			// Port testing 
			string context = ApiPort.PORT;
			string param = ApiPort.port("407966");
			
			string ret = kcp.proxy(context, param);

			Console.WriteLine("\nRaw Data:");
			Console.WriteLine(ret);
		}
	}
}
