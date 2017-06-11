using System.ComponentModel.DataAnnotations;

namespace imperugo.corsi.flashmobile.common.Requests
{
	public class SimplePagedRequest
	{
		public SimplePagedRequest()
		{
			this.PageIndex = 0;
			this.PageSize = 10;
		}

		[Range(0,int.MaxValue)]
		public int PageIndex { get; set; }

		[Range(1, int.MaxValue)]
		public int PageSize { get; set; }
	}
}