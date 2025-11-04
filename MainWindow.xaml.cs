using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace trpo7_voroshilov_pr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Doctor regDoctor = new Doctor();
        Doctor loadDoctor = new Doctor();
        public MainWindow()
        {
            InitializeComponent();
            RegisterDoctor.DataContext = regDoctor;
            LoginDoctor.DataContext = loadDoctor;
            InfoDoctor.DataContext = loadDoctor;
        }

        private void RegisterNewDoctor(object sender, RoutedEventArgs e)
        {
            if (regDoctor.Password.Trim() != ""&& regDoctor.Name.Trim() != "" && regDoctor.LastName.Trim() != "" && regDoctor.Specialisation.Trim() != "" && regDoctor.MiddleName.Trim() != "")
            {
                if (regDoctor.Password == regDoctor.RepeatPassword)
                {

                    regDoctor.ID = Convert.ToInt32(GenerateUniqueId());
                    string jsonString = JsonSerializer.Serialize(regDoctor);
                    string fileName = $"D_{regDoctor.ID.ToString().PadLeft(5, '0')}.json";
                    File.WriteAllText(fileName, jsonString);

                    MessageBox.Show("Успешно сохранен");
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }


        private string GenerateUniqueId()
        {
            int i = 1;
            while (i <= 99999)
            {
                if (!File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                {
                    return i.ToString().PadLeft(5,'0');
                }
                i++;
            }
            return "";
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string id = loadDoctor.ID.ToString().PadLeft(5,'0');
            if (File.Exists($"D_{id}.json"))
            {
                string jsonString = File.ReadAllText($"D_{id}.json");

                Doctor temp = JsonSerializer.Deserialize<Doctor>(jsonString);

                if (temp.Password == loadDoctor.Password)
                {
                    loadDoctor.Name = temp.Name;
                    loadDoctor.Password = temp.Password;
                    loadDoctor.MiddleName = temp.MiddleName;
                    loadDoctor.LastName = temp.LastName;
                    loadDoctor.Specialisation = temp.Specialisation;
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Такого ID нет");
            }
        }
    }
}