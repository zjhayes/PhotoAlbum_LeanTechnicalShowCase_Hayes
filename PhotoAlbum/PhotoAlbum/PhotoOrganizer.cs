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

        /// <summary>
        /// Formats PhotoCollection and prints to console.
        /// If collection is empty list, assumes user provided albumId is invalid,
        /// and writes error message to the console.
        /// If PhotoCollection is null, passes exception to calling class.
        /// </summary>
        public void printCollectionToConsole()
        {
            try
            {
                if(collectionIsEmpty()) // When the user provided albumId doesn't exist..
                {
                    Console.WriteLine("Album ID does not exist.");
                }

                foreach(Photo photo in PhotoCollection)
                {
                    // Prints photo id and title to console.
                    Console.WriteLine("[{0}] {1}", photo.id, photo.title);
                }
            }
            catch (NullReferenceException nullex) // When PhotoCollection is empty.
            {
                throw new NullReferenceException("PhotoCollection cannot be null. ", nullex);
            }

        }

        /// <summary>
        /// Checks if PhotoCollection is empty list.
        /// </summary>
        /// <returns>True if empty list, False otherwise.</returns>
        private bool collectionIsEmpty()
        {
            // Returns true if PhotoCollection is empty.
            return PhotoCollection.Count == 0;
        }
    }
}
