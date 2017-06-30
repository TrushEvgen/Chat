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
            _users.Add(OperationContext.Current.GetCallbackChannel<IChatCallBack>(), user);
            foreach (var otherUser in _users.Keys)
            {
                otherUser.GetUserList(_users.Select(p => p.Value).ToList());
            }
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
            key = _users.FirstOrDefault(x => x.Value == user).Key;
            if (key != null)
            {
                _users.Remove(key);
                foreach (var otherUser in _users.Keys)
                {
                    otherUser.GetUserList(_users.Select(p => p.Value).ToList());
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
