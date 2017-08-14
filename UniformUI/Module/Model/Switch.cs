using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************************************************************************/
/* 名称：电磁阀实体类                                                    */
/* 作者：Samuel An                                                      */
/* 创建日期：2017-07-3                                                  */
/************************************************************************/

namespace UniformUI.Module.Model
{
    public class Switch
    {
        public Switch(int pin, int volt, string name, IOCard card)
        {
            _name = name;
            _pin = pin;
            _volt = volt;
            _card = card;
        }

        public Switch()
        {
            _name = "";
            _pin = 0;
            _volt = 0;
            _card = null;
        }

        public void On()
        {
            _card.On(_pin);
        }

        public void Off()
        {
            _card.Off(_pin);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Pin
        {
            get { return _pin; }
            set { _pin = Pin; }
        }

        public int Volt
        {
            get { return _volt; }
            set { _volt = Volt; }
        }

        private string _name;
        private int _pin;
        private int _volt;
        private IOCard _card;
    }
}
