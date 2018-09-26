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
                JsonAlbumOrganizer jsonAlbum = new JsonAlbumOrganizer("https://jsonplaceholder.typicode.com/photos");
                jsonAlbum.deserializeJson();
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
