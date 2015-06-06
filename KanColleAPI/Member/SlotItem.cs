
namespace KanColle.Member {
	public class SlotItem : IIdentifable {
		public int api_id { get; set; }
		public int api_slotitem_id { get; set; }

		public static string SLOTITEM = "api_get_member/slot_item/";

		public int ID() { return this.api_id; }
	}
}
