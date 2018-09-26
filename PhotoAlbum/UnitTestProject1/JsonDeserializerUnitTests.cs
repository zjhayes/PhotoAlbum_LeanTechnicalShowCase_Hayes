using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class JsonDeserializerUnitTests
    {
        [TestMethod]
        public void DeserializeJson_PhotosAreEqual_AreEqual()
        {
            JsonDeserializer deserializer = new JsonDeserializer();

            string testJson = "{\"albumId\": 1, \"id\": 1, " +
                "\"title\": \"accusamus beatae ad facilis cum similique qui sunt\", " +
                "\"url\": \"https://via.placeholder.com/600/92c952\", " +
                "\"thumbnailUrl\": \"https://via.placeholder.com/150/92c952\"}";

            Photo expected = new Photo();
            expected.albumId = 1;
            expected.id = 1;
            expected.title = "accusamus beatae ad facilis cum similique qui sunt";
            expected.url = "https://via.placeholder.com/600/92c952";
            expected.thumbnailUrl = "https://via.placeholder.com/150/92c952";

            var actual = deserializer.deserializeJson(testJson);

            Assert.AreEqual(expected.toString(), actual.toString());
        }
    }
}
