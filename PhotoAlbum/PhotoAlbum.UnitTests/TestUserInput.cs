using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    class TestUserInput : IUserInput
    {
        private string testInput;

        public string GetInput()
        {
            return testInput;
        }

        public void setTestInput(string testInput)
        {
            this.testInput = testInput;
        }
    }
}
