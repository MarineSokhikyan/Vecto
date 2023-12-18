using Vecto.Models;

namespace Vecto.Services
{
    public class BlurEffect : IImageEffect
    {
        public BlurEffect()
        {
            // Initialization logic, if needed
        }

        public override void ApplyEffect(Image image)
        {
            // Implement image blur logic here
            Console.WriteLine($"Applying blur effect to {image.Name}");
        }
    }

}
