using Vecto.Models;

namespace Vecto.Services
{
    public class GrayscaleEffect : IImageEffect
    {
        public GrayscaleEffect()
        {
        }

        public override void ApplyEffect(Image image)
        {
            Console.WriteLine($"Applying grayscale effect to {image.Name}");
        }
    }
}
