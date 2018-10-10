using System;

namespace PhotoAlbum
{
    public class EntryPoint
    {
        private JsonPhotoDeserializer deserializer;
        PhotoOrganizer organizer;
        private string jsonURL = "https://jsonplaceholder.typicode.com/photos";
        private string instructions = "Enter the ID number of the album you want to view. " +
            "Enter 'ALL' to view all albums, or 'EXIT' to end the program.";
        private string albumHeader = "> photo-album ";
        private bool exitProgram = false;

        public void RunByConsole(IUserInput input)
        {
            Console.WriteLine(instructions);

            while (!exitProgram)    // Run until user enters "EXIT"
            {
                Console.Write(albumHeader);
                string args = input.GetInput();
                RunProgram(args);
            }
            Environment.Exit(0);
        }

        public void RunByCommandLine(string args)
        {
            Console.WriteLine(albumHeader + args.ToString());   // ex. "> photo-album 1"
            RunProgram(args);
        }

        private void RunProgram(string input)
        {
            try
            {
                SetDeserializer(input);
                SetPhotoCollection();
                organizer.PrintCollectionToConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
                Console.WriteLine(instructions);
            }
        }

        private void SetPhotoCollection()
        {
            organizer = new PhotoOrganizer
            {
                PhotoCollection = deserializer.DeserializeJson()
            };
        }

        private void SetDeserializer(string input)
        {
            deserializer = new JsonPhotoDeserializer();
            if (int.TryParse(input, out int albumId))
            {
                deserializer.JsonURL = (jsonURL + "?albumId=" + albumId);
            }
            else if (input.ToUpper() == "ALL")
            {
                // All photos will be printed to console.
                deserializer.JsonURL = jsonURL;
            }
            else if (input.ToUpper() == "EXIT")
            {
                exitProgram = true;
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }
        }
    }
}
