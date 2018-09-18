using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GedditWeb.Services
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResult(bool success, T result)
        {
            Success = success;
            Message = "";
            Result = result;
        }

        public ServiceResult(bool success, string message, T result = default(T))
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }
}