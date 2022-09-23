using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Web;
using Videos.Dto;
using Videos.Models;

namespace Videos.Data
{
    public class VideoServices : IVideoServices
    {
        private readonly AppDbContext _context;

        public VideoServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Video>> Create(string link)
        {
            try
            {
                {
                    var uri = new Uri(link);
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    var videoId = query["v"];
                    var video = await GetUrlVideo(videoId);
                    foreach (var item in video.items)
                    {
                        var _video = new Video { id = item.id, etag = item.etag, kind = item.kind, url = link };
                        _context.Videos.Add(_video);
                        await _context.SaveChangesAsync();
                    }
                    var result = _context.Videos.OrderByDescending(v => v.id_videos).ToList();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var video = _context.Videos.Find(Id);
                _context.Videos.Remove(video);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Video> Get(int Id)
        {
            var result = await _context.Videos.FindAsync(Id);
            return result;
        }

        public List<Video> GetAll()
        {
            var result = _context.Videos.OrderByDescending(v => v.id_videos).ToList();
            return result;
        }

        public async Task<VideoDto> GetUrlVideo(string idVideo)
        {
            VideoDto video = new();

            var apiYoutube = "https://www.googleapis.com/youtube/v3";
            var keyApiYoutube = "AIzaSyCh5TP79zJkQtMqshrDFp1i43fZR4Mix94";

            var client = new HttpClient();
            client.BaseAddress = new Uri(apiYoutube);
            var response = await client.GetAsync(String.Format("https://www.googleapis.com/youtube/v3/videos?id={0}&key={1}&", idVideo, keyApiYoutube));
            var body = await response.Content.ReadAsStringAsync();
            video = JsonSerializer.Deserialize<VideoDto>(body);

            return video;
        }
    }
}
