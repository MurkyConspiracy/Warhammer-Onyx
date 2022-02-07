using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Warhammer_Onyx
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLHandler wfrpSQLConnection;
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void uxMainButton_Click(object sender, RoutedEventArgs e)
        {
            var loginDiag = new LoginDialog();
            var loginRes = await loginDiag.ShowAsync();
            if(loginRes == ContentDialogResult.Primary)
            {
                wfrpSQLConnection = loginDiag.SQLHandler;
            }
            if (wfrpSQLConnection == null)
                return;
            if(wfrpSQLConnection.TestConnection())
            {
                await new MessageDialog("Connection Establsihed!").ShowAsync();
            }



        }
    }
}
