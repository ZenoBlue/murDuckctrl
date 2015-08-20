using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace Duckctrl
{
    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.IO.Ports.SerialPort serialPort =new System.IO.Ports.SerialPort();
       private string[] ports = System.IO.Ports.SerialPort.GetPortNames();//获得可以使用的串口
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (string port in ports)
            {
                //   this.ComBox.AppendText(port);
               this.comlist.Items.Add(port);
                
                // this.comlist.Focus();

            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (this.openbtn.Content.ToString() == "open")
            {
                if (this.comlist.Text.Length != 0)
                {
                    this.openbtn.Content = "close";
                    serialPort.PortName = this.comlist.SelectedItem.ToString();
                    this.comlist.Focus();
                  
                    //  serialPort.PortName = this.ComBox.Text.ToString();
                    serialPort.BaudRate = 9600;
                    serialPort.Parity = Parity.None;
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Open();
                }
            }
            else
            {
                this.openbtn.Content = "open";
                this.serialPort.Close();
            }

        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                MessageBox.Show("请先打开串口！");
            }
            else 
            {
                try
                {
                    serialPort.Write("00000001");

                }
                catch (Exception error)
                {
                    MessageBox.Show("error" + error.ToString());
                }
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.DiscardOutBuffer();//清空发送缓存
                    serialPort.DiscardInBuffer();//清空接收缓存
                }
                else
                {
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.serialPort.Close();
            this.Close();
        }

        private void minbtn_Click(object sender, RoutedEventArgs e) //最小化 按钮
        {
            this.WindowState = WindowState.Minimized;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) //拖动窗体
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
