using System;
namespace ModelLayer.DTO
{
	public class ResponseBody<T>
	{
		public bool Sucess { get; set; } = true;
		public string Message { get; set; } = "";
		public T Data = default(T);
		
	}
}

