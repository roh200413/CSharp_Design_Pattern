using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeginPatten
{
    class AdapterPattern2
    {
    }
    public interface IAdapter
    {
        void Display(byte[] data);
    }

    public class HdmiToVgaAdapter : IAdapter
    {
        private LegacyVGA vga = new LegacyVGA();

        public void Display(byte[] data)
        {
            vga.Display(data);
        }
    }

    public class LegacyVGA
    {
        public void Display(byte[] data)
        {

        }
    }

    public class HdmiAdapter : IAdapter
    {
        public void Display(byte[] data) { }
    }

    class AdapterPattern_Client0
    {
        private bool vgaMonitor = true;

        public void HowToUse()
        {
            IAdapter hdmi;
            if (vgaMonitor)
            {
                hdmi = new HdmiToVgaAdapter();
            }
            else
            {
                hdmi = new HdmiAdapter();
            }

            var data = new byte[] { };
            DisplayData(hdmi, data);
        }

        void DisplayData (IAdapter adapter, byte[] data)
        {
            adapter.Display(data);
        }
    }
}
