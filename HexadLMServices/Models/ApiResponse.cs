namespace HexadLMServices.Models
{
    public class ApiResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public int? ResponseCode { get; set; }
        public object Data { get; set; }
    }
}
