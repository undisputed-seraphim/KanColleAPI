
namespace KanColle.Master {

	public class MapArea : Iidentifiable {
		public int api_id { get; set; }
		public string api_name { get; set; }
		public int api_type { get; set; }
	}

	public class MapInfo : Iidentifiable {
		public int api_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_no { get; set; }
		public string api_name { get; set; }
		public int api_level { get; set; }
		public string api_opetext { get; set; }
		public string api_infotext { get; set; }
		public int[] api_item { get; set; }
		public int api_max_maphp { get; set; }
		public int api_required_defeat_count { get; set; }
	}

	public class MapBgm : Iidentifiable {
		public int api_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_no { get; set; }
		public int[] api_map_bgm { get; set; }
		public int[] api_boss_bgm { get; set; }
	}

	public class MapCell {
		public int api_map_no { get; set; }
		public int api_maparea_id { get; set; }
		public int api_mapinfo_no { get; set; }
		public int api_id { get; set; }
		public int api_no { get; set; }
		public int api_color_no { get; set; }
	}
}
