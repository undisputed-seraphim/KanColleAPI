using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace KanColle.Member {
	public class UnsetSlotWrapper {
		public int api_result { get; set; }
		public string api_result_msg { get; set; }
		public UnsetSlot api_data { get; set; }
	}

	public class UnsetSlot {
		public List<int> api_slottype1 { get; set; }
		public List<int> api_slottype2 { get; set; }
		public List<int> api_slottype3 { get; set; }
		public List<int> api_slottype4 { get; set; }
		public List<int> api_slottype5 { get; set; }
		public List<int> api_slottype6 { get; set; }
		public List<int> api_slottype7 { get; set; }
		public List<int> api_slottype8 { get; set; }
		public List<int> api_slottype9 { get; set; }
		public List<int> api_slottype10 { get; set; }
		public List<int> api_slottype11 { get; set; }
		public List<int> api_slottype12 { get; set; }
		public List<int> api_slottype13 { get; set; }
		public List<int> api_slottype14 { get; set; }
		public List<int> api_slottype15 { get; set; }
		public List<int> api_slottype16 { get; set; }
		public List<int> api_slottype17 { get; set; }
		public List<int> api_slottype18 { get; set; }
		public List<int> api_slottype19 { get; set; }
		public List<int> api_slottype20 { get; set; }
		public List<int> api_slottype21 { get; set; }
		public List<int> api_slottype22 { get; set; }
		public List<int> api_slottype23 { get; set; }
		public List<int> api_slottype24 { get; set; }
		public List<int> api_slottype25 { get; set; }
		public List<int> api_slottype26 { get; set; }
		public List<int> api_slottype27 { get; set; }
		public List<int> api_slottype28 { get; set; }
		public List<int> api_slottype29 { get; set; }
		public List<int> api_slottype30 { get; set; }
		public List<int> api_slottype31 { get; set; }

		public static string UNSETSLOT = "api_get_member/unsetslot/";

		public static UnsetSlot ParseUnsetSlot (string input) {
			return JsonConvert.DeserializeObject<UnsetSlot>(input, new UnsetSlotConverter());
		}
	}

	public class UnsetSlotConverter :JsonConverter {
		public override bool CanConvert (Type objectType) {
			return (objectType == typeof(List<int>));
		}

		public override Object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			JToken token = JToken.Load(reader);
			if (token.Type == JTokenType.Object) {
				return token.ToObject<List<int>>();
			}
			return new List<int>();
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
			throw new NotImplementedException();
		}
	}
}
