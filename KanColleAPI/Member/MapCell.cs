using System.Text;

namespace KanColle.Member {
	public class MapCell {
		public int api_id { get; set; }
		public int api_passed { get; set; }

		public static string MAPCELL = "api_get_member/mapcell/";

		public static string Get (int map_area_id, int map_info_no) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_maparea_id={0}&", map_area_id);
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_mapinfo_no={0}&", map_info_no);
			str.Append("api_token={0}");
			return str.ToString();
		}

		public override string ToString () {
			return string.Format("api_id={0}\tapi_passed={1}", this.api_id, this.api_passed);
		}
	}
}
