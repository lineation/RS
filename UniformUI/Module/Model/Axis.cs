using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/************************************************************************/
/* 名称：马达实体类                                                     */
/* 作者：Samuel An                                                      */
/* 创建日期：2017-07-3                                                  */
/************************************************************************/

namespace UniformUI.Module.Model
{
    public class Axis
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="motionCard"></param>
        public Axis(int index, MotionCard motionCard)
        {
            _index = index;
            _motionCard = motionCard;
        }

        public Axis()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public void ServoOn()
        {
            _motionCard.ServoOn(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ServoOff()
        {
            _motionCard.ServoOff(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facotr"></param>
        public void SetFactor(int facotr)
        {
            _factor = facotr;
            _motionCard.SetFactor(_index, _factor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plsOutMode"></param>
        public void SetPlsOutMode(PulsOutMode plsOutMode = PulsOutMode.PulsePulse)
        {
            _motionCard.SetPlsOutMode(_index, plsOutMode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vel"></param>
        public void SetSartVelocity(double vel)
        {
            _startVelocity = vel;
            _motionCard.SetSartVelocity(_index, _startVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vel"></param>
        public void SetWorkVelocity(double vel)
        {
            _workVelocity = vel;
            _motionCard.SetWorkVelocity(_index, _workVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc"></param>
        public void SetAcceleration(double acc)
        {
            _acceleration = acc;
            _motionCard.SetAcceleration(_index, _acceleration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dec"></param>
        public void SetDeceleration(double dec)
        {
            _deceleration = dec;
            _motionCard.SetDeceleration(_index, dec);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vel"></param>
        public void SetHomeSartVelocity(double vel)
        {
            _homeStartVelocity = vel;
            _motionCard.SetHomeSartVelocity(_index, _homeStartVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vel"></param>
        public void SetHomeWorkVelocity(double vel)
        {
            _homeWorkVelocity = vel;
            _motionCard.SetHomeSartVelocity(_index, _homeWorkVelocity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc"></param>
        public void SetHomeAcceleration(double acc)
        {
            _homeAcceleration = acc;
            _motionCard.SetHomeAcceleration(_index, _homeAcceleration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dec"></param>
        public void SetHomeDeceleration(double dec)
        {
            _homeDeceleration = dec;
            _motionCard.SetHomeDeceleration(_index, _homeDeceleration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        public void SetHomeMode(HomeMode mode)
        {
            _homeMode = mode;
            _motionCard.SetHomeMode(_index, _homeMode);
        }

        public void SetHomeDirection(Direction dir)
        {
            _homeDirection = dir;
            _motionCard.SetHomeDirection(_index, _homeDirection);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Home()
        {
            Debug.WriteLine("Axis.Home");
            _motionCard.Home(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="wait"></param>
        public void Move(double offset, bool wait = true)
        {
            _motionCard.Move(_index, offset, wait);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="wait"></param>
        public void MoveTo(double target, bool wait = true)
        {
            _motionCard.MoveTo(_index, target, wait);
        }

        public void Jog(bool start, Direction dir = Direction.POSITIVE)
        {
            if (start)
                _motionCard.JogStart(_index, dir);
            else
                _motionCard.JogEnd(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetCurrentPos()
        {
            return _motionCard.GetCurrentPos(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="interval"></param>
        public void StartupLineCompare(double startPos, double endPos, double interval)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetLineCompare()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        public void WaitForDone(double timeout = 15)
        {
            _motionCard.WaitForDone(_index, timeout);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="sv"></param>
        /// <param name="wv"></param>
        /// <param name="acc"></param>
        /// <param name="dec"></param>
        /// <param name="hm"></param>
        /// <param name="dir"></param>
        /// <param name="homeSV"></param>
        /// <param name="homeWV"></param>
        /// <param name="homeAcc"></param>
        /// <param name="homeDec"></param>
        public void SetParameter(int factor, double sv, double wv, double acc, double dec, HomeMode hm, Direction dir, double homeSV, double homeWV, double homeAcc, double homeDec)
        {
            SetFactor(factor);
            SetSartVelocity(sv);
            SetWorkVelocity(wv);
            SetAcceleration(acc);
            SetDeceleration(dec);
            SetHomeDirection(dir);
            SetHomeMode(hm);
            SetHomeSartVelocity(homeSV);
            SetHomeWorkVelocity(homeWV);
            SetHomeAcceleration(homeAcc);
            SetHomeDeceleration(homeDec);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMoving()
        {
            return _motionCard.IsMoving(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsMel()
        {
            return _motionCard.IsMel(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPel()
        {
            return _motionCard.IsPel(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsOrg()
        {
            return _motionCard.IsOrg(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsWarn()
        {
            return _motionCard.IsWarn(_index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _motionCard.Stop(_index);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int Factor
        {
            get { return _factor; }
            set { _factor = value; }
        }

        public double StartVelocity
        {
            get { return _startVelocity; }
            set { _startVelocity = value; }
        }

        public double WorkVelocity
        {
            get { return _workVelocity; }
            set { _workVelocity = value; }
        }

        public double Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        public double Deceleration
        {
            get { return _deceleration; }
            set { _deceleration = value; }
        }

        public double HomeStartVelocity
        {
            get { return _homeStartVelocity; }
            set { _homeStartVelocity = value; }
        }

        public double HomeWorkVelocity
        {
            get { return _homeWorkVelocity; }
            set { _homeStartVelocity = value; }
        }

        public double HomeAcceleration
        {
            get { return _homeAcceleration; }
            set { _homeAcceleration = value; }
        }

        public double HomeDeceleration
        {
            get { return _homeDeceleration; }
            set { _homeDeceleration = value; }
        }

        public HomeMode HomeMode
        {
            get { return _homeMode; }
            set { _homeMode = value; }
        }

        public Direction HomeDirection
        {
            get { return _homeDirection; }
            set { _homeDirection = value; }
        }

        
        private string _name;
        private int _index;
        private int _factor;
        private double _startVelocity;
        private double _workVelocity;
        private double _acceleration;
        private double _deceleration;
        private double _homeStartVelocity;
        private double _homeWorkVelocity;
        private double _homeAcceleration;
        private double _homeDeceleration;
        private HomeMode _homeMode;
        private Direction _homeDirection;
        private MotionCard _motionCard;
    }
}
