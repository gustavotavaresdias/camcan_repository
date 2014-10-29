﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using CamCan.CamCanService;
using Microsoft.Phone.Shell;

namespace CamCan
{
    public partial class Login : PhoneApplicationPage
    {
        UserProfile user = new UserProfile();
        String password;


        public Login()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            user.setUsername = txtUser.Text;
            password = txtPass.Text;

            //WebService connection
            Service1Client camcanService = new Service1Client();
            camcanService.returnUserProfile += new EventHandler<returnUserCompletedEventArgs>(camcanService_returnUserProfileCompleted);
            camcanService.returnUserProfileAsync(user.getUsername, password);

        }

        //this is the event handler which is called when the event is triggered
        void camcanService_returnUserProfileCompleted(object sender, returnUserCompletedEventArgs e)
        {
            //adds the information returned in the User class
            user = e.Result;

            if (user.getUsername.Equals("Empty"))
            {

                MessageBox.Show("Invalid Entry! ");

            }
            else
            {
                this.NavigationService.Navigate(new Uri("/Scenarios.xaml?User=" + user, UriKind.Relative));

            }

        }


        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Information.xaml", UriKind.Relative));
        }

    }
}