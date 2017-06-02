using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.IO;

public class Screenshotscloud
{
	public string screenshotscloudApiKey;
	public string screenshotscloudApiSecret;

	public Screenshotscloud(string apiKey, string apiSecret) {
		screenshotscloudApiKey = apiKey;
        screenshotscloudApiSecret = apiSecret;
	}

    public string screenshotUrl(Dictionary<string, string> options) {
        string parameters = parameterString(options);

        return string.Format("https://api.screenshots.cloud/v1/screenshot/{0}/{1}/?{2}", this.screenshotscloudApiKey, calculateRFC2104HMAC(parameters, this.screenshotscloudApiSecret), parameters);
    }

	public static string parameterString(Dictionary<string, string> options) {
        string results = "";

		foreach(KeyValuePair<string, string> option in options)
        {
			results += string.Format(results == ""?"{0}={1}":"&{0}={1}", option.Key, WebUtility.UrlEncode(option.Value));
        }

        return results;
    }

	public static string calculateRFC2104HMAC(string data, string key) {
        HMACSHA1 sha = new HMACSHA1(Encoding.ASCII.GetBytes(key));
        MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(data));
        return sha.ComputeHash(stream).Aggregate("", (current, next) => current + String.Format("{0:x2}", next), current => current);
    }
}
