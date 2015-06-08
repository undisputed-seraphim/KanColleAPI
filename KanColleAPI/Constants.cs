﻿/*
 * This is the class that holds all constants to be used within the KanColle assembly.
 * 
 * This file is not mature yet, do not attempt to change other files until this is complete.
 */
namespace KanColle {
	public static class Constants {

		// Headers for KanColleProxy
		public const string HEADER_CONTENT_TYPE = "application/x-www-form-urlencoded";
		public const string HEADER_REFERER = "{0}kcs/mainD2.swf?api_token={1}/[[DYNAMIC]]/1";

		// Firefox.
		public const string HEADER_FIREFOX_USER_AGENT = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
		public const string HEADER_FIREFOX_ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

		// Flash.
		public const string HEADER_FLASH_USER_AGENT = "Shockwave Flash";
		public const string HEADER_FLASH_ACCEPT = "text/xml, application/xml, application/xhtml+xml, text/html;q=0.9, text/plain;q=0.8, text/css, image/png, image/jpeg, image/gif;q=0.8, application/x-shockwave-flash, video/mp4;q=0.9, flv-application/octet-stream;q=0.8, video/x-flv;q=0.7, audio/mp4, application/futuresplash, */*;q=0.5, application/x-mpegURL";

		// Chrome.
		public const string HEADER_CHROME_USER_AGENT = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36";
		public const string HEADER_CHROME_ACCEPT = "*/*";

		// GET parameters
		public static string DEFAULT_GET { get { return "api_token={0}&api_verno=1"; } }
	}
}