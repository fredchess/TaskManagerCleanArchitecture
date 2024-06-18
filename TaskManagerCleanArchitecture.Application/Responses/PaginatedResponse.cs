namespace TaskManagerCleanArchitecture.Application.Responses
{
    public class PaginatedResponse<T> where T : class
    {
        public IList<T> Datas { get; set; } = [];
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalData { get; set; }
    }
}