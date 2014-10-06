using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KanColle.Request.Kousyou;

namespace RapidCraft {
	class RapidCraft {
		static void Main (string[] args) {
			if (args.Length == 0) {
				Console.WriteLine("USAGE: RapidCraft [Number of crafts] [Fuel] [Ammo] [Steel] [Bauxite]");
				Console.WriteLine("Set your flagship before you begin!");
			}

			int craftnum = int.Parse(args[0]);
			int fuel = int.Parse(args[1]), ammo = int.Parse(args[2]), steel = int.Parse(args[3]), baux = int.Parse(args[4]);

		}
	}
}
