using System;
using System.Windows;
using System.Windows.Input;
using GraduateWorkCompany.Domain.Services;
using GraduateWorkCompany.Pages;
using GraduateWorkCompany.Properties;

namespace GraduateWorkCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ManagerFrame.Frame = MainFrame;
            ManagerFrame.MenuFrame = MenuFrame;
            if (Settings.Default.ClientId == Guid.Empty)
                ManagerFrame.Frame.Navigate(new AuthorizationPage());
            else
            {
                ManagerFrame.Frame.Navigate(new TimetablePage());
                ManagerFrame.MenuFrame.Navigate(new ClientMenuPage());
            }
        }
    }
}
