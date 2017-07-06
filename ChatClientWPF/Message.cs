using ChatClientWPF.ChatWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientWPF
{
    public class Message
    {
        public Message()
        {

        }
        public Message(string message,User user)
        {
            MessageText = message;
            User = user;
            ReceiveTime = DateTime.Now;
        }
        public Message(string message)
        {
            MessageText = message;          
        }
        private string _messageText;

        public string MessageText
        {
            get { return _messageText; }
            set { _messageText = value; }
        }

        private DateTime _receiveTime;

        public DateTime ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        public override string ToString()
        {
            if (ReceiveTime == DateTime.MinValue && User == null)
                return $"{MessageText}";
            return $"[{ReceiveTime}] {User?.UserName}: {MessageText}";
        }

    }
}
