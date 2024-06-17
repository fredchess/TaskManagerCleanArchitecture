using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Responses
{
	public class BaseResponse
	{
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; } = 200;
        public IList<string> ValidationErrors { get; set; } = [];

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string message)
        {
            Message = message;
        }

		public BaseResponse(bool status, string message)
		{
			Message = message;
            Success = status;
		}

		public BaseResponse(IList<string> errors)
        {
            ValidationErrors = errors;
        }
    }
}
