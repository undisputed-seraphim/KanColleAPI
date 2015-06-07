
namespace KanColle.Member {

	public class Port {
		public Material[] api_material { get; set; }
		public Deck[] api_deck_port { get; set; }
		public NDock[] api_ndock { get; set; }
		public Ship[] api_ship { get; set; }
		public Basic api_basic { get; set; }
		public ActionLog[] api_log { get; set; }
		public int api_p_bgm_id { get; set; }
		public int api_parallel_quest_count { get; set; }
		public int? api_combined_flag { get; set; }

		public static string PORT = "api_port/port/";

		public string GetFleetList (int fleet_num) {
			return this.api_deck_port[fleet_num - 1].GetShipList(true);
		}
	}
}