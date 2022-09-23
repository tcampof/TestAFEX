namespace Videos.Dto
{

    public class VideoDto
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public IList<Item> items { get; set; }
        public PageInfo pageInfo { get; set; }
    }
    public class Item
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
    }

    public class PageInfo
    {
        public int totalResults { get; set; }
        public int resultsPerPage { get; set; }
    }

}
