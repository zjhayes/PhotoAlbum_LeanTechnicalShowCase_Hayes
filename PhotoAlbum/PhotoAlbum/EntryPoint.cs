using System;

namespace PhotoAlbum
{
    class EntryPoint
    {
        private static JsonPhotoDeserializer deserializer;
        private static string jsonURL;
        private static string instructions = "Enter the ID number of the album you want to view. " +
            "Enter 'ALL' to view all albums, or 'EXIT' to end the program.";

        /// <summary>
        /// Deserializes JSON URL, user can enter Album ID to print that photo album.
        /// Or user can enter "ALL" to print all photos to console.
        /// Or user can enter "EXIT" to end program.
        /// </summary>
        /// <param name="args">Command line arguements.</param>
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
                    validateInput(input);
                    PhotoOrganizer organizer = new PhotoOrganizer
                    {
                        // Deserialize JSON to PhotoCollection of Photo objects.
                        PhotoCollection = deserializer.deserializeJson()
                    };
                    organizer.printCollectionToConsole();   // Print the user designated photo album.
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(); // Empty line for spacing.
                    Console.WriteLine(instructions);
                }
            }
        }

        /// <summary>
        /// Validates that user input is an int, implying it is an albumId.
        /// Otherwise, if user enters "ALL" deserializes entire JsonURL.
        /// Otherwise, if user enters "EXIT" ends the program.
        /// Any other input is invalid, writes error message to console.
        /// </summary>
        /// <param name="input">User input read from console.</param>
        private static void validateInput(string input)
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
