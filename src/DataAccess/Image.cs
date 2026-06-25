namespace Bildur.DataAccess
{
    public class Image
    {
        public int ID;
        public required string FileName;
        public required byte[] Content;
        public required string ImageType;
        public int Size;
        // Helper string not mapped in database
        public string? base64String;
    }
}
