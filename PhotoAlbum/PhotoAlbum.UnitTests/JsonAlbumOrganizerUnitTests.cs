using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class JsonAlbumOrganizerUnitTests
    {
        [TestMethod]
        public void JsonDeserializer_ThrowsNullArgumentException()
        {
            JsonAlbumOrganizer testAlbumOrganizer = new JsonAlbumOrganizer(null);
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
            JsonAlbumOrganizer testAlbumOrganizer = new JsonAlbumOrganizer("https://jsonplaceholder.typicode.com/photos");
            testAlbumOrganizer.deserializeJson();

            string expected = "[albumId = 1, id = 1, title = accusamus beatae ad facilis cum similique qui sunt, " +
                "url = https://via.placeholder.com/600/92c952, thumbnailUrl = https://via.placeholder.com/150/92c952]";

            var actual = testAlbumOrganizer.DeserializedPhotoCollection[0].toString();

            Assert.AreEqual(expected, actual);
        }
    }
}
