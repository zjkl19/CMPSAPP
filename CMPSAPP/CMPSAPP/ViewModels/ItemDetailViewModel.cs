using System;

using CMPSAPP.Models;

namespace CMPSAPP.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Guid CMProjectId{ get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }

        public ItemDetailViewModel(Guid cmprojectId,Item item = null)
        {
            Title = item?.Name;
            Item = item;
            CMProjectId = cmprojectId;
        }
    }
}
