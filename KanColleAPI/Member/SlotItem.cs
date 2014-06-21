
namespace KanColle.Member {
	public class SlotItem : Iidentifiable {
		public int api_id { get; set; }
		public int api_slotitem_id { get; set; }

		public static string SLOTITEM = "api_get_member/slot_item/";
	}
}
