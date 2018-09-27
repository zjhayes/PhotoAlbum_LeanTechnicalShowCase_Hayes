using System;
using System.Collections.Generic;

namespace PhotoAlbum
{
    public class PhotoOrganizer
    {
        public List<Photo> PhotoCollection { get; set; }

        public PhotoOrganizer()
        {

        }

        public void printCollectionToConsole()
        {
            try
            {
                foreach(Photo photo in PhotoCollection)
                {
                    // Prints photo id and title to console.
                    Console.WriteLine("[{0}] {1}", photo.id, photo.title);
                }
            }
            catch (ArgumentNullException nullex) // When PhotoCollection is empty.
            {
                throw new ArgumentNullException("PhotoCollection cannot be empty. ", nullex);
            }

        }
    }
}
