using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColle.Member {
	public class Practice {
		public int api_member_id { get; set; }
		public int api_id { get; set; }
		public int api_enemy_id { get; set; }
		public string api_enemy_name { get; set; }
		public string api_enemy_name_id { get; set; }
		public int api_enemy_level { get; set; }
		public string api_enemy_rank { get; set; }
		public int api_enemy_flag { get; set; }
		public int api_enemy_flag_ship { get; set; }
		public string api_enemy_comment { get; set; }
		public string api_enemy_comment_id { get; set; }
		public int api_state { get; set; }
		public int api_medals { get; set; }

		public static string PRACTICE = "api_get_member/practice/";
	}
}
