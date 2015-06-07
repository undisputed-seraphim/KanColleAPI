using System;

namespace KanColle.Master {

	public class Start2 {
		public Ship[] api_mst_ship { get; set; }
		public ShipGraph[] api_mst_shipgraph { get; set; }
		public SlotItemType[] api_mst_slotitem_equiptype { get; set; }
		public ShipType[] api_mst_shiptype { get; set; }
		public SlotItem[] api_mst_slotitem { get; set; }
		public SlotItemGraph[] api_mst_slotitemgraph { get; set; }
		public Furniture[] api_mst_furniture { get; set; }
		public FurnitureGraph[] api_mst_furnituregraph { get; set; }
		public UseItem[] api_mst_useitem { get; set; }
		public PayItem[] api_mst_payitem { get; set; }
		public ItemShop api_mst_item_shop { get; set; }
		public MapArea[] api_mst_maparea { get; set; }
		public MapInfo[] api_mst_mapinfo { get; set; }
		public MapBgm[] api_mst_mapbgm { get; set; }
		public MapCell[] api_mst_mapcell { get; set; }
		public Mission[] api_mst_mission { get; set; }
		public MstConst api_mst_const { get; set; }
		public ShipUpgrade[] api_mst_shipupgrade { get; set; }
		public BGM[] api_mst_bgm { get; set; }

		public static string GET = "api_start2/";
	}
}