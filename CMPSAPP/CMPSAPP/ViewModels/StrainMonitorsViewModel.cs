using CMPSAPP.Models;
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
    public class StrainMonitorsViewModel : StrainMonitorsBaseViewModel
    {
        public ObservableCollection<StrainMonitor> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        //public StrainMonitorsViewModel()
        //{
        //    Title = "StrainMonitors Browse";
        //    Items = new ObservableCollection<StrainMonitor>();
        //    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        //    //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
        //    //{
        //    //    var newItem = item as Item;
        //    //    Items.Add(newItem);
        //    //    await DataStore.AddItemAsync(newItem);
        //    //});
        //}

        public StrainMonitorsViewModel(Guid Id)
        {
            Title = "查看应变";
            Items = new ObservableCollection<StrainMonitor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(Id));

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

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
    }
}
