using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColle.Member {
	
	class MapInfo {
		public int api_id { get; set; }
		public int api_cleared { get; set; }
		public int api_exboss_flag { get; set; }
		public int? api_defeat_count { get; set; }

		public static string GET = "api_get_member/mapinfo/";
	}
}
