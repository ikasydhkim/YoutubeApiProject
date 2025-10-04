using Microsoft.AspNetCore.Mvc;
using YoutubeApiProject.Services;
using YoutubeApiProject.Models;


namespace YoutubeApiProject.Controllers

{

    public class YoutubeController : Controller

    {

        private readonly YoutubeApiService _youtubeService;


        public YoutubeController(YoutubeApiService youtubeService)

        {

            _youtubeService = youtubeService;

        }


        // Display Search Page

        public IActionResult Index()

        {

            return View(new List<YoutubeVideoModel>()); // Pass an empty list initially

        }


        // Handle the search query

        [HttpPost]

        public async Task<IActionResult> Search(string query)

        {

            var videos = await _youtubeService.SearchVideosAsync(query);

            return View("Index", videos);

        }

    }

}