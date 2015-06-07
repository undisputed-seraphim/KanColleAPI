namespace KanColle.Master {

	public class SlotItemType : IIdentifable, INameable {
		public int api_id { get; set; }
		public string api_name { get; set; }
		public int api_show_flag { get; set; }
	}
}
