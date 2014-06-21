using System.Text;

namespace KanColle.Request.Map {

	public class Map {
		public static string START = "api_req_map/start/";
		public static string NEXT = "api_req_map/next/";

		public static string Start (int mapinfo_no, int deck_id, int maparea_id, int formation_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_mapinfo_no={0}&", mapinfo_no);
			str.AppendFormat("api_deck_id={0}&", deck_id);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_maparea_id={0}&", maparea_id);
			str.AppendFormat("api_formation_id={0}", formation_id);
			return str.ToString();
		}

		public static string Next (int recovery_type = 0) {
			StringBuilder str = new StringBuilder();
			str.Append("api_token={0}&");
			str.AppendFormat("api_recovery_type={0}&", recovery_type);
			str.AppendFormat("api_verno={0}", 1);
			return str.ToString();
		}
	}

	public class Start {
		public int api_rashin_flg { get; set; }
		public int api_rashin_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_mapinfo_no { get; set; }
		public int api_no { get; set; }
		public int api_color_no { get; set; }
		public int api_event_id { get; set; }
		public int api_event_kind { get; set; }
		public int api_next { get; set; }
		public int api_bosscell_no { get; set; }
		public int api_bosscomp { get; set; }
		public Enemy api_enemy { get; set; }
	}

	public class Next {
		public int api_rashin_flg { get; set; }
		public int api_rashin_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_mapinfo_no { get; set; }
		public int api_no { get; set; }
		public int api_color_no { get; set; }
		public int api_event_id { get; set; }
		public int api_event_kind { get; set; }
		public int api_next { get; set; }
		public int api_bosscell_no { get; set; }
		public int api_bosscomp { get; set; }
		public int api_comment_kind { get; set; }
		public int api_production_kind { get; set; }
		public Enemy api_enemy { get; set; }
	}

	public class Enemy {
		public int api_enemy_id { get; set; }
		public int api_result { get; set; }
		public string api_result_str { get; set; }
	}
}
