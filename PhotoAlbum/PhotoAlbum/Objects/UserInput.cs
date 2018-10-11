using System;

namespace PhotoAlbum
{

    class UserInput : IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine().Trim();
        }
    }
}
