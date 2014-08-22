using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColle {
	public sealed class Expedition {
		private readonly string name;
		private readonly int id;
		private readonly int period;

		public static readonly Expedition 練習航海 = new Expedition("練習航海", 1, 15);
		public static readonly Expedition 長距離練習航海 = new Expedition("長距離練習航海", 2, 30);
		public static readonly Expedition 警備任務 = new Expedition("警備任務", 3, 20);

		private Expedition (string name, int id, int period) {
			this.name = name;
			this.id = id;
			this.period = period;
		}

		public override string ToString () {
			return this.name;
		}
	}
}
