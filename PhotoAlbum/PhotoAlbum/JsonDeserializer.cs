using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum
{
    public class JsonDeserializer
    {
        public JsonDeserializer()
        {
            
        }

        public Photo deserializeJson(string strJson)
        {
            var jPhoto = JsonConvert.DeserializeObject<Photo>(strJson);
            return jPhoto;
        }
    }
}
