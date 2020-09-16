using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class InvoideDetailsDTO
    {
        int id;
        int phoneID;
        int invoiceID;
        float unitPrice;
        int quantity;

        public InvoideDetailsDTO()
        {
        }

        public InvoideDetailsDTO(int id, int phoneID, int invoiceID, float unitPrice, int quantity)
        {
            this.Id = id;
            this.PhoneID = phoneID;
            this.InvoiceID = invoiceID;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public int Id { get => id; set => id = value; }
        public int PhoneID { get => phoneID; set => phoneID = value; }
        public int InvoiceID { get => invoiceID; set => invoiceID = value; }
        public float UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
