using System.Text;

namespace KanColle.Request.Kaisou {
	public class Kaisou {
		public static string UNSETSLOT_ALL = "api_req_kaisou/unsetslot_all/";
		public static string SLOTSET = "api_req_kaisou/slotset/";
		public static string REMODELING = "api_req_kaisou/remodeling/";

		public static string UnsetSlotAll (int ship_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_id={0}", ship_id);
			return str.ToString();
		}

		public static string Slotset (int ship_id, int item_id, int slot_position) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_item_id={0}&", item_id);
			str.Append("api_token={0}&");
			str.AppendFormat("api_id={0}&", ship_id);
			str.AppendFormat("api_slot_idx={0}", slot_position);
			return str.ToString();
		}

		public static string Remodeling (int ship_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_id={0}&", ship_id);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}");
			return str.ToString();
		}
	}
}
