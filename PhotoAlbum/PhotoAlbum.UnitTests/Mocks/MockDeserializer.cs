using System.Collections.Generic;
using PhotoAlbum;
using PhotoAlbum.Interfaces;

namespace PhotoAlbumUnitTests.Mocks
{
    class MockDeserializer : IJsonDeserializer
    {
        public bool DeserializeJson_MethodRan { get; set; }
        public bool DeserializeAlbum_MethodRan { get; set; }
        public bool DeserializeAll_MethodRan { get; set; }

        public MockDeserializer()
        {
            DeserializeJson_MethodRan = false;
            DeserializeAlbum_MethodRan = false;
            DeserializeAll_MethodRan = false;
        }
        public List<Photo> DeserializeJson()
        {
            DeserializeJson_MethodRan = true;
            return new List<Photo>();
        }
        
        public void SetDeserializerToAlbum(string jsonURL, int albumId)
        {
            DeserializeAlbum_MethodRan = true;
        }

        public void SetDeserializerToAll(string jsonURL)
        {
            DeserializeAll_MethodRan = true;
        }
    }
}
