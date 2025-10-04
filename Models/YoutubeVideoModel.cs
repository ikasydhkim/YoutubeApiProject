namespace YoutubeApiProject.Models
{
    public class YoutubeVideoModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ThumbnailUrl { get; set; }

        public string VideoUrl { get; set; } // Add this property for the video link
    }
}
