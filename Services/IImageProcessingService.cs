using Vecto.Models;

namespace Vecto.Services
{
    public interface IImageProcessingService
    {
        void ProcessImages(List<Image> images);
    }
}
