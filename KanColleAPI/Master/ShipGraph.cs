namespace KanColle.Master {

	public class ShipGraph : IIdentifable {
		public int api_id { get; set; }
		public int api_sortno { get; set; }
		public string api_filename { get; set; }
		public string api_version { get; set; }
		public int[] api_boko_n { get; set; }
		public int[] api_boko_d { get; set; }
		public int[] api_kaisyu_n { get; set; }
		public int[] api_kaisyu_d { get; set; }
		public int[] api_kaizo_n { get; set; }
		public int[] api_kaizo_d { get; set; }
		public int[] api_map_n { get; set; }
		public int[] api_map_d { get; set; }
		public int[] api_ensyuf_n { get; set; }
		public int[] api_ensyuf_d { get; set; }
		public int[] api_ensyue_n { get; set; }
		public int[] api_battle_n { get; set; }
		public int[] api_battle_d { get; set; }
		public int[] api_weda { get; set; }
		public int[] api_wedb { get; set; }
	}
}
