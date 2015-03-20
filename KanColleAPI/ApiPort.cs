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
//		private static long[] array = { 5740, 6906, 7533, 2139, 1567, 6510939, 8897, 6833, 6154, 6682, 13, 4528, 3791, 10, 5610, 8860, 1000, 2518707 };
//		private static long[] array = { 6515, 4294, 3631, 2139, 5138, 6510939, 8897, 5306, 5932, 4202, 13, 1923, 3791, 10, 6741, 3189, 1000, 2518707 };
//		private static long[] array = { 7158, 2731, 6840, 2139, 4285, 6510939, 8897, 2985, 4223, 2465, 13, 3617, 3791, 10, 2522, 4135, 1000, 2518707 };
//		private static long[] array = { 3398, 2613, 4165, 2139, 9662, 6510939, 8897, 1512, 8024, 9389, 13, 4901, 3791, 10, 1161, 8465, 1000, 2518707 };
//		private static long[] array = { 3599, 5795, 2992, 2139, 2689, 6510939, 8897, 1832, 5794, 6622, 13, 7783, 3791, 10, 9853, 2440, 1000, 2518707 };
//		private static long[] array = { 9514, 8207, 4082, 2139, 8501, 6510939, 8897, 1465, 4355, 2499, 13, 6558, 3791, 10, 6556, 3026, 1000, 2518707 };
//      private static long[] array = { 5888, 7810, 3901, 2139, 8413, 4131807, 8897, 5444, 9683, 7159, 13, 4810, 3791, 10, 5342, 2211, 1000, 1876153 };
//      private static long[] array = { 8238, 4537, 3282, 2139, 5781, 4131807, 8897, 4739, 9122, 9516, 13, 7330, 3791, 10, 8455, 2727, 1000, 1876153 };
//      private static long[] array = { 2867, 6569, 2722, 2139, 3681, 4131807, 8897, 6193, 8277, 9888, 13, 6798, 3791, 10, 8955, 3339, 1000, 1876153 };
//		private static long[] array = { 3101, 7566, 5167, 2139, 9031, 4131807, 8897, 9973, 4140, 6130, 13, 8957, 3791, 10, 6321, 8845, 1000, 1876153 };
		private static long[] array = { 9463, 8462, 9655, 2139, 6496, 4131807, 8897, 3346, 6042, 7926, 13, 8921, 3791, 10, 2846, 8330, 1000, 1876153 };

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

            string part_0 = (random_floor(32768) + 32768).ToString();

			string part_1 = ((random_floor(9) + 1) * 1000 + (member_id % 1000)).ToString();
			//string part_2 = (((array[5] * long.Parse(member_id.ToString().Substring(0, 4))) - (time_floor() + member_id) + array[17]) * array[func(member_id % 10)]).ToString();
            string part_2 = ((((long.Parse(member_id.ToString().Substring(0, 4)) + 1000) * (array[5] + long.Parse(part_0)) - time_floor()) + (array[17] + (9 * long.Parse(part_0))) - member_id) * array[func(member_id % 10)]).ToString();
            string part_3 = (random_floor(9 * (int) array[16]) + array[16]).ToString();

			return string.Join("", part_1, part_2, part_3, part_0);
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
    }
}