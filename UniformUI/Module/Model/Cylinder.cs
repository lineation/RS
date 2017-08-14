using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;
using System.Data;

/************************************************************************/
/* 名称：气缸                                                            */
/* 作用：对工业气缸进行封装                                               */
/* 作者：Samuel An                                                       */
/* 创建日期：2017.7.13                                                   */
/************************************************************************/

namespace UniformUI.Module.Model
{
    /// <summary>
    /// 气缸抽象类
    /// </summary>
    public abstract class Cylinder
    {
        protected double _timeout;
        protected Signal _pel;
        protected Signal _nel;
        protected Switch _sw;

        public Cylinder(Switch sw, Signal pel, Signal nel, double timeout)
        {
            _sw = sw;
            _pel = pel;
            _nel = nel;
            _timeout = timeout;
        }

        public virtual bool On()
        {
            _sw.On();

            if (_pel != null)
            {
                DateTime tStop = DateTime.Now.AddSeconds(_timeout);
                while (DateTime.Now < tStop)
                {
                    if (_pel.IsEnable())
                    {
                        return true;
                    }

                    Utility.Delay(20);
                }

                return false;
            }
            else
                return true;
        }

        public virtual bool Off()
        {
            _sw.Off();
            if (_nel != null)
            {
                DateTime tStop = DateTime.Now.AddSeconds(_timeout);
                while (DateTime.Now < tStop)
                {
                    if (_nel.IsEnable())
                    {
                        return true;
                    }

                    Utility.Delay(20);
                }

                return false;
            }
            else
            {
                return true;
            }
        }
    }

    /// <summary>
    /// 普通单电磁阀气缸
    /// </summary>
    class GeneralCylinder : Cylinder
    {
        public event EventHandler<GUIEventArgs> Notify;
        protected void OnNotify(string msg)
        {
            EventHandler<GUIEventArgs> tmp = Notify;
            if (tmp != null) tmp(this, new GUIEventArgs(msg));
        }

        public GeneralCylinder(string name, Switch sw, Signal pel, Signal nel, double timeout)
            : base(sw, pel, nel, timeout)
        {
            _name = name;
        }

        public override bool On()
        {
            return base.On();
        }

        public override bool Off()
        {
            return base.Off();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _name;
    }

    /// <summary>
    /// 双电磁阀气缸
    /// </summary>
    public class RodlessCylinder : Cylinder
    {
        public event EventHandler<GUIEventArgs> Notify;
        protected void OnNotify(string msg)
        {
            EventHandler<GUIEventArgs> tmp = Notify;
            if (tmp != null) tmp(this, new GUIEventArgs(msg));
        }

        public RodlessCylinder(string name, Switch p, Switch n, Signal pel, Signal nel, double timeout)
            : base(p, pel, nel, timeout)
        {
            _name = name;
            _n = n;
            _timeout = timeout;
        }

        public override bool On()
        {   
            _n.Off();
            return base.On();
        }

        public override bool Off()
        {
            _n.On();
            return base.Off();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _name;
        private Switch _n;
    }
}
