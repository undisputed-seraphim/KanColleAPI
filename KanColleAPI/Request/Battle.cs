using System.Collections.Generic;
using System.Text;

namespace KanColle.Request {

	public class Battle {
		public int api_dock_id { get; set; }
		public List<int> api_ship_ke { get; set; }
		public List<int> api_ship_lv { get; set; }
		public List<int> api_nowhps { get; set; }
		public List<int> api_maxhps { get; set; }
		public int api_midnight_flag { get; set; }
		public List<List<int>> api_eSlot { get; set; }
		public List<List<int>> api_eKyouka { get; set; }
		public List<List<int>> api_fParam { get; set; }
		public List<List<int>> api_eParam { get; set; }
		public List<int> api_search { get; set; }
		public List<int> api_formation { get; set; }
		public List<int> api_stage_flag { get; set; }
		public ApiKouku api_kouku { get; set; }
		public int api_support_flag { get; set; }
		public object api_support_info { get; set; }
		public int api_opening_flag { get; set; }
		public object api_opening_atack { get; set; }
		public List<int> api_hourai_flag { get; set; }
		public object api_hougeki1 { get; set; }
		public object api_hougeki2 { get; set; }
		public object api_hougeki3 { get; set; }
		public object api_raigeki { get; set; }

		public static string BATTLE = "api_req_sortie/battle";

		public static string Get (int formation, int recovery_type) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_formation={0}&", formation);
			str.Append("api_token={0}&");
			str.AppendFormat("api_recovery_type={0}&", recovery_type);
			str.AppendFormat("api_verno={0}", 1);
			return str.ToString();
		}
	}

	public class ApiStage1 {
		public int api_f_count { get; set; }
		public int api_f_lostcount { get; set; }
		public int api_e_count { get; set; }
		public int api_e_lostcount { get; set; }
		public int api_disp_seiku { get; set; }
		public List<int> api_touch_plane { get; set; }
	}

	public class ApiStage2 {
		public int api_f_count { get; set; }
		public int api_f_lostcount { get; set; }
		public int api_e_count { get; set; }
		public int api_e_lostcount { get; set; }
	}

	public class ApiStage3 {
		public List<int> api_frai_flag { get; set; }
		public List<int> api_erai_flag { get; set; }
		public List<int> api_fbak_flag { get; set; }
		public List<int> api_ebak_flag { get; set; }
		public List<int> api_fcl_flag { get; set; }
		public List<int> api_ecl_flag { get; set; }
		public List<int> api_fdam { get; set; }
		public List<int> api_edam { get; set; }
	}

	public class ApiKouku {
		public List<List<int>> api_plane_from { get; set; }
		public ApiStage1 api_stage1 { get; set; }
		public ApiStage2 api_stage2 { get; set; }
		public ApiStage3 api_stage3 { get; set; }
	}

	public class BattleResult {
		public List<int> api_ship_id { get; set; }
		public string api_win_rank { get; set; }
		public int api_get_exp { get; set; }
		public int api_mvp { get; set; }
		public int api_member_lv { get; set; }
		public int api_member_exp { get; set; }
		public int api_get_base_exp { get; set; }
		public List<int> api_get_ship_exp { get; set; }
		public List<List<int>> api_get_exp_lvup { get; set; }
		public int api_dests { get; set; }
		public int api_destsf { get; set; }
		public List<int> api_lost_flag { get; set; }
		public string api_quest_name { get; set; }
		public int api_quest_level { get; set; }
		public ApiEnemyInfo api_enemy_info { get; set; }
		public int api_first_clear { get; set; }
		public List<int> api_get_flag { get; set; }
		public ApiGetShip api_get_ship { get; set; }
		public int api_get_eventflag { get; set; }
		public int api_get_exmap_rate { get; set; }
		public int api_get_exmap_useitem_id { get; set; }

		public static string BATTLERESULT = "api_req_sortie/battleresult";
	}

	public class ApiEnemyInfo {
		public string api_level { get; set; }
		public string api_rank { get; set; }
		public string api_deck_name { get; set; }
	}

	public class ApiGetShip {
		public int api_ship_id { get; set; }
		public string api_ship_type { get; set; }
		public string api_ship_name { get; set; }
		public string api_ship_getmes { get; set; }
	}
}
