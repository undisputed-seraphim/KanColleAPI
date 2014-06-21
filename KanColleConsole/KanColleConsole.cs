using System;
using System.IO;
using System.Text;

using KanColle;

namespace KanColleConsole {
	class KanColleConsole {

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			KanColleProxy kcp = new KanColleProxy(full_api_token, true);
			string context = ApiPort.PORT;
			string param = ApiPort.port("407966");

			string ret = kcp.proxyWithFileWrite("output.txt", context, param);
			Console.WriteLine("Press any key to display the first 100 characters of the output...");
			Console.Read();
			Console.WriteLine(ret.Substring(0, 100));
		}
	}
}
