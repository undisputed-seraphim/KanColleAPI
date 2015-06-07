namespace KanColle.Master {

	public class ShipUpgrade : IIdentifable {
		public int api_id { get; set; }
		public int api_original_ship_id { get; set; }
		public int api_upgrade_type { get; set; }
		public int api_upgrade_level { get; set; }
		public int api_drawing_count { get; set; }
		public int api_sortno { get; set; }
	}
}
