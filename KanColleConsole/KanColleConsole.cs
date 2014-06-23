using System;
using System.IO;
using System.Text;
using System.Reflection;

using KanColle;
using KanColle.Request.Kaisou;
using Newtonsoft.Json;

namespace KanColleConsole {
	class KanColleConsole {

		static void Main (string[] args) {
			Console.OutputEncoding = Encoding.Unicode;

			StreamReader reader = new StreamReader("api_token.txt");
			string full_api_token = reader.ReadLine();
			reader.Close();

			KanColleProxy kcp = new KanColleProxy(full_api_token, false);

			Console.WriteLine("ship ID, item ID, shot ID");

			string context = Kaisou.SLOTSET;
			string param = Kaisou.Slotset(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
			string ret = kcp.proxy(context, param);

			Console.WriteLine("\nRaw Data:");
			Console.WriteLine(ret);
		}
	}
}
