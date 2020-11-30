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

            var item = new Employee(XpoDefault.Session) {
                FirstName = "Item 1",
                LastName = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel) {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void Update_Clicked(object sender, EventArgs e) {
            MessagingCenter.Send(this, "UpdateItem", viewModel.Item);
            await Navigation.PopToRootAsync();
        }
        async void Delete_Clicked(object sender, EventArgs e) {
            if(viewModel.Item != null) {
                var result = await DisplayAlert("Delete", $"Are you sure you want to delete the \"{viewModel.Item.FullName}\" item?", "Yes", "No");
                if(result) {
                    MessagingCenter.Send(this, "DeleteItem", viewModel.Item);
                    await Navigation.PopToRootAsync();
                }
            }
        }
    }
}