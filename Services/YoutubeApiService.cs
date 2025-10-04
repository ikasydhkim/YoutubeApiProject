using Google.Apis.Services;

using Google.Apis.YouTube.v3;

using YoutubeApiProject.Models;


namespace YoutubeApiProject.Services

{

    public class YoutubeApiService

    {

        private readonly string _apiKey;


        public YoutubeApiService(IConfiguration configuration)

        {

            _apiKey = configuration["YoutubeApiKey"]; // Fetch API key from appsettings.json

        }


        public async Task<List<YoutubeVideoModel>> SearchVideosAsync(string query)

        {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()

            {

                ApiKey = _apiKey,

                ApplicationName = "YoutubeProject"

            });


            var searchRequest = youtubeService.Search.List("snippet");

            searchRequest.Q = query; // User's query from form input

            searchRequest.MaxResults = 10;

            var searchResponse = await searchRequest.ExecuteAsync();


            var videos = searchResponse.Items.Select(item => new YoutubeVideoModel

            {

                Title = item.Snippet.Title,

                Description = item.Snippet.Description,

                ThumbnailUrl = item.Snippet.Thumbnails.Medium.Url,

                VideoUrl = "https://www.youtube.com/watch?v=6ykCRoxzlUQ&list=RD6ykCRoxzlUQ&start_radio=1" + item.Id.VideoId // Add this line

            }).ToList();


            return videos;

        }
    }
}