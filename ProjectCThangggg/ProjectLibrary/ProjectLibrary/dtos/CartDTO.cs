using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class CartDTO
    {
        int id;
        int idPhone;
        string phoneName;
        float price;
        int quantity;

        public CartDTO()
        {
        }

        public CartDTO(int id, int idPhone, string phoneName, float price, int quantity)
        {
            this.Id = id;
            this.IdPhone = idPhone;
            this.PhoneName = phoneName;
            this.Price = price;
            this.Quantity = quantity;
        }

        public int Id { get => id; set => id = value; }
        public int IdPhone { get => idPhone; set => idPhone = value; }
        public string PhoneName { get => phoneName; set => phoneName = value; }
        public float Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
