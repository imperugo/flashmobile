using System;
using System.ComponentModel.DataAnnotations;

namespace imperugo.corsi.flashmobile.common.Requests.Chats
{
	public class CreateChatRequest : RequestBase
	{
		[Required]
		public string[] CallerIndentifiers { get; set; }
	}
}