﻿
namespace KanColle.Member {
	public class MapInfo : IIdentifable {
		public int api_id { get; set; }
		public int api_cleared { get; set; }
		public int api_exboss_flag { get; set; }
		public int? api_defeat_count { get; set; }

		public static string MAPINFO = "api_get_member/mapinfo/";

		public int ID() { return this.api_id; }
	}
}
