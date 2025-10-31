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
        Doctor doctor = new Doctor();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = doctor;
        }

        private void RegisterNewDoctor(object sender, RoutedEventArgs e)
        {
            if (doctor.Password == doctor.RepeatPassword)
            {
                doctor.ID = GenerateUniqueId();

                string jsonString = JsonSerializer.Serialize(doctor);
                string fileName = $"D_{doctor.ID.ToString().PadLeft(5,'0')}.json";
                File.WriteAllText(fileName, jsonString);

                MessageBox.Show("Успешно сохранен");
            }
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }


        private string GenerateUniqueId()
        {
            int i = 1;
            while (i <= 99999)
            {
                if (!File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                {
                    return $"{i.ToString().PadLeft(5,'0')}.json";
                }
                i++;
            }
            return "";
        }
    }
}