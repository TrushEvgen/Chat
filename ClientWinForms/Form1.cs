using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientWinForms.ChatService;

namespace ClientWinForms
{
    public partial class Form1 : Form, ChatService.IChatCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer checkCommunicationState = new Timer();        

        private ChatClient chatClient;

        public ChatClient ChatClient
        {
            get
            {
                if (chatClient == null)
                    return null;
                switch (chatClient.State)
                {
                    case CommunicationState.Created:
                        break;
                    case CommunicationState.Opened:
                        return chatClient;
                    case CommunicationState.Closed:
                    case CommunicationState.Faulted:                        
                        chatClient = null;
                        checkCommunicationState.Stop();                    
                        break;
                }               
                return chatClient;
            }
            set { chatClient = value; }
        }


        InstanceContext instanceContext = null;

        public string UserName { get; private set; }
        ChatService.User User = new ChatService.User();

        private void Form1_Load(object sender, EventArgs e)
        {
            UserNameForm unf = new UserNameForm();
            unf.ShowDialog();

            User.UserName = unf.User;
            instanceContext = new InstanceContext(this);
            ChatClient = new ChatService.ChatClient(instanceContext, "NetTcpBinding_IChat");

            checkCommunicationState.Interval = 10 * 1000;
            checkCommunicationState.Tick += delegate
            {
                if (ChatClient != null)
                {
                    if (ChatClient.State == CommunicationState.Closed || ChatClient.State == CommunicationState.Faulted)
                    {
                        richTextBox1.AppendText($"{Environment.NewLine} Соединение разорвано");
                        checkCommunicationState.Stop();
                    }
                }
            };
            checkCommunicationState.Start();
            ChatClient?.Join(User);

            FormClosing += delegate { ChatClient?.Leave(User); chatClient?.Close(); };        
        }

       

        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            if (ChatClient != null)
            {
                ChatClient?.Send(textBox1.Text);
                textBox1.Text = string.Empty;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_SendMessage_Click(null, null);
                e.Handled = false;
            }
            
        }

        public void GetMessages(User user, string text)
        {
            richTextBox1.Text += $"{Environment.NewLine} [{DateTime.Now}]: [{user.UserName}] {text}";
        }
        
        public void ReceiveWhisper(User fromUser, string message)
        {
            throw new NotImplementedException();
        }

        public void GetUserList(User[] users)
        {
            foreach (User usr in users)
            {
                UserList.Items.Add(usr.UserName);
            }
        }

        public void UserJoined(User user)
        {
            richTextBox1.Text += $"{Environment.NewLine} Пользователь {user.UserName} подключился";
            UserList.Items.Add(user.UserName);

        }

        public void UserLeave(User user)
        {
            richTextBox1.Text += $"{Environment.NewLine} Пользователь {user.UserName} отключился";
            UserList.Items.Remove(user.UserName);

        }
    }
}
