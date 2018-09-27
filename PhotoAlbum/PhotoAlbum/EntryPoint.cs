using System;

namespace PhotoAlbum
{
    class EntryPoint
    {
        private static JsonPhotoDeserializer deserializer;
        private static string jsonURL;
        private static string instructions = "Enter the ID number of the album you want to view. " +
            "Enter 'ALL' to view all albums, or 'EXIT' to end the program.";

        static void Main(string[] args)
        {
            Console.WriteLine(instructions);
            while (true)
            {
                jsonURL = "https://jsonplaceholder.typicode.com/photos";
                deserializer = new JsonPhotoDeserializer();
                try
                {
                    Console.Write("> photo-album ");
                    string input = Console.ReadLine();
                    validateInput(input);
                    PhotoOrganizer organizer = new PhotoOrganizer
                    {
                        PhotoCollection = deserializer.deserializeJson()
                    };
                    organizer.printCollectionToConsole();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(); // Empty line for spacing.
                    Console.WriteLine(instructions);
                }
            }
        }

        private static void validateInput(string input)
        {
            if (int.TryParse(input, out int albumId))
            {
                deserializer.JsonURL = (jsonURL + "?albumId=" + albumId);
            }
            else if (input.ToUpper() == "ALL")
            {
                deserializer.JsonURL = jsonURL;      // All photos will be printed to console.
            }
            else if (input.ToUpper() == "EXIT")
            {
                Environment.Exit(0);                // End program.
            }
            else   // if input not accepted.
            {
                Console.WriteLine("INVALID INPUT");
            }
        }
    }
}
