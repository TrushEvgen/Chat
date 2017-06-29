using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract =typeof(IChatCallBack))]
    public interface IChat
    {
        [OperationContract(IsOneWay =true)]
        void Send (string message);

        [OperationContract(IsOneWay =true)]
        void Join(User user);

        [OperationContract(IsOneWay = true)]
        void Leave(User user);
    }

    public interface IChatCallBack
    {
        [OperationContract(IsOneWay =true)]
        void GetMessages(string text);

        [OperationContract(IsOneWay = true)]
        void GetUserList(List<string> users);
    }
    
}
