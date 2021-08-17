﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void SetUp()
        {
            SaintSender.Core.Models.EmailConnection.SetUp();
        }

        public void ListEmails()
        {
            SaintSender.Core.Models.Inbox.ListMails();
        }
    }
}