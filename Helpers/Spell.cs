using System;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using JetBrains.Annotations;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Mystical.Helpers
{
    [UsedImplicitly]
    class Spell : Mystical
    {

        #region CoCast Wrappers

        public static async Task<bool> CoCast(int spell)
        {
            return await CoCast(spell, Me.CurrentTarget, true, false);
        }

        public static async Task<bool> CoCast(int spell, WoWUnit unit)
        {
            return await CoCast(spell, unit, true, false);
        }

        public static async Task<bool> CoCast(int spell, bool reqs)
        {
            return await CoCast(spell, Me.CurrentTarget, reqs, false);
        }

        public static async Task<bool> CoCast(int spell, WoWUnit unit, bool reqs)
        {
            return await CoCast(spell, unit, reqs, false);
        }

        #endregion

        #region CoCast

        public static async Task<bool> CoCast(int spell, WoWUnit unit, bool reqs, bool cancel)
        {
            var sp = WoWSpell.FromId(spell);
            var sname = sp != null ? sp.Name : "#" + spell;

            if (unit == null || !reqs || !SpellManager.CanCast(spell, unit, true))
                return false;

            if (!SpellManager.Cast(spell, unit))
                return false;

            if (!await Coroutine.Wait(GetSpellCastTime(sname), () => cancel) && GetSpellCastTime(sname).TotalSeconds > 0)
            {
                SpellManager.StopCasting();
                Log.WriteLog("Canceling " + sname + ".");
                return false;
            }

            await CommonCoroutines.SleepForLagDuration();
            return true;
        }

        #endregion

        #region CastOnGround

        public static async Task<bool> CastOnGround(int spell, WoWUnit unit, bool reqs)
        {
            var sp = WoWSpell.FromId(spell);
            var sname = sp != null ? sp.Name : "#" + spell;

            if (!reqs || !SpellManager.CanCast(spell) || unit == null)
                return false;

            var onLocation = unit.Location;

            if (!SpellManager.Cast(spell))
                return false;

            if (!await Coroutine.Wait(1000, () => StyxWoW.Me.CurrentPendingCursorSpell != null))
            {
                Logging.Write(Colors.DarkRed, "Cursor Spell Didn't happen");
                return false;
            }

            SpellManager.ClickRemoteLocation(onLocation);
            Log.WritetoFile(LogLevel.Diagnostic, String.Format("Casting {0}", sname));
            await CommonCoroutines.SleepForLagDuration();
            return true;
        }

        #endregion

        #region GetSpellCastTime(string s)

        public static TimeSpan GetSpellCastTime(string s)
        {
            SpellFindResults sfr;
            if (SpellManager.FindSpell(s, out sfr))
                return TimeSpan.FromMilliseconds((sfr.Override ?? sfr.Original).CastTime);
            return TimeSpan.Zero;
        }

        #endregion

    }
}
