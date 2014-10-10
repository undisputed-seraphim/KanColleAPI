using System;
using System.Text;

namespace KanColle {
    public class ApiPort {

		/*
		 * Old arrays of values kept for reference.
		 */
//		private static int RADIX = 31;
//		private static string[] LOCAL_3 = { "244", "bjc", "6jj", "4rl", "8qa", "64q", "38a", "9ir", "7h1", "929", "118" };
//		private static long[] SF = { 1802, 9814, 5616, 4168, 7492, 5188, 2765, 8118, 6381, 7636 };
//		private static long[] array = { 1623, 5727, 9278, 3527, 4976, 7180734, 6632, 3708, 4796, 9675, 13, 6631, 2987, 10, 1901, 9881, 1000, 3527 };
//		private static long[] array = { 7536, 1882, 2237, 7280, 5686, 7180734, 6632, 1671, 4819, 1353, 13, 8422, 2987, 10, 1601, 6266, 1000, 3640 };
//		private static long[] array = { 3791, 8897, 8024, 2139, 8567, 7180734, 6096, 3998, 3086, 4767, 13, 1445, 4179, 10, 7927, 8861, 1000, 8059 };
//		private static long[] array = { 5309, 1153, 4306, 2139, 7464, 6510939, 8897, 8629, 9219, 7279, 13, 1219, 3791, 10, 4137, 7064, 1000, 2518707 };
//		private static long[] array = { 6170, 5086, 7404, 2139, 3658, 6510939, 8897, 1997, 6321, 9417, 13, 7819, 3791, 10, 9194, 3978, 1000, 2518707 };
//		private static long[] array = { 7032, 5046, 9693, 2139, 8206, 6510939, 8897, 2065, 6433, 3688, 13, 4766, 3791, 10, 4391, 9752, 1000, 2518707 };
//		private static long[] array = { 6180, 7415, 8024, 2139, 4055, 6510939, 8897, 1725, 3464, 9259, 13, 6524, 3791, 10, 5272, 6433, 1000, 2518707 };
//		private static long[] array = { 3730, 5213, 6130, 2139, 7927, 6510939, 8897, 7258, 3059, 3778, 13, 1785, 3791, 10, 2563, 1528, 1000, 2518707 };
		private static long[] array = { 5740, 6906, 7533, 2139, 1567, 6510939, 8897, 6833, 6154, 6682, 13, 4528, 3791, 10, 5610, 8860, 1000, 2518707 };

		public static string PORT = "api_port/port/";

		public static string port (int memberID) {
			return port(memberID.ToString());
		}

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

		private static long millisSinceUnixEpoch (int year, int month, int day, int hour, int minute, int second) {
			DateTime custom_date = new DateTime(year, month, day, hour, minute, second);
			return (long) (custom_date - new DateTime(1970, 1, 1)).TotalMilliseconds;
		}

		/**
		 * Current version of the algorithm.
		 */
		private static string api_port (string args) {
			int member_id = int.Parse(args);
			string api_port = __((long) member_id);
			//Console.WriteLine("DEBUG API_PORT OUTPUT: " + api_port);
			return api_port;
		}

		private static string __ (long member_id) {

			string part_1 = ((random_floor(9) + 1) * 1000 + (member_id % 1000)).ToString();
			string part_2 = (((array[5] * long.Parse(member_id.ToString().Substring(0, 4))) - (time_floor() + member_id) + array[17]) * array[func(member_id % 10)]).ToString();
			string part_3 = (random_floor(9 * (int) array[16]) + array[16]).ToString();

			return string.Join("", part_1, part_2, part_3);
		}

		private static int func (long input) {
			string sqrt13 = Math.Sqrt(array[array[13]]).ToString(); // 3.605551275463989

			//Original function pseudocode:
			// int counter = 0;
			// While (input != (convert to integer from string) -> sqrt13.substring(counter, 1)) {
			//		counter++;
			// }
			// return counter;
			//
			// Because C# runs into errors if you try to parse a period (.) to an integer,
			// I have written this simulation instead. Far easier.

			int[] arr = { 1, 7, 8, 0, 11, 4, 2, 9, 15, 14 };

			return arr[input];
		}

		private static int random_floor (int a) {
			return (int) Math.Floor(new System.Random().NextDouble() * a);
		}

		private static long time_floor () {
			return millisSinceUnixEpoch() / 1000;
		}

		/**
		 * Obsolete version of the algorithm kept for legacy purposes.
		 */
		/*
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
		 * */

		/**
		 * Obsolete version of the algorithm kept for legacy purposes.
		 */
		/*
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
		 * */
    }
}