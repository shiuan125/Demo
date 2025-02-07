namespace Demo.Services.OGImageService
{
    public interface IOGImageService
    {
        public Task<string> GetOGImage(string Name);
    }
}
