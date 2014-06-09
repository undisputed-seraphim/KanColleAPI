using System.Text;

namespace KanColle.Request {
	public class Map {
		public static string START = "api_req_map/start/";
		public static string NEXT = "api_req_map/next/";

		public static string Start (int mapinfo_no, int deck_id, int maparea_id, int formation_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_mapinfo_no={0}&", mapinfo_no);
			str.AppendFormat("api_deck_id={0}&", deck_id);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_maparea_id={0}&", maparea_id);
			str.AppendFormat("api_formation_id={0}", formation_id);
			return str.ToString();
		}

		public static string Next (int recovery_type) {
			StringBuilder str = new StringBuilder();
			str.Append("api_token={0}&");
			str.AppendFormat("api_recovery_type={0}&", recovery_type);
			str.AppendFormat("api_verno={0}", 1);
			return str.ToString();
		}
	}

	public enum Maps {
		鎮守府正面海域,
		南西諸島沖,
		製油所地帯沿岸,
		南西諸島防衛線,
		鎮守府近海,
		カムラン半島,
		バシー島沖,
		東部オリョール海,
		沖ノ島海域,
		沖ノ島沖,
		モーレイ海,
		キス島沖,
		アルフォンシーノ方面,
		北方海域全域,
		ジャム島攻略作戦,
		カレー洋制圧戦,
		リランカ島空襲,
		カスガダマ沖海戦,
		南方海域前面,
		珊瑚諸島沖,
		サブ島沖海域,
		サーモン海域,
		サーモン海域北方
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

	public class Start {
		public int api_rashin_flg { get; set; }
		public int api_rashin_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_mapinfo_no { get; set; }
		public int api_no { get; set; }
		public int api_color_no { get; set; }
		public int api_event_id { get; set; }
		public int api_event_kind { get; set; }
		public int api_next { get; set; }
		public int api_bosscell_no { get; set; }
		public int api_bosscomp { get; set; }
		public Enemy api_enemy { get; set; }
	}

	public class Next {
		public int api_rashin_flg { get; set; }
		public int api_rashin_id { get; set; }
		public int api_maparea_id { get; set; }
		public int api_mapinfo_no { get; set; }
		public int api_no { get; set; }
		public int api_color_no { get; set; }
		public int api_event_id { get; set; }
		public int api_event_kind { get; set; }
		public int api_next { get; set; }
		public int api_bosscell_no { get; set; }
		public int api_bosscomp { get; set; }
		public int api_comment_kind { get; set; }
		public int api_production_kind { get; set; }
		public Enemy api_enemy { get; set; }
	}

	public class Enemy {
		public int api_enemy_id { get; set; }
		public int api_result { get; set; }
		public string api_result_str { get; set; }
	}
}
