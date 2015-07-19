using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mystical.Spec;

namespace Mystical.Helpers
{
    [UsedImplicitly]
    class SpellList : Mystical
    {
        #region Mage Spells

        public const int
            AmplifyMagic = 159916,
            ArcaneBrilliance = 1459,
            BlastWave = 157981,
            BlazingSpeed = 108843,
            Blink = 1953,
            Blizzard = 10,
            BrainFreeze = 44549,
            ColdSnap = 11958,
            Combustion = 11129,
            CometStorm = 153595,
            ConeofCold = 120,
            ConjureRefreshmentTable = 43987,
            ConjureRefreshment = 42955,
            Counterspell = 2139,
            DeepFreeze = 44572,
            DragonsBreath = 31661,
            EnhancedFrostbolt = 157646,
            Evanesce = 157913,
            FingersofFrost = 112965,
            Fireball = 133,
            FireBlast = 2136,
            Flamestrike = 2120,
            FreezingGrasp = 175689,
            FrostArmor = 7302,
            Frostbolt = 116,
            FrostfireBolt = 44614,
            FrostNova = 122,
            FrozenOrb = 84714,
            GarrisonAbility = 161691,
            GreaterInvisibility = 110959,
            IceBarrier = 11426,
            IceBlock = 45438,
            IceFloes = 108839,
            IceShards = 165360,
            IcyVeins = 12472,
            ImprovedBlizzard = 157727,
            ImprovedIcyVeins = 157721,
            ImprovedWaterElemental = 157738,
            IncantersFlow = 1463,
            InfernoBlast = 108853,
            Invisibility = 66,
            LivingBomb = 44457,
            MageBomb = 125430, // level 75 Talent
            Meteor = 153561,
            Polymorph = 118,
            Pyroblast = 11366,
            RemoveCurse = 475,
            RingofFrost = 113724,
            RuneofPower = 116011,
            Scorch = 2948,
            Shatter = 12982,
            SlowFall = 130,
            Spellsteal = 30449,
            SummonWaterElemental = 31687,
            TimeWarp = 80353,

            // Professions
            Skinning = 158756,
            Fishing = 131474,
            Tailoring = 158758,
            CookingFire = 818,
            Cooking = 158765,
            FirstAid = 158741,
            
            // Portals
            TeleportValeofEternalBlossoms = 132621,
            TeleportTolBarad = 88342,
            TeleportTheramore = 49359,
            TeleportStormwind = 3561,
            TeleportStormshield = 176248,
            TeleportShattrath = 33690,
            TeleportIronforge = 3562,
            TeleportExodar = 32271,
            TeleportDarnassus = 3565,
            TeleportDalaran = 53140,
            PortalValeofEternalBlossoms = 132620,
            PortalTolBarad = 88345,
            PortalTheramore = 49360,
            PortalStormwind = 10059,
            PortalStormshield = 176246,
            PortalShattrath = 33691,
            PortalIronforge = 11416,
            PortalExodar = 32266,
            PortalDarnassus = 11419,
            PortalDalaran = 53142,

            // General
            WisdomoftheFourWinds = 115913,
            WeaponSkills = 76298,
            Upgrades = 170733,
            TheQuickandtheDead = 83950,
            TheHumanSpirit = 20598,
            SwiftRecovery = 169608,
            MountUp = 78633,
            Languages = 79738,
            HastyHearth = 83944,
            GuildMail = 83951,
            FlightMastersLicense = 90267,
            Diplomacy = 20599,
            ColdWeatherFlying = 54197,
            BattlePetTraining = 119467,
            ArtisanRiding = 34091,
            ArmorSkills = 76276,
            Shoot = 5019,
            ReviveBattlePets = 125439,
            MobileBanking = 83958,
            MassResurrection = 83968,
            EveryManforHimself = 59752,
            AutoAttack = 6603;

        #endregion
    }
}
