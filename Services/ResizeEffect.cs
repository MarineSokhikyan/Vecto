using Vecto.Models;

namespace Vecto.Services
{
    public class ResizeEffect : IImageEffect
    {
        public ResizeEffect()
        {
            // Initialization logic, if needed
        }

        public override void ApplyEffect(Image image)
        {
            // Implement image resizing logic here
            Console.WriteLine($"Resizing {image.Name}");
        }
    }
}
