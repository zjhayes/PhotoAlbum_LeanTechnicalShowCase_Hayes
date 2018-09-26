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
    public class JsonAlbumOrganizer
    {
        private string jsonURL;
        public List<Photo> DeserializedPhotoCollection { get; set; }

        public JsonAlbumOrganizer(string jsonURL)
        {
            this.jsonURL = jsonURL;
        }

        public void deserializeJson()
        {
            try
            {
                string strJson = jsonURLToString();
                // Create list of deserialized JSON photo objects.
                DeserializedPhotoCollection = JsonConvert.DeserializeObject<List<Photo>>(strJson);
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

        public void printCollectionToConsole()
        {

        }
    }
}
