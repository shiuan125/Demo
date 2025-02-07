using Demo.Repositories.DBModels;
using Demo.Repositories.Repositories;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Net.Mime.MediaTypeNames;

namespace Demo.Services.OGImageService
{
    public class OGImageService : IOGImageService
    {
        private readonly IRepository<Ogimage> _ogImageRepository;

        public OGImageService(IRepository<Ogimage> _ogImageRepository)
        {
            this._ogImageRepository = _ogImageRepository;
        }

        public async Task<string> GetOGImage(string Name)
        {
            string fileName = string.Empty;
            string filePath = "/File/image/";
            var ogImage = await _ogImageRepository.FindAsync(x => x.Name == Name)
                ?? throw new ArgumentException("No OG Image mapping found with the name", nameof(Name));
            
            if (ogImage.LocalMirrorFile)
            {
                fileName = !string.IsNullOrWhiteSpace(ogImage.Ext) ? $"{Name}-ogimage{ogImage.Ext}" : $"{Name}{ogImage.Ext}";
            }
            else
            {
                fileName = !string.IsNullOrWhiteSpace(ogImage.LocalExt) ? $"{Name}-ogimage{ogImage.LocalExt}" : $"{Name}{ogImage.Ext}";
            }

            return $"{filePath}{fileName}";
        }


    }
}
