using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mystical.Helpers;
using Mystical.Math;
using Styx;
using Styx.CommonBot.Routines;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Mystical
{
    class Mystical : CombatRoutine
    {
        protected static readonly LocalPlayer Me = StyxWoW.Me;

        public override string Name
        {
            get { return "Mystical"; }
        }

        public override WoWClass Class
        {
            get { return WoWClass.Mage; }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Pulse()
        {
            if (KeyboardPolling.IsKeyDown(Keys.NumPad1))
            {
                Log.WriteLog("_rot : " + Calculators._rot(Me));
                Log.WriteLog("_rotation : " + Calculators._rotation(Me));
                Log.WriteLog("_radians : " + Calculators._radians(Me));
                Log.WriteLog("_theta : " + Calculators._theta(Me));
                Log.WriteLog("_thetadeg : " + Calculators._thetadeg(Me));
            }

            if (KeyboardPolling.IsKeyDown(Keys.NumPad2))
            {
                Log.WriteLog("_X(Me) : " + Calculators._X(Me));
                Log.WriteLog("_Y(Me) : " + Calculators._Y(Me));
                Log.WriteLog("_Z(Me) : " + Calculators._Z(Me));
                Log.WriteLog("_X(Target) : " + Calculators._X(Me.CurrentTarget));
                Log.WriteLog("_Y(Target) : " + Calculators._Y(Me.CurrentTarget));
                Log.WriteLog("_Z(Target) : " + Calculators._Z(Me.CurrentTarget));
                Log.WriteLog("_R Me to Target : " + Calculators._R(Me, Me.CurrentTarget));
                Log.WriteLog("_relX : " + Calculators._relX(Me, Me.CurrentTarget));
                Log.WriteLog("_relY : " + Calculators._relY(Me, Me.CurrentTarget));
                Log.WriteLog("_relZ : " + Calculators._relZ(Me, Me.CurrentTarget));
            }

            if (KeyboardPolling.IsKeyDown(Keys.NumPad3))
            {
                Log.WriteLog("_metoTar : " + Calculators._obj1ToObj2(Me, Me.CurrentTarget));
                Log.WriteLog("_unitMetoTar : " + Calculators._unitVector(Me, Me.CurrentTarget));
            }

            if (Me.IsAlive && Me.CurrentTarget != null)
            {
                // Test Turning

                // Test Strafing

                if (Me.CurrentTarget.Distance < 6)
                {
                    // starfe away
                }

                if (Me.CurrentTarget.Distance < 3)
                {
                    // blink away
                }

            }
        }

    }
}
