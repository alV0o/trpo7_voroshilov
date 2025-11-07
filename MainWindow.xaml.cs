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
        Patient addPatient = new Patient();
        Patient updatePatient = new Patient();
        JSONs jsons = new JSONs();

        public MainWindow()
        {
            InitializeComponent();
            RegisterDoctor.DataContext = regDoctor;
            LoginDoctor.DataContext = loadDoctor;
            InfoDoctor.DataContext = loadDoctor;
            AddPatient.DataContext = addPatient;
            UpdatePatient.DataContext = updatePatient;
            Appointment.DataContext = updatePatient;


            int i = 1;
            while (i <= 9999999)
            {
                if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                {
                    jsons.CountDoctors++;
                }
                if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                {
                    jsons.CountPatients++;
                }
                i++;
            }
            jsons.CountAll = jsons.CountDoctors + jsons.CountPatients;
            StatusBar.DataContext = jsons;
        }

        private void RegisterNewDoctor(object sender, RoutedEventArgs e)
        {
            if (regDoctor.Password.Trim() != ""&& regDoctor.Name.Trim() != "" && regDoctor.LastName.Trim() != "" && regDoctor.Specialisation.Trim() != "" && regDoctor.MiddleName.Trim() != "")
            {
                if (regDoctor.Password == regDoctor.RepeatPassword)
                {

                    regDoctor.ID = Convert.ToInt32(GenerateUniqueId(5, 'D'));
                    string jsonString = JsonSerializer.Serialize(regDoctor);
                    string fileName = $"D_{regDoctor.ID.ToString().PadLeft(5, '0')}.json";
                    File.WriteAllText(fileName, jsonString);

                    //jsons.CountDoctors++;
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


        private string GenerateUniqueId(int countNums, char symbol)
        {
            int i = 1;
            int maxValue = Convert.ToInt32(9.ToString().PadLeft(countNums, '9'));
            while (i <= maxValue)
            {
                if (!File.Exists($"{symbol}_{i.ToString().PadLeft(countNums, '0')}.json"))
                {
                    return i.ToString().PadLeft(countNums,'0');
                }
                i++;
            }
            return "";
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string id = $"D_{loadDoctor.ID.ToString().PadLeft(5,'0')}.json";
            if (File.Exists(id))
            {
                string jsonString = File.ReadAllText(id);

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

        private void AddNewPatient(object sender, RoutedEventArgs e)
        {
            if (addPatient.Name.Trim() != "" && addPatient.LastName.Trim() != "" && addPatient.MiddleName.Trim() != "" && addPatient.Birthday.Trim() != "")
            {
                addPatient.ID = Convert.ToInt32(GenerateUniqueId(7, 'P'));
                
                string jsonString = JsonSerializer.Serialize(addPatient);
                string fileName = $"P_{addPatient.ID.ToString().PadLeft(7, '0')}.json";
                File.WriteAllText(fileName, jsonString);
                //jsons.CountPatients++;

                MessageBox.Show("Успешно сохранен");
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void FindPatient(object sender, RoutedEventArgs e)
        {
            string fileName = $"P_{updatePatient.ID.ToString().PadLeft(7, '0')}.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);

                Patient temp = JsonSerializer.Deserialize<Patient>(jsonString);

                updatePatient.Name = temp.Name;
                updatePatient.LastName = temp.LastName;
                updatePatient.MiddleName = temp.MiddleName;
                updatePatient.Birthday = temp.Birthday;
                updatePatient.LastAppointment = temp.LastAppointment;
                updatePatient.LastDoctor = temp.LastDoctor;
                updatePatient.Diagnosis = temp.Diagnosis;
                updatePatient.Recomendations = temp.Recomendations;
                UpdateLastDoctorObj(updatePatient);

            }
            else
            {
                MessageBox.Show("Такого ID нет");
            }
        }

        private void ResetPatient(object sender, RoutedEventArgs e)
        {
            string fileName = $"P_{updatePatient.ID.ToString().PadLeft(7, '0')}.json";
            string jsonString = File.ReadAllText(fileName);

            Patient temp = JsonSerializer.Deserialize<Patient>(jsonString);

            updatePatient.Name = temp.Name;
            updatePatient.LastName = temp.LastName;
            updatePatient.MiddleName = temp.MiddleName;
            updatePatient.Birthday = temp.Birthday;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            string fileName = $"P_{updatePatient.ID.ToString().PadLeft(7, '0')}.json";
            string jsonString = JsonSerializer.Serialize(updatePatient);
            File.WriteAllText(fileName, jsonString);
        }

        private void UpdateLastDoctorObj(Patient patient)
        {
            string fileName = $"D_{patient.LastDoctor.ToString().PadLeft(5, '0')}.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);

                Doctor temp = JsonSerializer.Deserialize<Doctor>(jsonString);

                patient.LastDoctorObj.Name = temp.Name;
                patient.LastDoctorObj.Password = temp.Password;
                patient.LastDoctorObj.MiddleName = temp.MiddleName;
                patient.LastDoctorObj.LastName = temp.LastName;
                patient.LastDoctorObj.Specialisation = temp.Specialisation;
            }
            else
            {
                patient.LastDoctorObj.Name = "-";
                patient.LastDoctorObj.MiddleName="-";
                patient.LastDoctorObj.LastName = "-";
            }
        }

        private void RegisterAppointment(object sender, RoutedEventArgs e)
        {
            if (loadDoctor.ID != 0)
            {
                updatePatient.LastDoctor = loadDoctor.ID;
                updatePatient.LastAppointment = DateTime.Now.ToString();
                UpdateLastDoctorObj(updatePatient);
                
                string fileName = $"P_{updatePatient.ID.ToString().PadLeft(7, '0')}.json";
                string jsonString = JsonSerializer.Serialize(updatePatient);
                File.WriteAllText(fileName, jsonString);
            }
            else MessageBox.Show("Нужно войти в аккаунт доктора!");
        }
    }
}