using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class PhoneTypeDTO
    {
        private int id;
        private string description;

        public PhoneTypeDTO()
        {
        }

        public PhoneTypeDTO(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
    }
}
