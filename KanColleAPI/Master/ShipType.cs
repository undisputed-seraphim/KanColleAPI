using System;

namespace KanColle.Master {

	public class ShipType : IIdentifable, INameable {
		public int api_id { get; set; }
		public int api_sortno { get; set; }
		public string api_name { get; set; }
		public int api_scnt { get; set; }
		public int api_kcnt { get; set; }
		public Object api_equip_type { get; set; }
	}
}
