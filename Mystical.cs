using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Coroutines;
using CommonBehaviors.Actions;
using Mystical.Helpers;
using Mystical.Math;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.CommonBot.Routines;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace Mystical
{
    class Mystical : CombatRoutine
    {
        protected static readonly LocalPlayer Me = StyxWoW.Me;
        public override string Name { get { return "Mystical"; } }
        public override WoWClass Class { get { return WoWClass.None; } }

        public override Composite CombatBehavior { get { return CreateCombat(); } }
        public override Composite PullBehavior { get { return CreatePull(); } }
        public override Composite PreCombatBuffBehavior { get { return CreateBuffs(); } }
        public override Composite RestBehavior { get { return CreateRest(); } }

        public override void Initialize()
        {
            BotEvents.OnBotStarted += OnBotStartEvent;
            BotEvents.OnBotStopped += OnBotStopEvent;
        }
        public override void ShutDown()
        {
            BotEvents.OnBotStarted -= OnBotStartEvent;
            BotEvents.OnBotStopped -= OnBotStopEvent;
        }

        private static void OnBotStartEvent(object o)
        {
            //RegisterHotkeys();
            InitializeOnce();
            //EventLog.AttachCombatLogEvent();

        }

        private static void OnBotStopEvent(object o)
        {
            //EventLog.DetachCombatLogEvent();
            //UnregisterHotkeys();
        }

        private static void InitializeOnce()
        {
            //ClassSettings.Initialize();

            switch (BotManager.Current.Name)
            {
                case "LazyRaider":
                    //GeneralSettings.Instance.Movement = false;
                    break;
                case "Enyo (Buddystore)":
                    //GeneralSettings.Instance.Movement = false;
                    break;
                case "Questing":
                    //GeneralSettings.Instance.Movement = true;
                    //GeneralSettings.Instance.Targeting = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "Akatosh Quester":
                    //GeneralSettings.Instance.Movement = true;
                    //GeneralSettings.Instance.Targeting = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "BGBuddy":
                    //GeneralSettings.Instance.Movement = true;
                    //GeneralSettings.Instance.Targeting = true;
                    //GeneralSettings.Instance.PvP = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "BGFarmer [Millz]":
                    //GeneralSettings.Instance.Movement = true;
                    //GeneralSettings.Instance.Targeting = true;
                    //GeneralSettings.Instance.PvP = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "Combat Bot":
                    //GeneralSettings.Instance.Movement = true;
                    //GeneralSettings.Instance.Targeting = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "Grind Bot":
                    //GeneralSettings.Instance.Movement = true;
                    Log.WriteLog(string.Format("Movement Enabled - Bot - {0} detected", BotManager.Current.Name));
                    break;
                case "Raid Bot":
                    //GeneralSettings.Instance.Movement = false;
                    break;
                case "RaidBot Improved":
                    //GeneralSettings.Instance.Movement = false;
                    break;
                default:
                    //GeneralSettings.Instance.Movement = false;
                    //GeneralSettings.Instance.Targeting = true;
                    Log.WriteLog(string.Format("Botbase - {0} detected", BotManager.Current.Name));
                    break;
            }

            //TalentManager.Init();
            //GeneralSettings.Instance.Save();
            Log.WriteLog(string.Format("Axiom Loaded"), Colors.Orange);
        }

        public override void Pulse()
        {
            if (KeyboardPolling.IsKeyDown(Keys.NumPad4))
            {
                Movement.Movement.CoPulse();
            }

            if (Me.GotTarget && !Me.CurrentTarget.IsFriendly && Me.CurrentTarget.IsTargetingMeOrPet)
            {
                Movement.Movement.CoPulse();
            }
        }

        #region Hooks

        protected virtual Composite CreateCombat()
        {
            return new HookExecutor("Axiom_Combat_Root",
                "Root composite for Axiom combat. Rotations will be plugged into this hook.",
                new ActionAlwaysFail());
        }

        protected virtual Composite CreateBuffs()
        {
            return new HookExecutor("Axiom_Buffs_Root",
                "Root composite for Axiom buffs. Rotations will be plugged into this hook.",
                new ActionAlwaysFail());
        }

        protected virtual Composite CreateRest()
        {
            return new HookExecutor("Axiom_Rest_Root",
                "Root composite for Axiom Resting. Rotations will be plugged into this hook.",
                new ActionAlwaysFail());
        }

        protected virtual Composite CreatePull()
        {
            return new HookExecutor("Axiom_Pull_Root",
                "Root composite for Axiom Pulling. Rotations will be plugged into this hook.",
                new ActionAlwaysFail());
        }

        #endregion

    }
}
