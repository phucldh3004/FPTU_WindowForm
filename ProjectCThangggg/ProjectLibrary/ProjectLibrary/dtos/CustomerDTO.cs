using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class CustomerDTO
    {
        string FullName, Address, Email, Phone;
        DateTime BirthDay;


        public CustomerDTO()
        {
        }
            public CustomerDTO(string fullName, string address, string email, string phone, DateTime birthDay)
        {
            FullName = fullName;
            Address = address;
            Email = email;
            Phone = phone;
            BirthDay = birthDay;
        }

        public string FullName1 { get => FullName; set => FullName = value; }
        public string Address1 { get => Address; set => Address = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public DateTime BirthDay1 { get => BirthDay; set => BirthDay = value; }
    }
}
