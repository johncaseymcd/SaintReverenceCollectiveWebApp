using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CollectionId { get; set; }
        [Required, MaxLength(100)]
        public string CollectionName { get; set; }
        [MaxLength(1000)]
        public string CollectionDescription { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
