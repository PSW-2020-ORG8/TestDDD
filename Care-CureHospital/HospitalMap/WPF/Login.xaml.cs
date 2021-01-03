using HospitalMap.Code.Controller;
using HospitalMap.Code.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Backend;
using Backend.Service.UsersServices;
using Service.UsersServices;
using WebAppPatient.Dto;
using WebAppPatient.Mapper;
using System.Linq;
using Model.AllActors;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ObservableCollection<LoginModel> logins = new LoginController().GetAllLogins();
        public static int role=0;
        

        public Login()
        {
            
            InitializeComponent();

        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Password;
            errorCredentials.Visibility = Visibility.Hidden;
            errorRoles.Visibility = Visibility.Hidden;

            if (_role.SelectedIndex == -1) {
                errorRoles.Visibility = Visibility.Visible;
                return;
            }

            if (_role.SelectedIndex == 1)
            {
                List<Patient> _listOFPatients = new List<Patient>();
                Backend.App.Instance().PatientService.GetAllEntities().ToList().ForEach(patient => _listOFPatients.Add(patient));
                foreach (Patient patient in _listOFPatients)
                {
                    if (usernameBox.Text.Equals(patient.Username) && passwordBox.Password.Equals(patient.Password))
                    {
                        role = 2;
                        MainWindow mainWindow = new MainWindow(3);
                        mainWindow.Show();
                        this.Close();
                    }
                }
                errorCredentials.Visibility = Visibility.Visible;
            }

            if (_role.SelectedIndex == 0)
            {
                List<Doctor> _listOfDoctors = new List<Doctor>();
                Backend.App.Instance().DoctorService.GetAllEntities().ToList().ForEach(patient => _listOfDoctors.Add(patient));
                foreach (Doctor doctor in _listOfDoctors)
                {
                    if (usernameBox.Text.Equals(doctor.Username) && passwordBox.Password.Equals(doctor.Password))
                    {
                        role = 1;
                        MainWindow mainWindow = new MainWindow(3);
                        mainWindow.Show();
                        this.Close();
                    }
                }
                errorCredentials.Visibility = Visibility.Visible;
            }
            
            if (_role.SelectedIndex == 2)
            {
                List<Secretary> _listOfSecretary = new List<Secretary>();
                Backend.App.Instance().SecretaryService.GetAllEntities().ToList().ForEach(patient => _listOfSecretary.Add(patient));
                foreach (Secretary secretary in _listOfSecretary)
                {
                    if (usernameBox.Text.Equals(secretary.Username) && passwordBox.Password.Equals(secretary.Password))
                    {
                        role = 4;
                        MainWindow mainWindow = new MainWindow(3);
                        mainWindow.Show();
                        this.Close();
                    }
                }
                errorCredentials.Visibility = Visibility.Visible;
            }
            
            if (_role.SelectedIndex == 3)
            {
                List<Manager> _listOfManagers = new List<Manager>();
                Backend.App.Instance().ManagerService.GetAllEntities().ToList().ForEach(patient => _listOfManagers.Add(patient));
                foreach (Manager manager in _listOfManagers)
                {
                    if (usernameBox.Text.Equals(manager.Username) && passwordBox.Password.Equals(manager.Password))
                    {
                        role = 3;
                        MainWindow mainWindow = new MainWindow(3);
                        mainWindow.Show();
                        this.Close();
                    }
                }
                errorCredentials.Visibility = Visibility.Visible;
            }
            



        }


    }
}
