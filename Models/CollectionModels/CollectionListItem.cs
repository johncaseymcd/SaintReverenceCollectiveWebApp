using System;

namespace SaintReverenceMVC.Models.CollectionModels
{
    public class CollectionListItem
    {
        public string CollectionName { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}