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
using System.IO;
namespace Greeting_Card
{
    /// <summary>
    /// Interaction logic for MainWindow..xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickChangeBackGround(object sender, RoutedEventArgs e)
        {
            //ImageBrush myBrush = new ImageBrush();
            //myBrush.ImageSource =
            //  new BitmapImage(new Uri(@"C:\Users\pragnesh\Desktop\images\smokeffect.jpg"));
            //this.Background = myBrush;
            Stream checkStream = Stream.Null;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Multiselect = false;
            //openFileDialog.InitialDirectory = "c:\\";
            //if you want filter only .txt file
            //dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            //if you want filter all files           
            openFileDialog.Filter = "All Image Files | *.*";

            if (Convert.ToBoolean(openFileDialog.ShowDialog()))
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        ImageBrush mybrush = new ImageBrush();
                        mybrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        //listBox1.Items.Add(openFileDialog.FileName);
                        this.Background = mybrush;
                    }
                    MessageBox.Show("Successfully done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Problem occured, try again later");
            }
        }

        private void OnClickSaveImage(object sender, RoutedEventArgs e)
        {
            Stream checkStream = Stream.Null;
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Multiselect = false;
            //openFileDialog.InitialDirectory = "c:\\";
            //if you want filter only .txt file
            //dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            //if you want filter all files           
            openFileDialog.Filter = "All Image Files | *.*";

            if (Convert.ToBoolean(openFileDialog.ShowDialog()))
            {
                try
                {
                    if ((checkStream = openFileDialog.OpenFile()) != null)
                    {
                        //logo1.Visibility = Visibility.Visible;
                        logo1.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                        //listBox1.Items.Add(openFileDialog.FileName);

                        MessageBox.Show("Successfully done");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Problem occured, try again later");
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result =Convert.ToBoolean( MessageBox.Show("Do you want to save file?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question)); 
            if (result)

            {
                try
                {
                    if (txtbox_name.Text != null && txtbox_address.Text != null && txtbox_mobile.Text != null&& txtbox_emailid!=null)
                    {
                        saveFile(txtbox_name.Text, txtbox_address.Text, txtbox_mobile.Text, txtbox_emailid.Text);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }
        public void saveFile(string name, string address, string telephone,string emailid)
        {
            string Msg = name + ";" + address +";"+ telephone + ";" + emailid;
            //String File_name = @"C:\Greeting Card\bin\sample.txt";
            String File_name = @"C:\Users\pragnesh\source\repos\Greeting Card\sample.txt";
            if (System.IO.File.Exists(File_name) == true)
            {
                FileStream fs = new FileStream(File_name, FileMode.Append, FileAccess.Write);
                StreamWriter objWrite = new StreamWriter(fs);
                objWrite.Write(Msg);
                objWrite.Write(Environment.NewLine);
                objWrite.Close();
            }
            else
            {
                FileStream fs = new FileStream(File_name, FileMode.Create, FileAccess.Write);
                StreamWriter objWrite = new StreamWriter(fs);
                objWrite.Write(Msg);
                objWrite.Write(Environment.NewLine);
                objWrite.Close();
            }
           }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 
