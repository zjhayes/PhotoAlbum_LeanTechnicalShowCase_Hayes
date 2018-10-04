using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class PhotoOrganizerUnitTests
    {
        StringWriter stringWriter = new StringWriter();

        [TestMethod]
        public void PrintCollectionToConsole_ThrowsArgumentNullException()
        {
            PhotoOrganizer testOrganizer = new PhotoOrganizer();
            // Not setting PhotoCollection property, making it null.
            try
            {
                testOrganizer.PrintCollectionToConsole();
                Assert.Fail();  // Exception not thrown if reached.
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);    // Passes if null reference exception is thrown.
            }
        }

        [TestMethod]
        public void PrintCollectionToConsole_CollectionPrintedToConsole_IsEqual()
        {
            PhotoOrganizer testOrganizer = new PhotoOrganizer();
            Photo testPhoto = new Photo();
            testPhoto.albumId = 1;
            testPhoto.id = 1;
            testPhoto.title = "accusamus beatae ad facilis cum similique qui sunt";
            testPhoto.url = "https://via.placeholder.com/600/92c952";
            testPhoto.thumbnailUrl = "https://via.placeholder.com/150/92c952";
            testOrganizer.PhotoCollection = new List<Photo>();
            testOrganizer.PhotoCollection.Add(testPhoto);

            using (stringWriter)
            {
                Console.SetOut(stringWriter);
                testOrganizer.PrintCollectionToConsole();
                string expected = 
                    string.Format("[1] accusamus beatae ad facilis cum similique qui sunt{0}", 
                    Environment.NewLine);
                string actual = stringWriter.ToString();
                // Passes if test collection is printed to console.
                Assert.AreEqual(expected, actual);
            }

        }

        [TestMethod]
        public void PrintCollectionToConsole_AlbumIdDoesNotExist_IsEqual()
        {
            PhotoOrganizer testOrganizer = new PhotoOrganizer();
            testOrganizer.PhotoCollection = new List<Photo>();
            // List is left empty.
            using (stringWriter)
            {
                Console.SetOut(stringWriter);
                testOrganizer.PrintCollectionToConsole();
                string expected =
                    string.Format("Album ID does not exist.{0}",
                    Environment.NewLine);
                string actual = stringWriter.ToString();
                // Passes if test collection is printed to console.
                Assert.AreEqual(expected, actual);
            }

        }
    }
}
