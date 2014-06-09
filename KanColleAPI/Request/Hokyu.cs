using System.Text;

namespace KanColle.Request {

	public enum ChargeKind {
		FUEL = 1,
		AMMO = 2,
		BOTH = 3
	}

	public class Charge {
		public Ship[] api_ship { get; set; }
		public int[] api_material { get; set; }
		public int api_use_bou { get; set; }

		public static string CHARGE = "api_req_hokyu/charge/";

		public static string Get (string ship_ids, ChargeKind kind = ChargeKind.BOTH) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_id_items={0}&", ship_ids);
			str.AppendFormat("api_onslot={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_kind={0}", (int) kind);
			return str.ToString();
		}
	}

	internal class Ship {
		public int api_id { get; set; }
		public int api_fuel { get; set; }
		public int api_bull { get; set; }
		public int[] api_onslot { get; set; }
	}
}
