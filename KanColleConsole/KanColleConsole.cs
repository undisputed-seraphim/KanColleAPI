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

			KanColleProxy kcp = new KanColleProxy(full_api_token);
		}
	}
}
