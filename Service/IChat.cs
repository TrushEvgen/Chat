﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract(CallbackContract =typeof(IChatCallBack))]
    public interface IChat
    {
        [OperationContract(IsOneWay =true)]
        void Send (string message);

        [OperationContract(IsOneWay =true)]
        void Join(User user);

        [OperationContract(IsOneWay = true)]
        void Whisper(User toUser, string message);

        [OperationContract(IsOneWay = true)]
        void Leave(User user);
    }

    public interface IChatCallBack
    {
        [OperationContract(IsOneWay =true)]
        void GetMessages(User user, string text);

        [OperationContract(IsOneWay = true)]
        void GetUserList(List<User> users);

        [OperationContract(IsOneWay = true)]
        void UserJoined(User user);

        [OperationContract(IsOneWay = true)]
        void UserLeave(User user);

        [OperationContract(IsOneWay =true)]
        void ReceiveWhisper(User fromUser, string message);
    }
    
}
