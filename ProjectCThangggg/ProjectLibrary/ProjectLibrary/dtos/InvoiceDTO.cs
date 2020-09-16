using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class InvoiceDTO
    {
        int id;
        DateTime dateOfPurcharse;
        String customerPhone;
        float totalPrice;

        public InvoiceDTO()
        {
        }

        public InvoiceDTO(int id, DateTime dateOfPurcharse, string customerPhone, float totalPrice)
        {
            this.Id = id;
            this.DateOfPurcharse = dateOfPurcharse;
            this.CustomerPhone = customerPhone;
            this.TotalPrice = totalPrice;
        }

        public int Id { get => id; set => id = value; }
        public DateTime DateOfPurcharse { get => dateOfPurcharse; set => dateOfPurcharse = value; }
        public string CustomerPhone { get => customerPhone; set => customerPhone = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
