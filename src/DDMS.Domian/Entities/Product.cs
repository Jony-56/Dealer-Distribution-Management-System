using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Product:AuditableEntity
    {
        private readonly List<ProductPriceHistory> _productPriceHistories = new();
        private readonly List<StockEntryItem> _stockEntryItems = new();
        private readonly List<DispatchItem> _dispatchItems = new();
        private readonly List<DailyClosingItem> _dailyColosingItems = new();
        private readonly List<StockAdjustment> _stockAdjustments = new();

        private Product() { }

        private Product ( 
            Guid brandId,
            Guid productGroupId,
            string name,
            string? description,
            string sku,
            string barcode ,
            int piecesPerCarton,
            decimal sellingPrice,
            int minimumStock,
            string? imageUrl
           
            )
        {
            BrandId = brandId;
            ProductGroupId = productGroupId;
            Name = name;
            Description = description;
            SKU = sku;
            Barcode = barcode;
            PiecesPerCarton = piecesPerCarton;
            SellingPrice = sellingPrice;
            MinimumStock = minimumStock;
            ImageUrl = imageUrl;


        }

        public Guid BrandId { get; private set; }

        public Guid ProductGroupId { get; private set; }

        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public string SKU { get; private set; } = string.Empty;

        public string? Barcode { get; private set; } 
        public int PiecesPerCarton { get; private set; }
        public decimal SellingPrice { get; private set; }
        public int CurrerntCartonStock { get; private set; }
        public int CurrentPiecesStock { get; private set; }
        public int  MinimumStock { get; private set; }
        public string? ImageUrl { get; private set; }
        public bool IsActive { get; private set; }

        public Brand Brand { get; private set; } = null!;
        public ProductGroup ProductGroup { get; private set; } = null!;

       public IReadOnlyCollection<ProductPriceHistory> productPriceHistories => _productPriceHistories.AsReadOnly();
        public IReadOnlyCollection<StockEntryItem> stockEntryItems => _stockEntryItems.AsReadOnly();

        public IReadOnlyCollection<DispatchItem> dispatchItems => _dispatchItems.AsReadOnly();

        public IReadOnlyCollection <DailyClosingItem> dailyClosingItems => _dailyColosingItems.AsReadOnly();

        public IReadOnlyCollection<StockAdjustment> stockAdjustments => _stockAdjustments.AsReadOnly();

        public static Product Create 
            (
                Guid brandId,
                Guid productGroupId,
                string name,
                string? description,
                string sku,
                string barcode,
                int piecesPerCarton,
                decimal sellingPrice,
                int minimumStock,
                string? imageUrl
            )
        {
            if ( brandId == Guid.Empty )
            {
                throw new ArgumentNullException("Brand is required");
            }
            if ( productGroupId == Guid.Empty )
            {
                throw new ArgumentNullException("Product Group is Required");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name is required");

            }
            if (string.IsNullOrWhiteSpace(sku) )
            {
                throw new ArgumentException("SKU is required");
            }
            if (piecesPerCarton <= 0)
            {
                throw new ArgumentException("Pieces per carton must be grater than 0");

            }
            if (sellingPrice <= 0)
            {
                throw new ArgumentException("Selling Price cannot be negative ");

            }
            if (minimumStock <= 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative ");

            }
            return new Product(
                    brandId,
        productGroupId,
        name.Trim(),
        description?.Trim(),
            sku.Trim().ToUpper(),
        barcode?.Trim(),
        piecesPerCarton,
        sellingPrice,
        minimumStock,
        imageUrl?.Trim()

                );

        }
        public void UpdateBasicInformation
            (
            Guid brandId,
                Guid productGroupId,
                string name,
                string? description,
                string sku,
                string barcode,
                int piecesPerCarton,
                decimal sellingPrice,
                int minimumStock,
                string? imageUrl
            )
        {
            if (brandId == Guid.Empty)
            {
                throw new ArgumentNullException("Brand is required");
            }
            if (productGroupId == Guid.Empty)
            {
                throw new ArgumentNullException("Product Group is Required");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name is required");

            }
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new ArgumentException("SKU is required");
            }
            if (piecesPerCarton <= 0)
            {
                throw new ArgumentException("Pieces per carton must be grater than 0");

            }
          
            if (minimumStock <= 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative ");
            }

            BrandId = brandId;
            ProductGroupId = productGroupId;
            Name = name;
            Description = description;
            SKU = sku;
            Barcode = barcode;
            PiecesPerCarton = piecesPerCarton;
            MinimumStock = minimumStock;
            ImageUrl = imageUrl;

            }
        public void UpdateSellingPrice ( decimal price )
        {
            if (price <= 0)
            {
                throw new ArgumentException("Selling Price cannot be negative ");

            }
            if (SellingPrice == price)
                return;

            var history = ProductPriceHistory.Create(
                Id, SellingPrice, price, DateTime.UtcNow);
            _productPriceHistories.Add( history );
            SellingPrice = price;
        }
        public void SetStatus ( bool isActive)
        {
            IsActive = isActive;
        }

    }
}
