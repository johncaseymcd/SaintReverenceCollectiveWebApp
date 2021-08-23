using System;
using System.Collections.Generic;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class Collection
    {
        public Collection()
        {
            Products = new HashSet<Product>();
        }

        public int CollectionId { get; set; }
        public string CollectionName { get; set; }
        public string CollectionDescription { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
