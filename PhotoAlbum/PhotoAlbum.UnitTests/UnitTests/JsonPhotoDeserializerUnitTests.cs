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
        public void JsonPhotoDeserializer_JsonStringDeserialized_AreEqual()
        {
            JsonPhotoDeserializer testDeserializer = new JsonPhotoDeserializer
            {
                JsonURL = "https://jsonplaceholder.typicode.com/photos"
            };
            List<Photo> deserializedPhotoCollection = testDeserializer.DeserializeJson();

            string expected = "[albumId = 1, id = 1, title = accusamus beatae ad facilis cum similique qui sunt, " +
                "url = https://via.placeholder.com/600/92c952, thumbnailUrl = https://via.placeholder.com/150/92c952]";

            string actual = deserializedPhotoCollection[0].ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDeserializerToAlbum_SetsJsonUrl_AreEqual()
        {
            string jsonUrl = "https://jsonplaceholder.typicode.com/photos";
            JsonPhotoDeserializer testDeserializer = new JsonPhotoDeserializer
            {
                JsonURL = jsonUrl
            };

            testDeserializer.SetDeserializerToAlbum(jsonUrl, 1);
            string expected = "https://jsonplaceholder.typicode.com/photos?albumId=1";
            string actual = testDeserializer.JsonURL;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetDeserializerToAll_SetsJsonUrl_AreEqual()
        {
            string jsonUrl = "https://jsonplaceholder.typicode.com/photos";
            JsonPhotoDeserializer testDeserializer = new JsonPhotoDeserializer
            {
                JsonURL = "http://testfail.com"
            };
            testDeserializer.SetDeserializerToAll(jsonUrl);
            string expected = "https://jsonplaceholder.typicode.com/photos";
            string actual = testDeserializer.JsonURL;

            Assert.AreEqual(expected, actual);
        }
    }
}
