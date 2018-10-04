using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace PhotoAlbum
{
    public class JsonPhotoDeserializer
    {
        public string JsonURL { get; set; }

        public List<Photo> DeserializeJson()
        {
            try
            {
                string strJson = JsonURLToString();
                return JsonConvert.DeserializeObject<List<Photo>>(strJson);
            }
            catch(ArgumentNullException nullex) // When no jsonURL is provided.
            {
                throw new ArgumentNullException("Deserializer did not receive valid JSON URL. ", nullex);
            }
        }

        private string JsonURLToString()
        {
            try
            {
                return new WebClient().DownloadString(JsonURL);   // Convert JSON to string.
            }
            catch(WebException webex)   // When no internet connection..
            {
                throw new WebException("Must be connected to internet to retrieve JSON data. " + webex);
            }

        }
    }
}
