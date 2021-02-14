using System.Collections;
using System.Collections.Generic;

namespace MetWorkingUserApplication.Contracts.Response
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Errors = new List<string>();
            IsOk = true;
            IsForbbiden = false;
        }
        public List<string> Errors { get; set; }
        public bool IsOk { get; set; }
        public bool IsForbbiden { get; set; }
        public T Data { get; set; }
    }
}