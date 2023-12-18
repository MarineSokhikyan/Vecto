using Vecto.Models;

namespace Vecto.Services
{
    public class ResizeEffect : IImageEffect
    {
        public ResizeEffect()
        {
        }

        public override void ApplyEffect(Image image)
        {
            Console.WriteLine($"Resizing {image.Name}");
        }
    }
}
