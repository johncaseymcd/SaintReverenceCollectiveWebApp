using System;
using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.CollectionModels
{
    public class CollectionCreate
    {
        [Required, MaxLength(100)]
        public string CollectionName { get; set; }
        [MaxLength(1000)]
        public string CollectionDescription { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}