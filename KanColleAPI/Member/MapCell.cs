using System.Text;

namespace KanColle.Member {
	public class MapCell {
		public int api_id { get; set; }
		public int api_passed { get; set; }

		public static string MAPCELL = "api_get_member/mapcell/";

		public static string Get (int map_area_id, int map_info_no) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_maparea_id={0}&", map_area_id);
			str.Append("api_token={0}&");
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_mapinfo_mo={0}", map_info_no);
			return str.ToString();
		}
	}
}
