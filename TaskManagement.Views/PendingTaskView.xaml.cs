﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingTaskView : ContentPage
    {
        public PendingTaskView()
        {
            InitializeComponent();
        }
    }
}