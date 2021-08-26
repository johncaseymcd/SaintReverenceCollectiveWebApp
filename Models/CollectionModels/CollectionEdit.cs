using System;

namespace SaintReverenceMVC.Models.CollectionModels
{
    public class CollectionEdit
    {
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public string CollectionDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}