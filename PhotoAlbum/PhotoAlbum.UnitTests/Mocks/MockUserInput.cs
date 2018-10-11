using PhotoAlbum;

namespace PhotoAlbumUnitTests.Mocks
{
    class MockUserInput : IUserInput
    {
        private string testInput;

        public string GetInput()
        {
            return testInput;
        }
        
        public void SetTestInput(string testInput)
        {
            this.testInput = testInput;
        }
    }
}
