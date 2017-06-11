using System;

namespace imperugo.corsi.flashmobile.services.Exceptions
{
	public class ApplicationException : Exception
	{
		public ApplicationException() : this("Something went wrong")
		{
		}

		public ApplicationException(string message) : base(message)
		{
		}

		public ApplicationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}