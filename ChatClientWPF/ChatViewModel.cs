using ChatClientWPF.ChatWCFService;
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
        
        public ChatViewModel()
        {
            host = new ChatClient(new System.ServiceModel.InstanceContext(this), "NetTcpBinding_IChat");
            
            Host.Join(new User() { UserName = "Admin" });
            UserList.CollectionChanged += MessageList_CollectionChanged;          
        }

        private void MessageList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
          
        }

        private FlowDocument mainChatText = new FlowDocument();

        public FlowDocument MainChatText
        {
            get { return mainChatText; }
            //set
            //{
            //    mainChatText.AppendLine(value);
            //    OnPropertyChanged(nameof(MainChatText));
            //}
        }
         public void Click(string text)
        {       
               
            Paragraph newText = new Paragraph(new Run(text));
            mainChatText.Blocks.Add(newText);
            OnPropertyChanged(nameof(MainChatText));
        }
        private ChatClient host;

        public ChatClient Host
        {
            get { return host; }
            set { host = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void GetMessages(User user, string text)
        {
            MessageList.Add(new Message(text,user));
            //OnPropertyChanged(nameof(MessageList)); 
        }

        public void GetUserList(User[] users)
        {
            foreach (User item in users)
                UserList.Add(item);
        }

        public void UserJoined(User user)
        {
            UserList.Add(user);
            MessageList.Add(new Message($"Пользователь {user.UserName} подключился"));
            //GetUserList(UserList.ToArray());
            //OnPropertyChanged(nameof(UserList));
            //Click(user.UserName);
        }

        public void UserLeave(User user)
        {       
            UserList.Remove(user);
            //user.re
            User usr = new User();
            usr.UserGuid = Guid.NewGuid();
            MessageList.Add(new Message($"Пользователь {user.UserName} отключился"));

        }

        public void ReceiveWhisper(User fromUser, string message)
        {
            throw new NotImplementedException();
        }

        //private List<User> userList;

        //public List<User> UserList
        //{
        //    get { return userList; }
        //    set
        //    {
        //        userList = value;
        //        OnPropertyChanged(nameof(UserList));
        //    }
        //}

        //public ObservableCollection<User> UserList = new ObservableCollection<User>();

        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get { return userList ?? (userList = new ObservableCollection<User>()); }
            set { userList = value; }
        }

        private ObservableCollection<Message> messageList;

        public ObservableCollection<Message> MessageList
        {
            get { return messageList ?? (messageList = new ObservableCollection<Message>()); }
            set { messageList = value; }
        }


    }
}
