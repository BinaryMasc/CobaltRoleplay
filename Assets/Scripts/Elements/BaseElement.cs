using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace CobaltRoleplay.Objects
{

    public abstract class BaseElement
    {

        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public int Id { get; set; }

        public string SourceImageUrl { get; set; }
        public byte[] SourceImage { get; set; }

        bool imageLoaded = false;

        public BaseElement()
        {

        }

        public bool ImageLoaded() { return imageLoaded; }

        async public Task LoadSourceImage()
        {
            if (SourceImage == null && !string.IsNullOrWhiteSpace(SourceImageUrl))
            {
                using (var httpClient = new HttpClient())
                {
                    var img = await httpClient.GetByteArrayAsync(SourceImageUrl);
                    SourceImage = new byte[img.Length];
                    img.CopyTo(SourceImage, 0);
                    imageLoaded = true;

                }

            }
        }
    }
}
