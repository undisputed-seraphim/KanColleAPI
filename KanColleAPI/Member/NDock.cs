﻿namespace KanColle.Member {

	public class NDock : IIdentifable {
		public int api_member_id { get; set; }
		public int api_id { get; set; }
		public int api_state { get; set; }
		public int api_ship_id { get; set; }
		public long api_complete_time { get; set; }
		public string api_complete_time_str { get; set; }
		public int api_item1 { get; set; }
		public int api_item2 { get; set; }
		public int api_item3 { get; set; }
		public int api_item4 { get; set; }

		public static string GET = "api_get_member/ndock/";
	}
}
