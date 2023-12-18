namespace Vecto.Models
{
    public class Image
    {
        public string Name { get; set; }
    }
    public class PluginConfiguration
    {
        public string Type { get; set; } 
        public Dictionary<string, object> Parameters { get; set; }
    }
    public class ImageProcessingModel
    {
        public IFormFile ImageFile { get; set; } 
        public List<string> SelectedEffects { get; set; }
        public int Radius { get; set; }
        public int Size { get; set; }
    }

}
