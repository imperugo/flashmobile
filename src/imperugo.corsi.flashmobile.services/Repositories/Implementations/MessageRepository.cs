﻿using System.Collections.Concurrent;
using System.Linq;
using imperugo.corsi.flashmobile.services.Repositories.Documents;
using imperugo.corsi.flashmobile.services.Repositories.Interfaces;

namespace imperugo.corsi.flashmobile.services.Repositories.Implementations
{
	public class MessageRepository : IMessageRepository
	{
		private static readonly ConcurrentBag<MessageBase> db = new ConcurrentBag<MessageBase>();

		public MessageBase GetById(string id)
		{
			return db.FirstOrDefault(x => x.Id == id);
		}

		public void Seed()
		{
		}

		public void Seed(MessageBase[] documents)
		{
		}

		public TextMessage AddMessage(string text, string chatIdentifier)
		{
			var msg = new TextMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;

			db.Add(msg);

			return msg;
		}

		public ImageMessage AddImageMessage(string text, string chatIdentifier, string imageFilename)
		{
			var msg = new ImageMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;
			msg.MediaFileName = imageFilename;

			db.Add(msg);

			return msg;
		}

		public VideoMessage AddVideoMessage(string text, string chatIdentifier, string imageFilename)
		{
			var msg = new VideoMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;
			msg.MediaFileName = imageFilename;

			db.Add(msg);

			return msg;
		}

		public AudioMessage AddAudioMessage(string text, string chatIdentifier, string imageFilename)
		{
			var msg = new AudioMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;
			msg.MediaFileName = imageFilename;

			db.Add(msg);

			return msg;
		}

		public LocationMessage AddLocationMessage(string text, string chatIdentifier, double latitude,
			double longitude)
		{
			var msg = new LocationMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;
			msg.Latitude = latitude;
			msg.Longitude = longitude;

			db.Add(msg);

			return msg;
		}

		public ContactMessage AddContactMessage(string text, string chatIdentifier, string imageFilename, string firstname,
			string lastname)
		{
			var msg = new ContactMessage();
			msg.ChatIdentifier = chatIdentifier;
			msg.Text = text;
			msg.MediaFileName = imageFilename;
			msg.Firsname = firstname;
			msg.Lastname = lastname;

			db.Add(msg);

			return msg;
		}
	}
}