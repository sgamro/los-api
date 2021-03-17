namespace los_api.Models
{
    public class ResultModel
    {
        public string Message { set; get; }
        public int StatucCode { set; get; }
        public object Data { set; get; }
        public bool success { set; get; } 
    }
}