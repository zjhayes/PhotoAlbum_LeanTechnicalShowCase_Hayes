using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;
using System.Collections.Generic;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class JsonAlbumOrganizerUnitTests
    {
        [TestMethod]
        public void JsonDeserializer_ThrowsNullArgumentException()
        {
            JsonPhotoDeserializer testAlbumOrganizer = new JsonPhotoDeserializer(null);
            try
            {
                testAlbumOrganizer.deserializeJson();
                Assert.Fail();  // Exception not thrown if reached.
            }
            catch(ArgumentNullException)
            {
                Assert.IsTrue(true);    // Passes if exception is thrown.
            }
        }

        [TestMethod]
        public void JsonDeserializer_JsonStringDeserialized_IsEqual()
        {
            JsonPhotoDeserializer testDeserializer = new JsonPhotoDeserializer("https://jsonplaceholder.typicode.com/photos");
            List<Photo> deserializedPhotoCollection = testDeserializer.deserializeJson();

            string expected = "[albumId = 1, id = 1, title = accusamus beatae ad facilis cum similique qui sunt, " +
                "url = https://via.placeholder.com/600/92c952, thumbnailUrl = https://via.placeholder.com/150/92c952]";

            var actual = deserializedPhotoCollection[0].toString();

            Assert.AreEqual(expected, actual);
        }
    }
}
