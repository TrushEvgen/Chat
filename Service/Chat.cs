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
        }

        public void Leave(User user)
        {
            IChatCallBack key = null;
            key = _users.FirstOrDefault(x => x.Value == user).Key;
            if (key != null)
                _users.Remove(key);
        }

        public void Send(string message)
        {
            User user = null;
            var connection = OperationContext.Current.GetCallbackChannel<IChatCallBack>();
            if (!_users.TryGetValue(connection, out user))
                return;
            var result = $"[{DateTime.Now}]:{user.UserName}: {message}"; //string.Format("You entered: {0}", message);

            foreach (var otherUser in _users.Keys)
            {
                //if (otherUser == connection)
                //    continue;
                otherUser.GetMessages(result);
            }

            //OperationContext.Current.GetCallbackChannel<IChatCallBack>().GetMessages(result);
        }
    }
}
