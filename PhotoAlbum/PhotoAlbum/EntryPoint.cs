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

            while (true)    // Run until user enters "EXIT"
            {
                jsonURL = "https://jsonplaceholder.typicode.com/photos";
                deserializer = new JsonPhotoDeserializer();
                try
                {
                    Console.Write("> photo-album ");
                    string input = Console.ReadLine();  // Take user input.
                    ValidateInput(input);
                    PhotoOrganizer organizer = new PhotoOrganizer
                    {
                        PhotoCollection = deserializer.DeserializeJson()
                    };
                    organizer.PrintCollectionToConsole();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(); // Empty line for spacing.
                    Console.WriteLine(instructions);
                }
            }
        }

        private static void ValidateInput(string input)
        {
            // Check if input is valid integer and set albumId accordingly.
            if (int.TryParse(input, out int albumId))
            {
                // Set deserializer JsonURL to user designated album.
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
            else   // if input not accepted..
            {
                Console.WriteLine("INVALID INPUT");
            }
        }
    }
}
