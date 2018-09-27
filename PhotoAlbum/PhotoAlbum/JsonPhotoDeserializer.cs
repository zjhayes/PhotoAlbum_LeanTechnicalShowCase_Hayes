using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace PhotoAlbum
{
    public class JsonPhotoDeserializer
    {
        public string JsonURL { get; set; }

        public JsonPhotoDeserializer()
        {

        }
        public JsonPhotoDeserializer(string jsonURL)
        {
            JsonURL = jsonURL;
        }

        public List<Photo> deserializeJson()
        {
            try
            {
                string strJson = jsonURLToString();
                // Create list of deserialized JSON photo objects.
                return JsonConvert.DeserializeObject<List<Photo>>(strJson);
            }
            catch(ArgumentNullException nullex) // When no jsonURL is provided.
            {
                throw new ArgumentNullException("Deserializer did not receive valid JSON URL. ", nullex);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string jsonURLToString()
        {
            try
            {
                return new WebClient().DownloadString(JsonURL);   // Convert JSON to string.
            }
            catch(WebException webex)
            {
                throw new WebException("Must be connected to internet to retrieve JSON data. " + webex);
            }

        }
    }
}
