using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhoneManagement.Account
{
    class Account
    {
        private string userID;
        private string password;
        private int role;
        private int status;
        private string phone;
        private string fullname;
        private string address;

        public Account()
        {
        }

        public Account(string userID, string password, int role, int status, string phone, string fullname, string address)
        {
            this.UserID = userID;
            this.Password = password;
            this.Role = role;
            this.Status = status;
            this.Phone = phone;
            this.Fullname = fullname;
            this.Address = address;
        }

        public string UserID { get => userID; set => userID = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public int Status { get => status; set => status = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
    }
}
