using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class PhoneCategoriesDTO
    {
        private int id;
        private string description;

        public PhoneCategoriesDTO()
        {
        }

        public PhoneCategoriesDTO(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
    }
}
