
namespace PhotoAlbum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EntryPoint program = new EntryPoint();
            if (args.Length == 0)
            {
                program.RunByConsole(new UserInput());
            }
            else
            {
                program.RunByCommandLine(args[0]);
            }
        }
    }
}
