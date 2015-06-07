namespace KanColle.Member {

	public class ActionLog {
		public int api_no { get; set; }
		public string api_type { get; set; }
		public string api_state { get; set; }
		public string api_message { get; set; }

		override public string ToString() {
			return string.Format("%d\t%s", this.api_no, this.api_message);
		}
	}
}
