using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Foundation;

namespace Hommy.Models
{
    class Lamp
    {
        public string Name { get; set; }
        public bool State { get; set; }
        public NSIndexPath Index { get; set; }
    }

    class Radio
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    class Data
    {
        private static volatile Data _instance;
        private static object _syncRoot = new object();
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Data();
                    }
                }

                return _instance;
            }
        }

        private Data()
        {


            Lamps = new List<Lamp>()
            {
                new Lamp() {Name = "Kitchen", State = true},
                new Lamp() {Name = "Bedroom", State = false},
                new Lamp() {Name = "Toilet", State = false}
            };

            Radios = new List<Radio>()
            {
                new Radio() {Name = "Radio 1"},
                new Radio() {Name = "Radio 2"},
                new Radio() {Name = "Radio 3"},
                new Radio() {Name = "Radio 4"}
            };

            Ip = GetIP(_url);
            Console.WriteLine(Ip);
        }

        private const string _url = @"http://api.fushimyshi.com/hommy/ip.txt";
        public string Ip;

        public List<Lamp> Lamps { get; set; }
        public List<Radio> Radios { get; set; }
        

        /*private async Task<JsonValue> FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }*/

        public string GetIP(string url)
        {
            // WebClient is still convenient
            // Assume UTF8, but detect BOM - could also honor response charset I suppose
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
        }
    }
}
