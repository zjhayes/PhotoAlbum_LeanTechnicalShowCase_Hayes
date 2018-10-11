using System.Collections.Generic;

namespace PhotoAlbum.Interfaces
{
    public interface IJsonDeserializer
    {
        List<Photo> DeserializeJson();
        void SetDeserializerToAlbum(string jsonURL, int albumId);
        void SetDeserializerToAll(string jsonURL);
    }
}
