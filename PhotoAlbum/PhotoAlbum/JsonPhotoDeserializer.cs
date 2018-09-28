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

        /// <summary>
        /// Parses JsonURL into Photo objects.
        /// </summary>
        /// <returns>List of deserialized JSON Photo objects.</returns>
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

        /// <summary>
        /// Takes JSON from web using JsonURL and converts to string.
        /// </summary>
        /// <returns>String of JSON data.</returns>
        private string jsonURLToString()
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
