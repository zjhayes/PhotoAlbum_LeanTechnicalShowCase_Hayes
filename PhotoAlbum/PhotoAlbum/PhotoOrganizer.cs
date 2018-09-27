using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                int i = 0; // Album iterator.
                foreach(Photo photo in PhotoCollection)
                {
                    if(photo.albumId == i)
                    {
                        // Prints photo id and title to console.
                        Console.WriteLine("[{0}] {1}", photo.id, photo.title);
                    }
                    else
                    {
                        // Iterate to next album and print album id as header.
                        Console.WriteLine("> photo-album {0}", ++i);
                    }
                }
            }
            catch (ArgumentNullException nullex) // When PhotoCollection is empty.
            {
                throw new ArgumentNullException("PhotoCollection cannot be empty. ", nullex);
            }

        }
    }
}
