namespace MyDictionary.Model.Common
{
    public class CommonResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public string? StatusDesciption { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public void SetData(T data)
        {
            IsSuccess = true;
            Data = data;
            if (data != null)
            {
                Status = 1;
                StatusDesciption = "Service Success.";
            }
            else
            {
                Status = 2;
                StatusDesciption = "Data not found.";
                Message = "Service worked successfully but there are no results";
            }
        }

        public void SetException(Exception exception)
        {
            IsSuccess = false;
            Data = default(T);
            Status = -99;
            StatusDesciption = "Service failed. Check Message more details.";
            Message = $"{exception.Message}{Environment.NewLine}Trace: {exception.StackTrace}";
            if (exception.InnerException != null)
            {
                Message += $"{exception.InnerException.Message}{Environment.NewLine}Trace: {exception.InnerException.StackTrace}"; ;
            }
        }
    }
}
