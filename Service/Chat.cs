using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Chat" в коде и файле конфигурации.
    [ServiceBehavior(ConcurrencyMode =ConcurrencyMode.Single,InstanceContextMode =InstanceContextMode.Single)]
    public class Chat : IChat
    {
        Dictionary<IChatCallBack, User> _users = new Dictionary<IChatCallBack, User>();
        public void Join(User user)
        {
            IChatCallBack chatCallBack = OperationContext.Current.GetCallbackChannel<IChatCallBack>();
            //отправляем всем сообщение что мы зашли в чат
            foreach (var otherUser in _users.Keys)
            {
                otherUser.UserJoined(user);
            }
            _users.Add(chatCallBack, user);
            chatCallBack.GetUserList(_users.Select(p => p.Value).ToList());
            //foreach (var otherUser in _users.Keys)
            //{
            //    otherUser.GetUserList(_users.Select(p => p.Value).ToList());
            //}
        }

        public void Send(string message)
        {
            User user = null;
            var connection = OperationContext.Current.GetCallbackChannel<IChatCallBack>();
            if (!_users.TryGetValue(connection, out user))
                return;          

            foreach (var otherUser in _users.Keys)
            {
                otherUser.GetMessages(user, message);
            }
        }

        public void Leave(User user)
        {
            IChatCallBack key = null;
            key = OperationContext.Current.GetCallbackChannel<IChatCallBack>();    
            Console.WriteLine($"User {user.UserName} leave");
            //Console.WriteLine($"{user.UserName} key = {key}");

            if (key != null)
            {
                _users.Remove(key);
                foreach (var otherUser in _users.Keys)
                {
                    otherUser.UserLeave(user);
                }
            }
        }

        public void Whisper(User toUser, string message)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatCallBack>();
            User user = null;
            if (!_users.TryGetValue(connection, out user))
            {

            }
                IChatCallBack toUserConnection = null;
            toUserConnection = _users.Where(x => x.Value == toUser).FirstOrDefault().Key;
            if (toUserConnection!=null)
            {
                toUserConnection.ReceiveWhisper(user,message);
            }
        }
    }
}
