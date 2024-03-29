﻿using CMPSAPP.Models;
using CMPSAPP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CMPSAPP.ViewModels
{
    public class CoordinateMonitorsViewModel : MonitorsBaseViewModel<CoordinateMonitor>
    {
        public ObservableCollection<CoordinateMonitor> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        //public CoordinateMonitorsViewModel()
        //{
        //    Title = "CoordinateMonitors Browse";
        //    Items = new ObservableCollection<CoordinateMonitor>();
        //    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        //    //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
        //    //{
        //    //    var newItem = item as Item;
        //    //    Items.Add(newItem);
        //    //    await DataStore.AddItemAsync(newItem);
        //    //});
        //}

        public CoordinateMonitorsViewModel(Guid Id)
        {
            Title = "查看坐标";
            Items = new ObservableCollection<CoordinateMonitor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Id));

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        public CoordinateMonitorsViewModel(Guid Id, string No, DateTime? StartDateTime, DateTime? EndDateTime)
        {
            Title = "查看坐标";
            Items = new ObservableCollection<CoordinateMonitor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Id, No, StartDateTime, EndDateTime));

        }
        async Task ExecuteLoadItemsCommand(Guid Id)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(Id,true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadItemsCommand(Guid Id, string No, DateTime? StartDateTime, DateTime? EndDateTime)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(Id, No, StartDateTime, EndDateTime, true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
