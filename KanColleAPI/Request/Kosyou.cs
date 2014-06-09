using System.Text;

namespace KanColle.Request {

	public class Kousyou {
		public static string GETSHIP = "api_req_kousyou/getship/";
		public static string DESTROYITEM = "api_req_kousyou/destroyitem2/";
		public static string CREATESHIP = "api_erq/kousyou/createship/";
		public static string DESTROYSHIP = "api_req_kousyou/destroyship/";

		public static string GetShip (int kdock_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_kdock_id={0}", kdock_id);
			return str.ToString();
		}

		public static string DestroyItem (params int[] slotitem_ids) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_slotitem_ids={0}&", string.Join(",", slotitem_ids));
			str.Append("api_token={0}");
			return str.ToString();
		}

		public static string CreateShip (int fuel, int ammo, int steel, int baux, int kdock_id, int item5 = 1, int highspeed = 0, int large_flag = 0) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_item1={0}&", fuel);
			str.AppendFormat("api_item2={0}&", ammo);
			str.AppendFormat("api_item3={0}&", steel);
			str.AppendFormat("api_item4={0}&", baux);
			str.AppendFormat("api_ietm5={0}&", item5);
			str.AppendFormat("api_kdock_id={0}&", kdock_id);
			str.AppendFormat("api_large_flag={0}&", large_flag);
			str.AppendFormat("api_highspeed={0}&", highspeed);
			str.Append("api_token={0}&");
			str.AppendFormat("api_verno={0}&", 1);
			return str.ToString();
		}

		public static string GetDestroyShip (int ship_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_ship_id={0}", ship_id);
			return str.ToString();
		}
	}

	public class GetShip {
		public int api_id { get; set; }
		public int api_ship_id { get; set; }
		public KDock[] api_kdock { get; set; }
		public KanColle.Member.Ship api_ship { get; set; }
		public Slotitem[] api_slotitem { get; set; }
	}

	public class Slotitem {
		public int api_id { get; set; }
		public int api_slotitem_id { get; set; }
	}

	public class KDock {
		public int api_member_id { get; set; }
		public int api_id { get; set; }
		public int api_state { get; set; }
		public int api_created_ship_id { get; set; }
		public int api_complete_time { get; set; }
		public string api_complete_time_str { get; set; }
		public int api_item1 { get; set; }
		public int api_item2 { get; set; }
		public int api_item3 { get; set; }
		public int api_item4 { get; set; }
		public int api_item5 { get; set; }
	}

	public class DestroyItem {
		public int[] api_get_material { get; set; }
	}

	public class DestroyShip {
		public int[] api_material { get; set; }
	}
}
