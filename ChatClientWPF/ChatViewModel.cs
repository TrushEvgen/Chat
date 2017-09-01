using ChatClientWPF.ChatWCFService;
using ChatClientWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ChatClientWPF
{
    public class ChatViewModel : INotifyPropertyChanged,IChatCallback
    {
        private readonly ChatModel _ChatModel;
        public ChatViewModel(ChatModel chatModel)
        {
            _ChatModel = chatModel;
            _ChatModel.Host = new ChatClient(new System.ServiceModel.InstanceContext(this), "NetTcpBinding_IChat");
            _ChatModel.Host.Join(new User() { UserName = "Admin" });
            //host = new ChatClient(new System.ServiceModel.InstanceContext(this), "NetTcpBinding_IChat");
            
            //Host.Join(new User() { UserName = "Admin" });
        }

        public ChatViewModel() : this(new ChatModel())
        {          
        }

        #region Property
        //private ChatClient host;

        //public ChatClient Host
        //{
        //    get { return host; }
        //    set { host = value; }
        //}
        //private ObservableCollection<User> userList;

        //public ObservableCollection<User> UserList
        //{
        //    get { return userList ?? (userList = new ObservableCollection<User>()); }
        //    set { userList = value; }
        //}

        private ObservableCollection<Message> messageList;

        public ObservableCollection<Message> MessageList
        {
            get { return messageList ?? (messageList = new ObservableCollection<Message>()); }
            set { messageList = value; }
        }

        private RelayCommand _sendMessage;

        public RelayCommand SendMessage
        {
            get
            {
                return _sendMessage ??
                    (_sendMessage = new RelayCommand(SendMessageClick));
            }
        }

        private string _messageString;

        public string MessageString
        {
            get { return _messageString; }
            set { _messageString = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        public void GetMessages(User user, string text)
        {
            MessageList.Add(new Message(text,user));
            //OnPropertyChanged(nameof(MessageList)); 
        }

        public void GetUserList(User[] users)
        {
            foreach (User item in users)
                _ChatModel.UserList.Add(item);
        }

        public void UserJoined(User user)
        {
            _ChatModel.UserList.Add(user);
            MessageList.Add(new Message($"Пользователь {user.UserName} подключился"));
            //GetUserList(UserList.ToArray());
            //OnPropertyChanged(nameof(UserList));
            //Click(user.UserName);
        }

        public void UserLeave(User user)
        {
            User userFromList = null;
            userFromList = _ChatModel.UserList.Where(x => x.UserName == user.UserName).FirstOrDefault();
            _ChatModel.UserList.Remove(userFromList);    
            MessageList.Add(new Message($"Пользователь {user.UserName} отключился"));
        }

        public void ReceiveWhisper(User fromUser, string message)
        {
            throw new NotImplementedException();
        }

    

        private void SendMessageClick(object message)
        {
            if (_ChatModel.Host.State == System.ServiceModel.CommunicationState.Opened)
            {
                _ChatModel.Host.Send(MessageString);
                MessageString = string.Empty;
                OnPropertyChanged(nameof(MessageString));
            }
        }
    }
}
