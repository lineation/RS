using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineIO;

namespace UniformUI.Module.Model
{
    class UWC300Card : IOCard
    {
        public UWC300Card(int port, int cardNum)
            : base(cardNum)
        {
            _port = port;
            _cardNum = cardNum;
        }

        public override bool Init()
        {
            base.Init();
            int ret = UWC300.uwc300_initial((uint)_port);
            return ret == 0;
        }

        public override bool IsEnable(int pin)
        {
            ulong lStatus = 0;
            int rtn = UWC300.uwc300_get_32output(ref lStatus);
            if (rtn > 0)
            {
                return false;
            }

            return 1 == (lStatus & (ulong)(0x01 << pin - 1));
        }

        public override void On(int pin)
        {
            ulong lStatus = 0;
            int rtn = UWC300.uwc300_get_32output(ref lStatus);
            if (rtn > 0)
            {
                return;
            }

            lStatus &= (ulong)(~(0x01 << pin - 1));
            rtn = UWC300.uwc300_set_32output(lStatus);
            if (rtn > 0)
            {
                return;
            }
        }

        public override void Off(int pin)
        {
            ulong lStatus = 0;
            int rtn = UWC300.uwc300_get_32output(ref lStatus);
            if (rtn > 0)
            {
                return;
            }

            lStatus |= (ulong)(0x01 << pin - 1);
            rtn = UWC300.uwc300_set_32output(lStatus);
            if (rtn > 0)
            {
                return;
            }
        }

        private int _port;
        private int _cardNum;
    }
}
