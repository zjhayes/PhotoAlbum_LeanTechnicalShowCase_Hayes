using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    [TestClass]
    public class PhotoOrganizerUnitTests
    {
        [TestMethod]
        public void PrintCollectionToConsole_ThrowsNullArgumentException()
        {
            PhotoOrganizer testOrganizer = new PhotoOrganizer() ;
            // Not setting PhotoCollection property, making it null.
            try
            {
                testOrganizer.printCollectionToConsole();
                Assert.Fail();  // Exception not thrown if reached.
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);    // Passes if exception is thrown.
            }
        }
    }
}
