using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Exceptions
{
	public class ValidationException : Exception
	{
		public List<string> ValidationErrors { get; set; } = new List<string>();

        public ValidationException(ValidationResult result)
		{
			foreach (var error in result.Errors)
			{
				ValidationErrors.Add(error.ErrorMessage);
			}
		}
	}
}
