
namespace KanColle.Master {

	public class Furniture : IIdentifable {
		public int api_id { get; set; }
		public int api_type { get; set; }
		public int api_no { get; set; }
		public string api_title { get; set; }
		public string api_description { get; set; }
		public int api_rarity { get; set; }
		public int api_price { get; set; }
		public int api_saleflg { get; set; }
		public int api_season { get; set; }
	}
}
