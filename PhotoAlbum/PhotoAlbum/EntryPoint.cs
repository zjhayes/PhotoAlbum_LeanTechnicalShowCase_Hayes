using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                JsonPhotoDeserializer jsonAlbum = new JsonPhotoDeserializer("https://jsonplaceholder.typicode.com/photos");
                PhotoOrganizer organizer = new PhotoOrganizer();
                organizer.PhotoCollection = jsonAlbum.deserializeJson();
                organizer.printCollectionToConsole();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.Read(); // Keeps the console up.
            }

        }
    }
}
