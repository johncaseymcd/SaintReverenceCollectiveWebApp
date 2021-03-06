using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SaintReverenceMVC.Data
{
    public partial class src_backendContext : DbContext
    {
        public src_backendContext()
        {
        }

        public src_backendContext(DbContextOptions<src_backendContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoicesProduct> InvoicesProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersProduct> OrdersProducts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:SaintReverenceDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories", "products");

                entity.Property(e => e.CategoryID).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.ToTable("Collections", "products");

                entity.Property(e => e.CollectionID).HasColumnName("collectionID");

                entity.Property(e => e.CollectionDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("collectionDescription");

                entity.Property(e => e.CollectionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("collectionName");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publishDate");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers", "users");

                entity.Property(e => e.CustomerID)
                    .HasColumnName("customerID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerAddressCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customerAddressCity");

                entity.Property(e => e.CustomerAddressCountry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("customerAddressCountry");

                entity.Property(e => e.CustomerAddressLine1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("customerAddressLine1");

                entity.Property(e => e.CustomerAddressLine2)
                    .HasMaxLength(255)
                    .HasColumnName("customerAddressLine2");

                entity.Property(e => e.CustomerAddressLine3)
                    .HasMaxLength(255)
                    .HasColumnName("customerAddressLine3");

                entity.Property(e => e.CustomerAddressPostalCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("customerAddressPostalCode");

                entity.Property(e => e.CustomerAddressStateOrProvince)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("customerAddressStateOrProvince");

                entity.Property(e => e.CustomerBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("customerBirthday");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customerEmail");

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customerFirstName");

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customerLastName");

                entity.Property(e => e.CustomerMiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("customerMiddleName");

                entity.Property(e => e.CustomerOrderCount).HasColumnName("customerOrderCount");

                entity.Property(e => e.CustomerOrderTotal)
                    .HasColumnType("money")
                    .HasColumnName("customerOrderTotal");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("customerPhone");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "users");

                entity.Property(e => e.EmployeeID)
                    .HasColumnName("employeeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.EmployeeAddressCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("employeeAddressCity");

                entity.Property(e => e.EmployeeAddressCountry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employeeAddressCountry");

                entity.Property(e => e.EmployeeAddressLine1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("employeeAddressLine1");

                entity.Property(e => e.EmployeeAddressLine2)
                    .HasMaxLength(255)
                    .HasColumnName("employeeAddressLine2");

                entity.Property(e => e.EmployeeAddressLine3)
                    .HasMaxLength(255)
                    .HasColumnName("employeeAddressLine3");

                entity.Property(e => e.EmployeeAddressPostalCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("employeeAddressPostalCode");

                entity.Property(e => e.EmployeeAddressStateOrProvince)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("employeeAddressStateOrProvince");

                entity.Property(e => e.EmployeeBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("employeeBirthday");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeEmail");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("employeeFirstName");

                entity.Property(e => e.EmployeeHoursPerWeek).HasColumnName("employeeHoursPerWeek");

                entity.Property(e => e.EmployeeIsActive).HasColumnName("employeeIsActive");

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("employeeLastName");

                entity.Property(e => e.EmployeeMiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("employeeMiddleName");

                entity.Property(e => e.EmployeePermissionLevel).HasColumnName("employeePermissionLevel");

                entity.Property(e => e.EmployeePhone)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("employeePhone");

                entity.Property(e => e.EmployeeSalaryPerYear)
                    .HasColumnType("money")
                    .HasColumnName("employeeSalaryPerYear");

                entity.Property(e => e.EmployeeSsnhash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("employeeSSNHash");

                entity.HasOne(d => d.EmployeePermissionLevelNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeePermissionLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Permissions");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoices", "finances");

                entity.Property(e => e.InvoiceID)
                    .HasColumnName("invoiceID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdditionalFees)
                    .HasColumnType("money")
                    .HasColumnName("additionalFees");

                entity.Property(e => e.CostOfProducts)
                    .HasColumnType("money")
                    .HasColumnName("costOfProducts");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dueDate");

                entity.Property(e => e.InvoiceIsPaid).HasColumnName("invoiceIsPaid");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingPaid)
                    .HasColumnType("money")
                    .HasColumnName("shippingPaid");

                entity.Property(e => e.TaxPaid)
                    .HasColumnType("money")
                    .HasColumnName("taxPaid");

                entity.Property(e => e.VendorID).HasColumnName("vendorID");

                entity.HasOne(d => d.VendorNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.VendorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Vendors");
            });

            modelBuilder.Entity<InvoicesProduct>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceID, e.ProductID })
                    .HasName("PK__Invoices__A0834C185010B855");

                entity.ToTable("InvoicesProducts", "joiner");

                entity.Property(e => e.InvoiceID).HasColumnName("invoiceID");

                entity.Property(e => e.ProductID).HasColumnName("productID");

                entity.HasOne(d => d.InvoiceNavigation)
                    .WithMany(p => p.InvoicesProducts)
                    .HasForeignKey(d => d.InvoiceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicesProducts_Invoices");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.InvoicesProducts)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoicesProducts_Products");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "finances");

                entity.Property(e => e.OrderID)
                    .HasColumnName("orderID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerID).HasColumnName("customerID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderStatus).HasColumnName("orderStatus");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.Property(e => e.PackageID).HasColumnName("packageID");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shippedDate");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Statuses");

                entity.HasOne(d => d.PackageNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PackageID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Package");
            });

            modelBuilder.Entity<OrdersProduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderID, e.ProductID })
                    .HasName("PK__OrdersPr__BAD83E69C1087E8C");

                entity.ToTable("OrdersProducts", "joiner");

                entity.Property(e => e.OrderID).HasColumnName("orderID");

                entity.Property(e => e.ProductID).HasColumnName("productID");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersProducts_Orders");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.OrdersProducts)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersProducts_Products");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Packages", "products");

                entity.Property(e => e.PackageID).HasColumnName("packageID");

                entity.Property(e => e.PackageCostToShip)
                    .HasColumnType("money")
                    .HasColumnName("packageCostToShip");

                entity.Property(e => e.PackageHeightInCentimeters)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("packageHeightInCentimeters");

                entity.Property(e => e.PackageLengthInCentimeters)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("packageLengthInCentimeters");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("packageName");

                entity.Property(e => e.PackageWeightInGrams)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("packageWeightInGrams");

                entity.Property(e => e.PackageWidthInCentimeters)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("packageWidthInCentimeters");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionLevel)
                    .HasName("PK__Permissi__31CF9B415282F1CB");

                entity.ToTable("Permissions", "helper");

                entity.Property(e => e.PermissionLevel).HasColumnName("permissionLevel");

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("permissionName");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "products");

                entity.Property(e => e.ProductID).HasColumnName("productID");

                entity.Property(e => e.CategoryID).HasColumnName("categoryID");

                entity.Property(e => e.CollectionID).HasColumnName("collectionID");

                entity.Property(e => e.PackageID).HasColumnName("packageID");

                entity.Property(e => e.ProductBuyCost)
                    .HasColumnType("money")
                    .HasColumnName("productBuyCost");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("productDescription");

                entity.Property(e => e.ProductInventoryCount).HasColumnName("productInventoryCount");

                entity.Property(e => e.ProductIsActive).HasColumnName("productIsActive");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductSellPrice)
                    .HasColumnType("money")
                    .HasColumnName("productSellPrice");

                entity.Property(e => e.ProductTurnaroundTime).HasColumnName("productTurnaroundTime");

                entity.Property(e => e.ProductWeightInGrams)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("productWeightInGrams");

                entity.Property(e => e.VendorID).HasColumnName("vendorID");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.CollectionNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CollectionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Collections");

                entity.HasOne(d => d.PackageNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PackageID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Packages");

                entity.HasOne(d => d.VendorNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Vendors");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Statuses", "helper");

                entity.Property(e => e.StatusID).HasColumnName("statusID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("statusName");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendors", "products");

                entity.Property(e => e.VendorID).HasColumnName("vendorID");

                entity.Property(e => e.VendorAddressCity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressCountry)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressLine1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressLine3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressPostalcode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VendorAddressStateOrProvince)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VendorEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vendorName");

                entity.Property(e => e.VendorPhone)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VendorWebsite)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
