using System.Text;

namespace KanColle.Member {

	public class Ship3 {
		public int api_id { get; set; }
		public int api_sortno { get; set; }
		public int api_ship_id { get; set; }
		public int api_lv { get; set; }
		public int[] api_exp { get; set; }
		public int api_nowhp { get; set; }
		public int api_maxhp { get; set; }
		public int api_leng { get; set; }
		public int[] api_slot { get; set; }
		public int[] api_onslot { get; set; }
		public int[] api_kyouka { get; set; }
		public int api_backs { get; set; }
		public int api_fuel { get; set; }
		public int api_bull { get; set; }
		public int api_slotnum { get; set; }
		public int api_ndock_time { get; set; }
		public int[] api_ndock_item { get; set; }
		public int api_srate { get; set; }
		public int api_cond { get; set; }
		public int[] api_karyoku { get; set; }
		public int[] api_raisou { get; set; }
		public int[] api_taiku { get; set; }
		public int[] api_soukou { get; set; }
		public int[] api_kaihi { get; set; }
		public int[] api_taisen { get; set; }
		public int[] api_sakuteki { get; set; }
		public int[] api_lucky { get; set; }
		public int api_locked { get; set; }

		public static string SHIP3 = "api_get_member/ship3/";
		public static string SHIP2 = "api_get_member/ship2/";

		public static string Ship2 (int sort_key = 5, int sort_order = 2) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_sort_key={0}&", sort_key);
			str.Append("api_token={0}&");
			str.AppendFormat("spi_sort_order={0}&", sort_order);
			str.AppendFormat("api_verno={0}", 1);
			return str.ToString();
		}
	}
}
