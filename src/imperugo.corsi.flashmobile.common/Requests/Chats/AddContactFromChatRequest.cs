﻿namespace imperugo.corsi.flashmobile.common.Requests.Chats
{
	public class AddContactFromChatRequest : RequestBase
	{
		public string ChatIdentifier { get; set; }
		public string CallerIndentifier { get; set; }
	}
}