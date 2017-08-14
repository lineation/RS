using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    public enum Direction
    {
        POSITIVE = 0,
        NEGATIVE
    };

    public enum PulsOutMode
    {
        PulseDir = 0,
        PulsePulse
    };

    public enum HomeMode
    {
        ORG = 0,// 找原点sensor
        PEL,	// 找正限位
        MEL		// 找负限位
    };

    public class MotionCard : IOCard
    {
        public MotionCard(int cardNum) : base(cardNum)
        {
            
        }

        public override bool Init()
        {
            return base.Init();
        }

        public override bool IsEnable(int pin)
        {
            return base.IsEnable(pin);
        }

        public override void On(int pin)
        {
            base.On(pin);
        }

        public override void Off(int pin)
        {
            base.Off(pin);
        }

        public virtual void Load(string file)
        {

        }

        public virtual void Save()
        {

        }

        public virtual void ServoOn(int axis)
        {

        }

        public virtual void ServoOff(int axis)
        {

        }

        public virtual void SetFactor(int axis, int facotr)
        {

        }

        public virtual void SetPlsOutMode(int axis, PulsOutMode plsOutMode)
        {

        }

        public virtual void SetSartVelocity(int axis, double vel)
        {

        }

        public virtual void SetWorkVelocity(int axis, double vel)
        {

        }

        public virtual void SetAcceleration(int axis, double acc)
        {

        }

        public virtual void SetDeceleration(int axis, double dec)
        {

        }

        public virtual void SetHomeSartVelocity(int axis, double vel)
        {

        }

        public virtual void SetHomeWorkVelocity(int axis, double vel)
        {

        }

        public virtual void SetHomeAcceleration(int axis, double acc)
        {

        }

        public virtual void SetHomeDeceleration(int axis, double dec)
        {

        }

        public virtual void SetHomeDirection(int axis, Direction dir)
        {

        }

        public virtual void SetHomeMode(int axis, HomeMode mode)
        {

        }

        public virtual void Home(int axis)
        {

        }

        public virtual void Move(int axis, double offset, bool wait = true)
        {

        }

        public virtual void MoveTo(int axis, double target, bool wait = true)
        {

        }

        public virtual void JogStart(int axis, Direction dir)
        {

        }

        public virtual void JogEnd(int axis)
        {

        }

        public virtual double GetCurrentPos(int axis)
        {
            return 0;
        }

        public virtual void StartupLineCompare(int axis, double startPos, double endPos, double interval)
        {

        }

        public virtual void ResetLineCompare(int axis)
        {

        }

        public virtual void WaitForDone(int axis, double timeout)
        {

        }

        public virtual bool IsMoving(int axis)
        {
            return false;
        }

        public virtual bool IsMel(int axis)
        {
            return false;
        }

        public virtual bool IsPel(int axis)
        {
            return false;
        }

        public virtual bool IsOrg(int axis)
        {
            return false;
        }

        public virtual bool IsWarn(int axis)
        {
            return false;
        }

        public virtual void Stop(int axis)
        {

        }

        protected int _axisTotal;
    }
}
