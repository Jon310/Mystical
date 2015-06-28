﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Mystical.Helpers;
using Styx;
using Styx.CommonBot;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Mystical.Movement
{
    class Movement
    {
        private static readonly WoWPlayer Me = StyxWoW.Me;

        internal static void Pulse() // convert to coroutine to get both movement and combat to run at the same time
        {
            {
                try
                {
                    //valid checks

                    //distance checks
                    
                    //check facing

                        //face

                    //strafe

                }
                catch (Exception ex)
                {
                    Log.WriteLog("Error in Movement Pulse: " + ex, Colors.DarkRed);
                }
            }
        }

        public static async Task<bool> CoPulse()
        {
            if (Me.CurrentTarget.IsDead || Me.CurrentTarget == null)
                return false;

            if (Me.CurrentTarget.Distance < 3)
            {
                WoWMovement.Move(WoWMovement.MovementDirection.Backwards);
                SpellManager.Cast("Blink");
            }

            return false;
        } 


    }
}
