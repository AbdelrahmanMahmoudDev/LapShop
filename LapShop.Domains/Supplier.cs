﻿namespace LapShop.Domains
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public List<PurchaseInvoice> PurchaseInvoices { get; set; }
    }
}
