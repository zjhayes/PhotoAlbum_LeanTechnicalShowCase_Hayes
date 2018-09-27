using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum
{
    public class JsonPhotoDeserializer
    {
        private string jsonURL;

        public JsonPhotoDeserializer(string jsonURL)
        {
            this.jsonURL = jsonURL;
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
                throw new ArgumentNullException("jsonURL cannot be null. ", nullex);
            }
        }

        private string jsonURLToString()
        {
            return new WebClient().DownloadString(jsonURL);   // Convert JSON to string.
        }
    }
}
