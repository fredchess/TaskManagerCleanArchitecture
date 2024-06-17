using System;

namespace TaskManagerCleanArchitecture.Application.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{ }
	}
}
