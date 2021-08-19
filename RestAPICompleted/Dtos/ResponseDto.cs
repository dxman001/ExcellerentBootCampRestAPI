
using System.Collections.Generic;

namespace RestAPICompleted.Dtos
{
    public class ResponseDto<T>
    {
        public List<T> Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ResponseDto(List<T> data,bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
        }
        public ResponseDto(T data, bool isSuccess, string message)
        {
            Data = new List<T> { data };
            IsSuccess = isSuccess;
            Message = message;
        }
        public ResponseDto(List<T> data,string message)
        {
            Data = data;
            IsSuccess = false;
            Message = message;
        }
        public ResponseDto(List<T> data)
        {
            Data = data;
            IsSuccess = true;
        }
        public ResponseDto(T data)
        {
            Data = new List<T> { data };
            IsSuccess = true;
        }
        public ResponseDto(bool isSuccess,string message)
        {
            Data = null;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
