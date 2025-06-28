using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Data;
using LapShop.Domains;
using LapShop.Domains.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LapShop.Services.SalesInvoice
{
    public class SalesInvoiceService : ISalesInvoiceService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MainContext _context;

        public SalesInvoiceService(UserManager<ApplicationUser> userManager, MainContext context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _context = context;
        }

        public async Task Save(ShoppingCartVM cart)
        {
            if(cart == null || cart.Items == null || !cart.Items.Any())
            {
                throw new ArgumentException("Cart cannot be null or empty.");
            }
            try
            {
                List<SalesInvoicexItem> invoiceItems = new List<SalesInvoicexItem>();
                foreach (var item in cart.Items)
                {
                    invoiceItems.Add(new SalesInvoicexItem
                    {
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        InvoicePrice = item.TotalPrice
                    });
                }

                Domains.SalesInvoice salesInvoice = new Domains.SalesInvoice
                {
                    InvoiceDate = DateTime.UtcNow,
                    SalesInvoicexItems = invoiceItems
                };

                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    _context.SalesInvoicexItems.AddRange(invoiceItems);
                    _context.SalesInvoices.Add(salesInvoice);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the sales invoice: " + ex.Message);
            }
        }
    }
}
