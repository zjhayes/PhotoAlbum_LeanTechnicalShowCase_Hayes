using PhotoAlbum.Interfaces;
using System;

namespace PhotoAlbum
{
    public class EntryPoint
    {
        public IJsonDeserializer Deserializer { get; set; }
        PhotoOrganizer organizer;
        private readonly string jsonURL = "https://jsonplaceholder.typicode.com/photos";
        private readonly string instructions = "Enter the ID number of the album you want to view. " +
            "Enter 'ALL' to view all albums, or 'EXIT' to end the program.";
        private readonly string albumHeader = "> photo-album ";
        private bool exitProgram = false;

        public EntryPoint()
        {
            Deserializer = new JsonPhotoDeserializer();
        }

        public virtual void RunByConsole(IUserInput input)
        {
            Console.WriteLine(instructions);

            do    // Run until user enters "EXIT"
            {
                Console.Write(albumHeader);
                string args = input.GetInput();
                RunProgram(args);
            }
            while (!IsExited());
        }

        public virtual void RunByCommandLine(string arg)
        {
            Console.WriteLine(albumHeader + arg.ToString());   // ex. "> photo-album 1"
            RunProgram(arg);
        }

        private void RunProgram(string input)
        {
            try
            {
                ParseInput(input);
                if (!exitProgram)
                {
                    SetPhotoCollection();
                    organizer.PrintCollectionToConsole();
                }
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
                PhotoCollection = Deserializer.DeserializeJson()
            };
        }

        private void ParseInput(string input)
        {
            if (int.TryParse(input, out int albumId))
            {
                Deserializer.SetDeserializerToAlbum(jsonURL, albumId);
            }
            else if (input.ToUpper() == "ALL")
            {
                Deserializer.SetDeserializerToAll(jsonURL);
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

        public virtual bool IsExited()
        {
            return exitProgram;
        }
    }
}
