using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAlbum
{
    public class PhotoOrganizer
    {
        public List<Photo> PhotoCollection { get; set; }

        public void PrintCollectionToConsole()
        {
            try
            {
                if(!PhotoCollection.Any()) // When the user provided albumId doesn't exist..
                {
                    Console.WriteLine("Album ID does not exist.");
                }

                foreach(Photo photo in PhotoCollection)
                {
                    Console.WriteLine("[{0}] {1}", photo.id, photo.title);
                }
            }
            catch (ArgumentNullException nullex) // When no jsonURL is provided.
            {
                throw new ArgumentNullException("PhotoCollection cannot be null. ", nullex);
            }

        }
    }
}
