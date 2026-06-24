namespace Bildur.DataAccess
{
    public class Image
    {
        public int ID;
        public required byte[] Content;
        public required string ImageType;
        public int Size;
        public int Width;
        public int Height;
    }
}
