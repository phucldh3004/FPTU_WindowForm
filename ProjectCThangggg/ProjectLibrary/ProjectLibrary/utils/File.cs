using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectLibrary.utils
{
    public class File
    {

        FileStream fs = new FileStream("ReportForCustomer.docx", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

        public void WriteToFile(string message)
        {
            byte[] arrByte = Encoding.UTF8.GetBytes(message);
            fs.Write(arrByte, 0, arrByte.Length);
            Console.WriteLine("Write finish!!");
            fs.Close();
        }

    }
}
