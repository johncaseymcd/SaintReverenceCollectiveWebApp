namespace SaintReverenceMVC.Models.PackageModels
{
    public class PackageDetail
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public decimal PackageWeightInGrams { get; set; }
        public string PackageDimensionsInCentimeters { get; set; }
        public decimal PackageCostToShip { get; set; }
    }
}