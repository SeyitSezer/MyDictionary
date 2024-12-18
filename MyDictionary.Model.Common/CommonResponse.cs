namespace MyDictionary.Model.Common
{
    public class CommonResponse<T>
    {
        public bool IsSuccess {  get; set; }
        public int Status {  get; set; }
        public string? StatusDesciption {  get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
