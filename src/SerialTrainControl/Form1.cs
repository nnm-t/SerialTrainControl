/*
Serial Train Control

Copyright (c) 2015 Noname Kamisawa


This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace SerialTrainControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //シリアルポート名を配列で取得
            string[] portList = SerialPort.GetPortNames();
            //ポート名のコンボボックスを初期化して入力
            numberComboBox.Items.Clear();
            foreach (string portName in portList)
            {
                numberComboBox.Items.Add(portName);
            }
            if (numberComboBox.Items.Count > 0)
            {
                numberComboBox.SelectedIndex = 0;
            }
            //通信速度選択を入力(手動設定可能)
            baudComboBox.Items.Clear();
            baudComboBox.Items.Add(300);
            baudComboBox.Items.Add(1200);
            baudComboBox.Items.Add(2400);
            baudComboBox.Items.Add(4800);
            baudComboBox.Items.Add(9600);
            baudComboBox.Items.Add(19200);
            baudComboBox.Items.Add(38400);
            baudComboBox.Items.Add(57600);
            baudComboBox.Items.Add(115200);
            baudComboBox.Items.Add(230400);
            baudComboBox.Items.Add(250000);
            baudComboBox.SelectedIndex = 8;
            //テキストを消す
            sendText.Clear();
            receiveText.Clear();
            //SWF読み込み
            flash.LoadMovie(0, Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "controller.swf");
            //Flashからのデータ受信
            flash.FSCommand += onFSCommand;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            //接続
            //シリアルポートを開ける
            //ポート名とボーレートを設定
            serial.PortName = numberComboBox.SelectedItem.ToString();
            serial.BaudRate = int.Parse(baudComboBox.SelectedItem.ToString());
            setBaud(baudComboBox.SelectedItem.ToString());
            //データビット設定
            serial.DataBits = 8;
            //パリティビットを設定
            serial.Parity = Parity.None;
            //ストップビットを設定
            serial.StopBits = StopBits.One;
            //フロー制御を設定
            serial.Handshake = Handshake.None;
            //文字コードを設定
            serial.Encoding = Encoding.ASCII;
            try
            {
                //シリアルポートをオープン
                serial.Open();
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;
                sendButton.Enabled = true;
                receiveText.AppendText("Serial Connection Success." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //例外を拾った
                receiveText.AppendText("Serial Connection Failed:" + Environment.NewLine + ex.Message);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            //切断
            //シリアルポートを閉じる
            serial.Close();
            setBaud("0");
            connectButton.Enabled = true;
            disconnectButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //送信
            //空でないことをチェック
            if (string.IsNullOrEmpty(sendText.Text) == false)
            {
                try
                {
                    //シリアルデータを送信
                    serial.Write(sendText.Text);
                    sendText.Clear();
                }
                catch (Exception ex)
                {
                    //例外を拾った
                    receiveText.AppendText("Data Transmission Failed:" + Environment.NewLine + ex.Message);
                }
            }
        }

        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //データ受信時
            //シリアルポートが開いている時のみ
            if (serial.IsOpen == true)
            {
                try
                {
                    //シリアルデータを受信
                    string data = serial.ReadExisting();
                    Invoke(new Delegate_ReceiveData2TextBox(ReceiveData2TextBox), new Object[] { data });
                }
                catch (Exception ex)
                {
                    //例外を拾った
                    receiveText.AppendText("Data Receive Failed:" + Environment.NewLine + ex.Message);
                }
            }
        }

        private delegate void Delegate_ReceiveData2TextBox(string data);

        private void ReceiveData2TextBox(string data)
        {
            //受信データをテキストボックスに追加
            if (data != null)
            {
                receiveText.AppendText(data);
            }
        }

        private void flash_Enter(object sender, EventArgs e)
        {

        }

        private void onFSCommand(Object eventSender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent eventArgs)
        {
            if (serial.IsOpen == true)
            {
                //Flashからデータ受信
                try
                {
                    //シリアルデータを送信
                    serial.Write(eventArgs.args);
                    sendText.Clear();
                }
                catch (Exception ex)
                {
                    //例外を拾った
                    receiveText.AppendText("Data Transmission Failed:" + Environment.NewLine + ex.Message);
                }
            }
        }

        private void setBaud(string value)
        {
            //値をFlashに送信
            string request =
                "<invoke name=\"setBaud\" returntype=\"xml\">" +
                "<arguments>" +
                "<string>" + value + "</string>" +
                "</arguments>" +
                "</invoke>";
            Console.WriteLine(request);
            flash.CallFunction(request);
        }
    }
}
