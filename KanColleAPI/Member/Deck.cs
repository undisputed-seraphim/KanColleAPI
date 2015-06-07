namespace KanColle.Member {

	public class Deck : IIdentifable, INameable {
		public int api_member_id { get; set; }
		public int api_id { get; set; }
		public string api_name { get; set; }
		public string api_name_id { get; set; }
		public long[] api_mission { get; set; }
		public string api_flagship { get; set; }
		public int[] api_ship { get; set; }

		public static string GET = "api_get_member/deck/";

		public string GetShipList(bool SkipEmptyPositions) {
			if (SkipEmptyPositions) {
				return string.Join(",", this.api_ship).Replace(",-1", "");
			} else {
				return string.Join(",", this.api_ship);
			}
		}
	}
}
