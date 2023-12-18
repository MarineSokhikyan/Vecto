using Vecto.Models;

namespace Vecto.Services
{
    public class BlurEffect : IImageEffect
    {
        public BlurEffect()
        {
        }

        public override void ApplyEffect(Image image)
        {
            Console.WriteLine($"Applying blur effect to {image.Name}");
        }
    }

}
