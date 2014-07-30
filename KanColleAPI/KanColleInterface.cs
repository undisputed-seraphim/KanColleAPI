using System;

namespace KanColle {
	public class KanColleAPI<T> {
		public int api_result { get; set; }
		public string api_result_msg { get; set; }
		public T api_data { get; set; }

		public T GetData () {
			switch (this.api_result) {
				default:
				case 1:
					return this.api_data;
				case 100:
				case 101:
					string e = string.Format(KancolleInvalidRequestException.DEFAULT_MESSAGE, this.api_result);
					throw new KancolleInvalidRequestException(e + "\n" + this.api_result_msg);
				case 200:
				case 201:
					string f = string.Format(KancolleInvalidAPITokenException.DEFAULT_MESSAGE, this.api_result);
					throw new KancolleInvalidAPITokenException(f + "\n" + this.api_result_msg);
			}
		}
	}

	interface Iidentifiable {
		int api_id { get; set; }
	}

	public class KancolleInvalidAPITokenException :Exception {
		public static string DEFAULT_MESSAGE = "{0}: The API token appears to be invalid or malformed.";

		public KancolleInvalidAPITokenException () : base(DEFAULT_MESSAGE) { }
		public KancolleInvalidAPITokenException (string message) : base(message) { }
		public KancolleInvalidAPITokenException (string message, Exception inner) : base(message, inner) { }
	}

	public class KancolleInvalidRequestException :Exception {
		public static string DEFAULT_MESSAGE = "{0}: The request sent to the server appears to be invalid, or was rejected.";

		public KancolleInvalidRequestException () : base(DEFAULT_MESSAGE) { }
		public KancolleInvalidRequestException (string message) : base(message) { }
		public KancolleInvalidRequestException (string message, Exception inner) : base(message, inner) { }
	}
}
