using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LapShop.Domains.ViewModels;

namespace LapShop.Services.SalesInvoice
{
    public interface ISalesInvoiceService
    {
        public Task Save(ShoppingCartVM cart);
    }
}
