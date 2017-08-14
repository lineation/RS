using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using APS168_W32;
using APS_Define_W32;


namespace UniformUI.Module.Model   
{
    class AdlinkModtionCard : MotionCard
    {
        public AdlinkModtionCard(int cardNum) : base(cardNum)
        {
            _cardNum = cardNum;
            _objLock = new object();
        }

        public override bool Init()
        {
            base.Init();

            int cardID = 0;
            int ret = APS168.APS_initial(ref cardID, 0);
            if ((int)APS_Define.ERR_NoError != ret)
            {
                return false;
            }

            int startAxisID = 0;
            ret = APS168.APS_get_first_axisId(_cardNum, ref startAxisID, ref _axisTotal);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return false;
            }

            return true;
        }

        public override bool IsEnable(int pin)
        {
            base.IsEnable(pin);

            int value = 0;
            APS168.APS_read_d_input(_cardNum, 0, ref value);

            int voltage = ((value >> pin) & 1);

            return (voltage == 1) ? true : false;
        }

        public override void On(int pin)
        {
            base.On(pin);

            int ret = APS168.APS_write_d_channel_output(_cardNum, 0, pin, 1);
        }

        public override void Off(int pin)
        {
            base.Off(pin);

            int ret = APS168.APS_write_d_channel_output(_cardNum, 0, pin, 0);
        }

        public override void Load(string file)
        {
            int ret = APS168.APS_load_param_from_file(file);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }
        }

        public override void Save()
        {
            int ret = APS168.APS_save_param_to_file(_cardNum, "");
        }

        public override void ServoOn(int axis)
        {
            APS168.APS_set_servo_on(axis, 1);
        }

        public override void ServoOff(int axis)
        {
            APS168.APS_set_servo_on(axis, 0);
        }

        public override void SetFactor(int axis, int factor)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_POS_UNIT_FACTOR, factor);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }
        }

        public override void SetPlsOutMode(int axis, PulsOutMode plsOutMode)
        {
            base.SetPlsOutMode(axis, plsOutMode);

            int param;
            if (plsOutMode == PulsOutMode.PulseDir)
            {
                param = 0;
            }
            else if (plsOutMode == PulsOutMode.PulsePulse)
            {
                param = 1;
            }
            else
                param = 0;

            int ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_PLS_OPT_MODE, param);
            if (ret != (int)APS_Define.ERR_NoError)
            {

            }
        }

        public override void SetSartVelocity(int axis, double vel)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_VS, vel);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }

            APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_JG_VM, (int)vel);
        }

        public override void SetWorkVelocity(int axis, double vel)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_VM, vel);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }

            APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_JG_VM, (int)vel);
        }

        public override void SetAcceleration(int axis, double acc)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_ACC, acc);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }

            APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_JG_ACC, acc); //Set jog move acceleration
        }

        public override void SetDeceleration(int axis, double dec)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_DEC, dec);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }
        }

        public override void SetHomeSartVelocity(int axis, double vel)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_VS, vel);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }
        }

        public override void SetHomeWorkVelocity(int axis, double vel)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_VM, vel);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }
        }

        public override void SetHomeAcceleration(int axis, double acc)
        {
            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_ACC, acc);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }
        }

        public override void SetHomeDeceleration(int axis, double dec)
        {
            base.SetHomeDeceleration(axis, dec);
        }

        public override void SetHomeDirection(int axis, Direction dir)
        {
            base.SetHomeDirection(axis, dir);

            int ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_HOME_DIR, dir == Direction.POSITIVE ? 0 : 1);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }
        }

        public override void SetHomeMode(int axis, HomeMode mode)
        {
            base.SetHomeMode(axis, mode);

            int homeMode;
            if (mode == HomeMode.MEL || mode == HomeMode.PEL)
            {
                homeMode = 1;
            }
            else if (mode == HomeMode.ORG)
            {
                homeMode = 0;
            }
            else
                homeMode = 0;

            int ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_HOME_MODE, homeMode);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }
        }

        public override void Home(int axis)
        {
            Debug.WriteLine("AdlinkMotionCard.Home");

            int ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_CURVE, 0.5);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }

            // Set EZ signal alignment (yes or no)
            ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_HOME_EZA, 0);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }

            // Set home position shfit distance. 
            ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_SHIFT, 0);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }

            // Set final home position.
            ret = APS168.APS_set_axis_param_f(axis, (int)APS_Define.PRA_HOME_POS, 0.0);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }

            ret = APS168.APS_home_move(axis);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                return;
            }

            //WaitForDone(axis, 1000);
        }

        public override void Move(int axis, double offset, bool wait = true)
        {
            int workVel = 0;
            APS168.APS_get_axis_param(axis, (int)APS_Define.PRA_VM, ref workVel);

            int ret = APS168.APS_relative_move(axis, (int)offset, workVel);
            if (ret != (int)APS_Define.ERR_NoError)
            {

            }
        }

        public override void MoveTo(int axis, double target, bool wait = true)
        {
            int workVel = 0;
            APS168.APS_get_axis_param(axis, (int)APS_Define.PRA_VM, ref workVel);

            int ret = APS168.APS_absolute_move(axis, (int)target, workVel);
            if (ret != (int)APS_Define.ERR_NoError)
            {
                ;
            }
        }

        public override void JogStart(int axis, Direction dir)
        {
            base.JogStart(axis, dir);

            int ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_JG_DIR, dir == Direction.POSITIVE ? 0 : 1);
            ret = APS168.APS_set_axis_param(axis, (int)APS_Define.PRA_JG_MODE, 0);
            ret = APS168.APS_jog_start(axis, 1);
            //APS168.APS_velocity_move(axis, 3000);
        }

        public override void JogEnd(int axis)
        {
            base.JogEnd(axis);
            APS168.APS_jog_start(axis, 0);
        }

        public override double GetCurrentPos(int axis)
        {
            double pos = 0;
            //APS168.APS_get_position(axis, ref pos);
            APS168.APS_get_position_f(axis, ref pos);
            return pos;
        }

        public override void StartupLineCompare(int axis, double startPos, double endPos, double interval)
        {

        }

        public override void ResetLineCompare(int axis)
        {

        }

        public override void WaitForDone(int axis, double timeout = 15)
        {
            base.WaitForDone(axis, timeout);

            DateTime tStop = DateTime.Now.AddSeconds(timeout);
            while (DateTime.Now < tStop)
            {
                if (IsMoving(axis)) continue;
            }
        }

        public override bool IsMoving(int axis)
        {
            base.IsMoving(axis);

            int status = (APS168.APS_motion_status(axis) >> (int)APS_Define.NSTP) & 1;

            return status == 0 ? true : false;
        }

        public override bool IsMel(int axis)
        {
            int mel = ((APS168.APS_motion_io_status(axis) >> (int)APS_Define.MIO_MEL) & 1);

            return mel == 1 ? true : false;
        }

        public override bool IsPel(int axis)
        {
            int pel = ((APS168.APS_motion_io_status(axis) >> (int)APS_Define.MIO_PEL) & 1);

            return pel == 1 ? true : false;
        }

        public override bool IsOrg(int axis)
        {
            int value = APS168.APS_motion_io_status(axis);
            int org = value >> (int)APS_Define.MIO_ORG & 1;

            return org == 1 ? true : false;
        }

        public override bool IsWarn(int axis)
        {
            int warn = ((APS168.APS_motion_io_status(axis) >> (int)APS_Define.MIO_WARN) & 1);

            return warn == 1 ? true : false;
        }

        public override void Stop(int axis)
        {
            APS168.APS_stop_move(axis);
        }

        private int _cardNum;
        private int _axisTotal;
        private object _objLock;
    }
}