﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace KanColle.Request.Mission {
	// TYPESAFE ENUM PATTERN! WOO!
	// http://stackoverflow.com/questions/424366/c-sharp-string-enums
	public sealed class ExpeditionResult {
		private readonly string result;
		private readonly int value;

		public static readonly ExpeditionResult FAIL = new ExpeditionResult("失敗！", 0);
		public static readonly ExpeditionResult SUCCESS = new ExpeditionResult("成功！", 1);
		public static readonly ExpeditionResult GREAT_SUCCESS = new ExpeditionResult("大成功！", 2);

		private ExpeditionResult (string result, int value) {
			this.result = result;
			this.value = value;
		}

		public override string ToString () {
			return this.result;
		}

		/**
		 * Defaults to FAIL.
		 */
		public static ExpeditionResult GetExpeditionResult (int i) {
			i = i % 3;
			switch (i) {
				default: 
				case 0:
					return ExpeditionResult.FAIL;
				case 1:
					return ExpeditionResult.SUCCESS;
				case 2:
					return ExpeditionResult.GREAT_SUCCESS;
			}
		}
	}


	public class Mission {
		public static string START = "api_req_mission/start/";
		public static string RESULT = "api_req_mission/result/";

		public static string Start (int fleet_id, int mission_id, int hash) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_mission_id={0}&", mission_id);
			str.AppendFormat("api_deck_id={0}&", fleet_id);
			str.AppendFormat("api_mission={0}&", hash);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}");
			return str.ToString();
		}

		public static string Result (int fleet_id) {
			StringBuilder str = new StringBuilder();
			str.AppendFormat("api_deck_id={0}&", fleet_id);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}");
			return str.ToString();
		}
	}

	public class MissionStart {
		public long api_complatetime { get; set; }
		public string api_complatetime_str { get; set; }

		public void PrintConsole () {
			string output = string.Format("This expedition will end at {0} GMT +9.", this.api_complatetime_str);
			Console.WriteLine("Mission started!");
			Console.WriteLine(output);
		}
	}

	public class MissionResult {
		public int[] api_ship_id { get; set; }
		public int api_clear_result { get; set; }
		public int api_get_exp { get; set; }
		public int api_member_lv { get; set; }
		public int api_member_exp { get; set; }
		public int[] api_get_ship_exp { get; set; }
		public int[][] api_get_exp_lvup { get; set; }
		public string api_maparea_name { get; set; }
		public string api_detail { get; set; }
		public string api_quest_name { get; set; }
		public int api_quest_level { get; set; }
		public int[] api_get_material { get; set; }
		public int[] api_useitem_flag { get; set; }
		public GetItem api_get_item1 { get; set; }

		public class GetItem {
			public int api_useitem_id { get; set; }
			public String api_useitem_name { get; set; }
			public int api_useitem_count { get; set; }
		}

		public ExpeditionResult GetResult() {
			return ExpeditionResult.GetExpeditionResult(this.api_clear_result);
		}

		public int[] PrintConsole () {
			string clear_result = "MISSION RESULT: {0} {1}";
			switch (this.api_clear_result) {
				default:
				case 0:
					clear_result = string.Format(clear_result, ExpeditionResult.FAIL, ":(");
					break;
				case 1:
					clear_result = string.Format(clear_result, ExpeditionResult.SUCCESS, ":)");
					break;
				case 2:
					clear_result = string.Format(clear_result, ExpeditionResult.GREAT_SUCCESS, ":D");
					break;
			}
			string get_material = string.Format("{0} fuel, {1} ammo, {2} steel, {3} bauxite",
			this.api_get_material[0], this.api_get_material[1], this.api_get_material[2], this.api_get_material[3]);

			Console.WriteLine("MISSION: {0}", this.api_quest_name);
			Console.WriteLine(clear_result);
			Console.WriteLine("You have received: {0}", get_material);
			if (this.api_useitem_flag[0] > 0) {
				Console.WriteLine("You have also received a {0}", this.api_get_item1.api_useitem_name);
			}

			return this.api_get_material;
		}
	}
	/*
	public static class MissionResultConverter :JsonConverter {
		public override bool CanConvert (Type objectType) {
			return (objectType == typeof(int[]));
		}

		public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			JToken token = JToken.Load(reader);
			if (token.Type == JTokenType.Object) {
				return token.ToObject<int[]>();
			}
			return new int[] { -1, -1, -1, -1 };
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
			throw new NotImplementedException();
		}
	}*/	
}
