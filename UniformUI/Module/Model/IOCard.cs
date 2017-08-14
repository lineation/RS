using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    public class IOCard
    {
        public IOCard(int cardNum)
        {
            _cardNum = cardNum;
        }

        public virtual bool Init()
        {
            return false;
        }

        public virtual int CardNum
        {
            get { return _cardNum; }
        }

        public virtual bool IsEnable(int pin)
        {
            return false;
        }

        public virtual void On(int pin)
        {

        }

        public virtual void Off(int pin)
        {

        }

        private int _cardNum;
    }
}
