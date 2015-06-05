using System.Collections.Generic;

namespace KanColle.Master {
	public class UseItem : Iidentifiable {
		public int api_id { get; set; }
		public int api_usetype { get; set; }
		public int api_category { get; set; }
		public string api_name { get; set; }
		public string[] api_description { get; set; }
		public int api_price { get; set; }
	}

	public class PayItem : Iidentifiable {
		public int api_id { get; set; }
		public int api_type { get; set; }
		public string api_name { get; set; }
		public string api_description { get; set; }
		public int[] api_item { get; set; }
		public int api_price { get; set; }
	}

	public class ItemShop {
		public List<int> api_cabinet_1 { get; set; }
		public List<int> api_cabinet_2 { get; set; }
	}

	public class BGM {
		public int api_id { get; set; }
		public string api_name { get; set; }
	}
}
