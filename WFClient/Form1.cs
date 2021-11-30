using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationClassLibrary;
using CommunicationClassLibrary.Entities;

namespace WFClient
{
    public partial class Form1 : Form
    {
        Msg msg = null;

        ClientManager client = new ClientManager();

        public Form1()
        {
            InitializeComponent();

            client.Connect();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxCommand.Text == "exit")
            {
                msg = new Msg()
                {
                    Message = "exit"
                };
                client.SendMsgToServer(msg);

                Environment.Exit(0);
            }

            msg = new Msg()
            {
                Message = textBoxCommand.Text
            };
            client.SendMsgToServer(msg);

            buttonEnter.Enabled = false;
            textBoxCommand.Enabled = false;

            Task.Run(() =>
            {
                msg = client.RecieveMsgFromServer();
                this.Invoke(new MethodInvoker(() =>
                    {
                        listBoxOut.Items.Add(msg.Message);

                        buttonEnter.Enabled = true;
                        textBoxCommand.Enabled = true;

                        textBoxCommand.Clear();
                        textBoxCommand.Focus();
                    }
                ));
            });

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            msg = new Msg()
            {
                Message = "exit"
            };
            client.SendMsgToServer(msg);
        }

        private void textBoxCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonEnter_Click(sender, e);
            }
            //else if(e.KeyChar == 38)
            //{
            //    textBoxCommand.Text = listBoxOut.Items[listBoxOut.Items.Count-1].ToString();
            //}
        }
    }
}
