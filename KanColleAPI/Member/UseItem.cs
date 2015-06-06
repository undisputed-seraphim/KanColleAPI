using System.Collections.Generic;

namespace KanColle.Member {
	public class UseItem : IIdentifable, INameable {
		public int api_member_id { get; set; }
		public int api_id { get; set; }
		public int api_value { get; set; }
		public int api_usetype { get; set; }
		public int api_category { get; set; }
		public string api_name { get; set; }
		public List<string> api_description { get; set; }
		public int api_price { get; set; }
		public int api_count { get; set; }

		public static string USEITEM = "api_get_member/useitem/";

		public int ID() { return this.api_id; }

		public string Name() { return this.api_name; }
	}
}
