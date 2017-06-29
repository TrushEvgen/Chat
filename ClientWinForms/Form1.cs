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

namespace ClientWinForms
{
    public partial class Form1 : Form, ChatService.IChatCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChatService.ChatClient chatClient = null;

        InstanceContext instanceContext = null;

        public string UserName { get; private set; }
        ChatService.User User = new ChatService.User();

        private void Form1_Load(object sender, EventArgs e)
        {
            UserNameForm unf = new UserNameForm();
            unf.ShowDialog();

            User.UserName = unf.User;
            instanceContext = new InstanceContext(this);
            chatClient = new ChatService.ChatClient(instanceContext, "NetTcpBinding_IChat");
            chatClient.Join(User);
          
            


        }

        public void GetMessages(string text)
        {
            richTextBox1.Text += $"{Environment.NewLine} {text}";
        }

        private void btn_SendMessage_Click(object sender, EventArgs e)
        {
            chatClient.Send(textBox1.Text);
        }

        public void GetUserList(string[] users)
        {
            throw new NotImplementedException();
        }
    }
}
