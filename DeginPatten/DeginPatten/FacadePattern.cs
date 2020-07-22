using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class FacadePattern
    {
    }

    public class Facade
    {
        public static void PrintPicture(int employeeId)
        {
            var hr = new HRSystem();
            int picId = hr.GetPicturedId(employeeId);

            var pic = new PictureSystem();
            var data = pic.GetPicture(picId);

            var prt = new PrintSystem();
            prt.Print(data);
        }

        //Other Facade methods...
    }

    class HRSystem
    {
        public int GetPicturedId(int empId)
            => empId + 1000;
        //Oterh methods...
    }

    class PictureSystem
    {
        public byte[] GetPicture(int id)
        {
            byte[] data = new byte[] { 0xff };
            Console.WriteLine($"Retrieve Image for {id}");
            return data;
        }
    }

    class PrintSystem
    {
        public void Print(byte[] data)
        {
            Console.WriteLine($"Print {data.Length} bytes.");
        }
    }

    class Facade_Client
    {
        public static void howToUse()
        {
            Facade.PrintPicture(1001);
        }
    }
}
