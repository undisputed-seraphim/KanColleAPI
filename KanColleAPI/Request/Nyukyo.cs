using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColle.Request.Nyukyo {

	public class Nyukyo {
		public static string START = "api_req_nyukyo/start/";

		public static string Start (int ship_id, int ndock_id, int highspeed = 0) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_verno={0}&", 1);
			str.AppendFormat("api_ndock_id&", ndock_id);
			str.Append("api_token={0}&");
			str.AppendFormat("api_highspeed={0}&", highspeed);
			str.AppendFormat("api_ship_id={0}", ship_id);
			return str.ToString();
		}
	}
}
