using System;
using Newtonsoft.Json;

namespace KanColle {
	public class Teitoku {
		private readonly KanColleProxy Proxy;

		public Member.Basic basic { get; private set; }
		public Member.Port Port { get; private set; }
		public Master.Start2 Start2 { get; private set; }

		public string MemberID { get { return this.basic.api_member_id; } private set { } }

		public Teitoku(string input) {
			string[] tokens = input.Split(new string[] { "kcs/mainD2.swf?api_token=" }, StringSplitOptions.None);
			if (tokens.Length != 2)
				throw new KancolleInvalidAPITokenException("This API token is in an invalid format.");
		}

		public Teitoku(string api_token, string server) {
			this.Proxy = new KanColleProxy(api_token, server);

			UpdateBasic();
			UpdatePort();
			// UpdateStart2();
		}

		public void UpdateBasic() {
			string json_response = this.Proxy.proxy(KanColle.Member.Basic.GET);
			KanColleAPI<KanColle.Member.Basic> basic = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Member.Basic>>(json_response);
			this.basic = basic.GetData();
		}

		public void UpdatePort() {
			string member_id = this.basic.api_member_id;
			string json_response = this.Proxy.proxy(ApiPort.PORT, ApiPort.port(member_id));
			KanColleAPI<KanColle.Member.Port> port = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Member.Port>>(json_response);
			this.Port = port.GetData();
		}

		public void UpdateStart2() {
			string json_response = this.Proxy.proxy(KanColle.Master.Start2.GET);
			KanColleAPI<KanColle.Master.Start2> start2 = JsonConvert.DeserializeObject<KanColleAPI<KanColle.Master.Start2>>(json_response);
			this.Start2 = start2.GetData();
		}
	}
}
