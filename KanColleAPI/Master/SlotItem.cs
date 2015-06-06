﻿
namespace KanColle.Master {
	public class SlotItem : IIdentifable, INameable {
		public int api_id { get; set; }
		public int api_sortno { get; set; }
		public string api_name { get; set; }
		public int[] api_type { get; set; }
		public int api_taik { get; set; }
		public int api_souk { get; set; }
		public int api_houg { get; set; }
		public int api_raig { get; set; }
		public int api_soku { get; set; }
		public int api_baku { get; set; }
		public int api_tyku { get; set; }
		public int api_tais { get; set; }
		public int api_atap { get; set; }
		public int api_houm { get; set; }
		public int api_raim { get; set; }
		public int api_houk { get; set; }
		public int api_raik { get; set; }
		public int api_bakk { get; set; }
		public int api_saku { get; set; }
		public int api_sakb { get; set; }
		public int api_luck { get; set; }
		public int api_leng { get; set; }
		public int api_rare { get; set; }
		public int[] api_broken { get; set; }
		public string api_info { get; set; }
		public string api_usebull { get; set; }

		public int ID() { return this.api_id; }
		public string Name() { return this.api_name; }
	}

	public class SlotItemType : IIdentifable, INameable {
		public int api_id { get; set; }
		public string api_name { get; set; }
		public int api_show_flag { get; set; }

		public int ID() { return this.api_id; }
		public string Name() { return this.api_name; }
	}

	public class SlotItemGraph : IIdentifable {
		public int api_id { get; set; }
		public int api_sortno { get; set; }
		public string api_filename { get; set; }
		public string api_version { get; set; }

		public int ID() { return this.api_id; }
	}
}
