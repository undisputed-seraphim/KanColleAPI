﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KanColle {
    public class ApiPort {

		private static int RADIX = 31;
		private static string[] LOCAL_3 = { "244", "bjc", "6jj", "4rl", "8qa", "64q", "38a", "9ir", "7h1", "929", "118" };
		private static long[] SF = { 1802, 9814, 5616, 4168, 7492, 5188, 2765, 8118, 6381, 7636 };
		private static long[] array = { 1623, 5727, 9278, 3527, 4976, 7180734, 6632, 3708, 4796, 9675, 13, 6631, 2987, 10, 1901, 9881, 1000, 3527 };
		public static string PORT = "api_port/port/";

		public static string port (string memberId) {
			long userIdStr = long.Parse(memberId);

			StringBuilder str = new StringBuilder();
			str.AppendFormat("spi_sort_order={0}&", 2);
			str.AppendFormat("api_verno={0}&", 1);
			str.Append("api_token={0}&");
			str.AppendFormat("api_port={0}&", api_port(memberId));
			str.AppendFormat("api_sort_key={0}", 5);
			return str.ToString();
		}

		// Generates a unix epoch time in milliseconds.
		private static long millisSinceUnixEpoch () {
			return (long) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
		}

		/**
		 * Current version of the algorithm.
		 */
		private static string api_port (string args) {
			int member_id = int.Parse(args);
			string api_port = __((long) member_id);
			Console.WriteLine("DEBUG API_PORT OUTPUT: " + api_port);
			return api_port;
		}

		private static string __ (long member_id) {

			string part_1 = ((random_floor(9) + 1) * 1000 + (member_id % 1000)).ToString();
			string part_2 = (((array[5] * long.Parse(member_id.ToString().Substring(0, 4))) - (time_floor() + member_id)) * array[2]).ToString();
			string part_3 = (random_floor(9000) + 1000).ToString();

			// Debug
			Console.WriteLine(part_1);
			Console.WriteLine(part_2);
			Console.WriteLine(part_3);

			return string.Join("", part_1, part_2, part_3);
		}

		private static int func (int input) {
			int temp = 0;
			string query = Math.Sqrt(13).ToString();
			try {
				while (input != int.Parse(query.Substring(temp, 1))) {
					temp++;
				}
			} catch (FormatException e) {
				Console.WriteLine(e);
				Console.WriteLine("DEBUG OUTPUT");
				Console.WriteLine(temp + "\t" + input);
				Console.WriteLine("3.60555127546399".Substring(temp, 1));
				Console.WriteLine("END DEBUG");
			}
			return temp;
		}

		private static int random_floor (int a) {
			return (int) Math.Floor(new System.Random().NextDouble() * a);
		}

		private static long time_floor () {
			return millisSinceUnixEpoch() / 1000;
		}

		/**
		 * Obsolete version of the algorithm.
		 */
		private static string _1 (long userIdStr) {
			long part1 = (cR() * 1000) + (userIdStr % 1000);
			long part2_1 = 9999999999L - (long) Math.Floor((double) millisSinceUnixEpoch() / (double) 1000);
			long part2_2 = (part2_1 - userIdStr) * SF[userIdStr % 10];
			long part3 = cS();

			return part1 + "" + part2_2 + "" + part3;
		}

		private static int cR () {
			double cR = 1 + Math.Floor(new System.Random().NextDouble() * 9);
			return (int) cR;
		}

		private static int cS () {
			double cS = 1000 + Math.Floor(new System.Random().NextDouble() * 8999);
			return (int) cS;
		}

		/**
		 * Obsolete version of the algorithm kept for legacy purposes.
		 */
		private static string _2 (long userIdStr) {
			long part1 = gI(LOCAL_3[10]) + (userIdStr % gI(LOCAL_3[10]));
			long part2 = (9999999999L - (long) Math.Floor((double) millisSinceUnixEpoch() / gI(LOCAL_3[10])) - userIdStr) * gI(LOCAL_3[userIdStr % 10]);
			string part3 = cN() + cN() + cN() + cN();

			return part1 + "" + part2 + "" + part3;
		}

		private static string cN () {
			int cN = (int) Math.Floor(new System.Random().NextDouble() * 10);
			return Convert.ToString(cN);
		}

		private static int gI (string s) {
			return Convert.ToInt32(s, RADIX);
		}
    }
}
