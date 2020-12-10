﻿using System;
using DevExpress.Xpo;
using XafSolution.Module.BusinessObjects;
using Xamarin.Forms;

using XamarinFormsDemo.ViewModels;

namespace XamarinFormsDemo.Views {
    public partial class ItemDetailPage : ContentPage {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage() {
            InitializeComponent();
            viewModel = new ItemDetailViewModel(new Guid());
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel) {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
            viewModel.Navigation = Navigation;
        }
        
    }
}
