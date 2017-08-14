using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************************************************************************/
/* 名称：传感器实体类                                                    */
/* 作者：Samuel An                                                      */
/* 创建日期：2017-07-3                                                  */
/************************************************************************/

namespace UniformUI.Module.Model 
{
    public class Signal
    {
        public Signal(int pin, int volt, string name, IOCard card)
        {
            _name = name;
            _pin = pin;
            _volt = volt;
            _card = card;
        }

        public Signal()
        {
            _name = "";
            _pin = 0;
            _volt = 0;
            _card = null;
        }

        public bool IsEnable()
        {
            return _card.IsEnable(_pin);
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

        public int CardNum
        {
            get { return _card.CardNum; }
        }

        private string _name;
        private int _pin;
        private int _volt;
        private IOCard _card;
    }
}
