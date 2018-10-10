using System;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            EntryPoint program= new EntryPoint();

            if(args.Length == 0)
            {
                program.RunByConsole(new UserInput());
            }
            else
            {
                program.RunByCommandLine(args[0]);
            }
        }
    }

    class UserInput : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
