
namespace KanColle.Master {

	// An enum of all maps in kancolle.
	public sealed class Map {
		private readonly int stage;
		private readonly int map;
		private readonly string name_jpn;

		public static readonly Map _1_1 = new Map(1, 1, "鎮守府正面海域");
		public static readonly Map _1_2 = new Map(1, 2, "南西諸島沖");
		public static readonly Map _1_3 = new Map(1, 3, "製油所地帯沿岸");
		public static readonly Map _1_4 = new Map(1, 4, "南西諸島防衛線");
		public static readonly Map _1_5 = new Map(1, 5, "鎮守府近海");
		public static readonly Map _2_1 = new Map(2, 1, "カムラン半島");
		public static readonly Map _2_2 = new Map(2, 2, "バシー島沖");
		public static readonly Map _2_3 = new Map(2, 3, "東部オリョール海");
		public static readonly Map _2_4 = new Map(2, 4, "沖ノ島海域");
		public static readonly Map _2_5 = new Map(2, 5, "沖ノ島沖");
		public static readonly Map _3_1 = new Map(3, 1, "モーレイ海");
		public static readonly Map _3_2 = new Map(3, 2, "キス島沖");
		public static readonly Map _3_3 = new Map(3, 3, "アルフォンシーノ方面");
		public static readonly Map _3_4 = new Map(3, 4, "北方海域全域");
		public static readonly Map _4_1 = new Map(4, 1, "ジャム島攻略作戦");
		public static readonly Map _4_2 = new Map(4, 2, "カレー洋制圧戦");
		public static readonly Map _4_3 = new Map(4, 3, "リランカ島空襲");
		public static readonly Map _4_4 = new Map(4, 4, "カスガダマ沖海戦");
		public static readonly Map _5_1 = new Map(5, 1, "南方海域前面");
		public static readonly Map _5_2 = new Map(5, 2, "珊瑚諸島沖");
		public static readonly Map _5_3 = new Map(5, 3, "サブ島沖海域");
		public static readonly Map _5_4 = new Map(5, 4, "サーモン海域");
		public static readonly Map _5_5 = new Map(5, 5, "サーモン海域北方");

		private Map (int stage, int map, string name_jpn) {
			this.stage = stage;
			this.map = map;
			this.name_jpn = name_jpn;
		}

		public override string ToString () {
			return this.name_jpn;
		}
	}

	public class MapArea : Iidentifiable {
		public int api_id { get; set; }
		public string api_name { get; set; }
		public int api_type { get; set; }

		public override string ToString () {
			return string.Format("{0}\t{1}\t{2}", api_id, api_type, api_name);
		}
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
		public int? api_max_maphp { get; set; }
		public int? api_required_defeat_count { get; set; }

		public override string ToString () {
			return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", api_id, api_maparea_id, api_no, api_name, api_max_maphp, api_required_defeat_count);
		}
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

	/*
	public enum EventMaps {
		前哨戦,
		警戒線突破,
		警戒線突破,
		湾内突入,
		敵泊地強襲,
		限定第1海域,
		限定第2海域,
		限定第3海域,
		限定第4海域,
		サーモン諸島海域,
		ルンバ沖海域,
		サンタクロース諸島海域,
		アイアンボトムサウンド,
		サーモン海域最深部,
		観音崎沖,
		硫黄島周辺海域,
		中部太平洋海域,
		南西海域サメワニ沖,
		南西海域ズンダ海峡,
		ポートワイン沖海域,
		中部太平洋海域,
		北太平洋海域
	}*/

}
