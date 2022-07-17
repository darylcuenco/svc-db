namespace svc_db.Models
{
    public class ResponseModel<T> 
    {
        public int? statusCode { get; set; }
        public string? status { get; set; }
        public int? errorCode { get; set; }
        public bool? success { get; set; }
        public string? message { get; set; }
        public T? data { get; set; }
    }

    public class GenericResponse
    {
        public int? statusCode { get; set; }
        public string? status { get; set; }
        public int? errorCode { get; set; }
        public bool? success { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }
    }

            
}