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
                Log.WriteLog("_rot :" + Calculators._rot);
                Log.WriteLog("_rotation :" + Calculators._rotation);
                Log.WriteLog("_radians :" + Calculators._radians);
                Log.WriteLog("_theta :" + Calculators._theta);
                Log.WriteLog("_thetadeg :" + Calculators._thetadeg);

            }

            if (KeyboardPolling.IsKeyDown(Keys.NumPad2))
            {
                Log.WriteLog("_rot :" + Calculators.);
                Log.WriteLog("_rotation :" + Calculators._rotation);
                Log.WriteLog("_radians :" + Calculators._radians);
                Log.WriteLog("_theta :" + Calculators._theta);
                Log.WriteLog("_thetadeg :" + Calculators._thetadeg);

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
