using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.dtos
{
    public class AccountDTO
    {
        string userID, phoneNumer, fullname, address;

        public AccountDTO()
        {
        }

        public AccountDTO(string userID, string phoneNumer, string fullname, string address)
        {
            this.UserID = userID;
            this.PhoneNumer = phoneNumer;
            this.Fullname = fullname;
            this.Address = address;
        }

        public string UserID { get => userID; set => userID = value; }
        public string PhoneNumer { get => phoneNumer; set => phoneNumer = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
    }
}
