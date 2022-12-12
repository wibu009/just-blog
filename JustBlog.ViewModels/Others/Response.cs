namespace JustBlog.ViewModels.Others
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public ICollection<T>? Datas { get; set; }
    }
}
