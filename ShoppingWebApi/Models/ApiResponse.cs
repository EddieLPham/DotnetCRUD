using System;
namespace ShoppingWebApi.Models
{
	public class ApiResponse
	{
		// Api responses to requests
		public string Code { get; set; }
		public string Message { get; set; }
		public object? ResponseData { get; set; }
	}
	public enum ResponseType
	{
		//add as many as needed
		Success,
		NotFound,
		Failure,

	}
}

