using PhotoAlbum;

namespace PhotoAlbumUnitTests
{
    class EntryPointLoopOnce : EntryPoint
    {
        public override bool IsExited()
        {
            return true;
        }
    }
}
