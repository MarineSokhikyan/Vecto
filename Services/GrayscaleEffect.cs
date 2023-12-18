using Vecto.Models;

namespace Vecto.Services
{
    public class GrayscaleEffect : IImageEffect
    {
        public GrayscaleEffect()
        {
            // Initialization logic, if needed
        }

        public override void ApplyEffect(Image image)
        {
            // Implement grayscale effect logic here
            Console.WriteLine($"Applying grayscale effect to {image.Name}");
        }
    }
}
