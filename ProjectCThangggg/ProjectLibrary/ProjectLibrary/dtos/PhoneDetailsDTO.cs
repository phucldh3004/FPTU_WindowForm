using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
     public class PhoneDetailsDTO
    {
        private int id;
        private string phoneName;
        private float price;
        private int manufactureYear;
        private DateTime acquiredDate;
        private int quantity;
        private string type;
        private string category;
        private string status;

        public PhoneDetailsDTO()
        {
        }

        public PhoneDetailsDTO(int id, string phoneName, float price, int manufactureYear, DateTime acquiredDate, int quantity, string type, string category, string status)
        {
            this.Id = id;
            this.PhoneName = phoneName;
            this.Price = price;
            this.ManufactureYear = manufactureYear;
            this.AcquiredDate = acquiredDate;
            this.Quantity = quantity;
            this.Type = type;
            this.Category = category;
            this.Status = status;
        }

        public int Id { get => Id1; set => Id1 = value; }
        public string PhoneName { get => PhoneName1; set => PhoneName1 = value; }
        public float Price { get => Price1; set => Price1 = value; }
        public int ManufactureYear { get => ManufactureYear1; set => ManufactureYear1 = value; }
        public DateTime AcquiredDate { get => AcquiredDate1; set => AcquiredDate1 = value; }
        public int Quantity { get => Quantity1; set => Quantity1 = value; }
        public string Type { get => Type1; set => Type1 = value; }
        public string Category { get => Category1; set => Category1 = value; }
        public string Status { get => Status1; set => Status1 = value; }
        public int Id1 { get => id; set => id = value; }
        public string PhoneName1 { get => phoneName; set => phoneName = value; }
        public float Price1 { get => price; set => price = value; }
        public int ManufactureYear1 { get => manufactureYear; set => manufactureYear = value; }
        public DateTime AcquiredDate1 { get => acquiredDate; set => acquiredDate = value; }
        public int Quantity1 { get => quantity; set => quantity = value; }
        public string Type1 { get => type; set => type = value; }
        public string Category1 { get => category; set => category = value; }
        public string Status1 { get => status; set => status = value; }
    }
}
