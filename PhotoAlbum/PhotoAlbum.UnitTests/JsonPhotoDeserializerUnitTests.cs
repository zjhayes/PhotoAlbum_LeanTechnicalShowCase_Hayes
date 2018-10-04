using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;
using System.Collections.Generic;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class JsonPhotoDeserializerUnitTests
    {
        [TestMethod]
        public void JsonPhotoDeserializer_ThrowsNullArgumentException()
        {
            JsonPhotoDeserializer testAlbumOrganizer = new JsonPhotoDeserializer();
            try
            {
                testAlbumOrganizer.DeserializeJson();
                Assert.Fail();  // Exception not thrown if reached.
            }
            catch(ArgumentNullException)
            {
                Assert.IsTrue(true);    // Passes if exception is thrown.
            }
        }

        [TestMethod]
        public void JsonPhotoDeserializer_JsonStringDeserialized_IsEqual()
        {
            JsonPhotoDeserializer testDeserializer = new JsonPhotoDeserializer();
            testDeserializer.JsonURL = "https://jsonplaceholder.typicode.com/photos";
            List<Photo> deserializedPhotoCollection = testDeserializer.DeserializeJson();

            string expected = "[albumId = 1, id = 1, title = accusamus beatae ad facilis cum similique qui sunt, " +
                "url = https://via.placeholder.com/600/92c952, thumbnailUrl = https://via.placeholder.com/150/92c952]";

            string actual = deserializedPhotoCollection[0].ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
