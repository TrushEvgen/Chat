using ChatClientWPF.ChatWCFService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClientWPF
{
    public class ChatModel : INotifyPropertyChanged
    {

        private ChatClient host;

        public ChatClient Host
        {
            get { return host; }
            set { host = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private ObservableCollection<User> userList;

        public ObservableCollection<User> UserList
        {
            get { return userList ?? (userList = new ObservableCollection<User>()); }
            set
            {
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }
    }
}
