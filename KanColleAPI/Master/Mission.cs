using System;

namespace KanColle.Master {
	public class Mission : Iidentifiable {
		public int api_id { get; set; }
		public int api_maparea_id { get; set; }
		public string api_name { get; set; }
		public string api_details { get; set; }
		public int api_time { get; set; }		// In minutes
		public int api_difficulty { get; set; }
		public float api_use_fuel { get; set; }
		public float api_use_bull { get; set; }
		public int[] api_win_item1 { get; set; }
		public int[] api_win_item2 { get; set; }
		public int api_return_flag { get; set; }
		
		public override string ToString() {
			TimeSpan span = TimeSpan.FromMinutes(api_time);
			string length = span.ToString(@"hh\:mm");
			return string.Format("{0}. {1} {2}", api_id, length, api_name);
		}
	}
}
