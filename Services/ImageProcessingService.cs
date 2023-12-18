using Vecto.Models;

namespace Vecto.Services
{
    public class ImageProcessingService : IImageProcessingService
    {
        private readonly List<IImageEffect> _effects;

        public ImageProcessingService(List<IImageEffect> effects)
        {
            _effects = effects ?? throw new ArgumentNullException(nameof(effects));
        }

        public void ProcessImages(List<Image> images)
        {
            foreach (var image in images)
            {
                Console.WriteLine($"Processing {image.Name}:");

                foreach (var effect in _effects)
                {
                    effect.ApplyEffect(image);
                }

                Console.WriteLine();
            }
        }
    }

}
