﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VisualStateManagerDemo
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            UserName.TextChanged += UserName_TextChanged;
            Email.TextChanged += Email_TextChanged;
            Password.TextChanged += Password_TextChanged;
            SubmitButton.Clicked += SubmitButton_Clicked;
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (IsValid())
                DisplayAlert("Welcome", "You've successfuly registered", "OK");
            else
                DisplayAlert("Welcome", "You've still got some fields to correct", "OK");
        }

        bool IsValid()
        {
            var userDetailsValid = CheckUserDetailsValid();
            var emailValid = CheckEmailValid();
            var passwordValid = CheckPasswordValid();

            return emailValid && passwordValid && userDetailsValid;
        }
        

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPasswordValid();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEmailValid();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckUserDetailsValid();
        }

        private bool CheckUserDetailsValid()
        {
            var isValid = (UserName.Text ?? "").Length > 0;

            return isValid;
        }

        private bool CheckEmailValid()
        {
            bool isValid = IsValidEmail(Email.Text);

            return isValid;
        }

        private bool CheckPasswordValid()
        {
            var pwdLength = (Password.Text ?? "").Length;
            bool isValid = pwdLength >= 6;
            return isValid;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
