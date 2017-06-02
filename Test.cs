using System;
using System.Collections.Generic;

public class Test
{
	static void Main()
    {
		String apiKey = "testkey";
		String apiSecret = "testsecret";

		Screenshotscloud screenshotscloud = new Screenshotscloud(apiKey, apiSecret);

		Dictionary<string, string> options = new Dictionary<string, string>();
		options.Add("url", "bbc.com/news");
		options.Add("width", "800");

		string result = screenshotscloud.screenshotUrl(options);
        System.Console.WriteLine(result);
    }
}
