

namespace KanColle.Master {

	public class MstConst {
		public DpFlagQuest api_dpflag_quest { get; set; }
		public BokoMaxShips api_boko_max_ships { get; set; }
		public ParallelQuestMax api_parallel_quest_max { get; set; }
	}

	public class DpFlagQuest {
		public string api_string_value { get; set; }
		public int api_int_value { get; set; }
	}

	public class BokoMaxShips {
		public string api_string_value { get; set; }
		public int api_int_value { get; set; }
	}

	public class ParallelQuestMax {
		public string api_string_value { get; set; }
		public int api_int_value { get; set; }
	}
}
