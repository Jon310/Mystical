using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Mystical.Helpers;
using Mystical.Math;
using Bots.DungeonBuddy.Helpers;
using Buddy.Coroutines;
using JetBrains.Annotations;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.Helpers;
using Styx.Pathing;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Mystical.Movement
{
    class Movement
    {
        private static readonly WoWPlayer Me = StyxWoW.Me;
        private const int Cone = 40;
        private static WoWUnit _target;

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

        public static void CoPulse()
        {

            if (Me.CurrentTarget.Distance < 3 && SpellManager.CanCast("Blink"))
            {
                WoWMovement.Move(WoWMovement.MovementDirection.Backwards);
                SpellManager.Cast("Blink");
                return;
            }

            _target = Me.CurrentTarget;

            // Strafe Left
            if (GetDegree <= 180 && GetDegree >= Cone)
            {
                var vectorA = Calculators._obj1ToObj2(Me, Me.CurrentTarget);
                var B = Calculators._B(vectorA, System.Math.PI / 2);

                if (!Me.IsFacing(new WoWPoint(B.X, B.Y, B.Z)) && Me.CurrentTarget.Distance < 10)
                {
                    WoWMovement.Move(WoWMovement.MovementDirection.TurnLeft);
                }

                if (Me.IsFacing(new WoWPoint(B.X, B.Y, B.Z)))
                {
                    WoWMovement.MoveStop(WoWMovement.MovementDirection.TurnLeft);
                }

                if (Me.CurrentTarget.Distance < 10)
                {
                    WoWMovement.Move(WoWMovement.MovementDirection.StrafeLeft);
                }

                if (Me.CurrentTarget.Distance >= 20)
                {
                    WoWMovement.MoveStop(WoWMovement.MovementDirection.StrafeLeft);
                }
            }

            // Strafe right
            if (GetDegree >= 180 && GetDegree <= (360 - Cone))
            {
                var vectorA = Calculators._obj1ToObj2(Me, Me.CurrentTarget);
                var B = Calculators._B(vectorA, -(System.Math.PI / 2));

                if (!Me.IsFacing(new WoWPoint(B.X, B.Y, B.Z)) && Me.CurrentTarget.Distance < 10)
                {
                    WoWMovement.Move(WoWMovement.MovementDirection.TurnRight);
                }

                if (Me.IsFacing(new WoWPoint(B.X, B.Y, B.Z)))
                {
                    WoWMovement.MoveStop(WoWMovement.MovementDirection.TurnRight);
                }

                if (Me.CurrentTarget.Distance < 10)
                {
                    WoWMovement.Move(WoWMovement.MovementDirection.StrafeRight);
                }

                if (Me.CurrentTarget.Distance >= 20)
                {
                    WoWMovement.MoveStop(WoWMovement.MovementDirection.StrafeRight);
                }
            }

            return;
        }

        

        private static double GetDegree
        {
            get
            {
                
                var d = System.Math.Atan2((_target.Y - Me.Y), (_target.X - Me.X));

                var r = d - _target.Rotation; 	  // subtracting object rotation from absolute rotation
                if (r < 0)
                    r += (System.Math.PI * 2);

                return WoWMathHelper.RadiansToDegrees((float)r);
            }
        }


    }
}
