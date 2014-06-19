using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColle.Request {
	public class Hensei {

		public static string RemoveAll (int fleet_id) {
			return Change(-2, -1, fleet_id);
		}

		public static string Change (int ship_id, int fleet_position, int fleet_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_ship_id={0}&", ship_id);
			str.AppendFormat("api_ship_idx={0}&", --fleet_position);
			str.Append("api_token={0}&");
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_id={0}", fleet_id);
			return str.ToString();
		}
	}

	public class Change {
		public int? api_change_count { get; set; }
	}
}
