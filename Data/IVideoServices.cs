using Videos.Models;

namespace Videos.Data
{
    public interface IVideoServices
    {
        public Task<List<Video>> Create(string idVideo);
        public List<Video> GetAll();
        public Task<List<Video>> Delete(int Id);

        public Task<Video> Get(int Id);
    }
}
