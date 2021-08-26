using System.ComponentModel.DataAnnotations;

namespace SaintReverenceMVC.Models.PackageModels
{
    public class PackageCreate
    {
        [Required, MaxLength(100)]
        public string PackageName { get; set; }
        [Required]
        public decimal PackageWeightInGrams { get; set; }
        [Required]
        public decimal PackageHeightInCentimeters { get; set; }
        [Required]
        public decimal PackageWidthInCentimeters { get; set; }
        [Required]
        public decimal PackageLengthInCentimeters { get; set; }
        [Required]
        public decimal PackageCostToShip { get; set; }
    }
}