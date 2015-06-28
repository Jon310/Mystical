using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.CommonBot.Routines;
using Styx.Helpers;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Vector3 = Buddy.Auth.Math.Vector3;

namespace Mystical.Math
{
    class Calculators
    {
        private static readonly LocalPlayer Me = StyxWoW.Me;

        #region Rotation

        // Rotation
        public static readonly float _rotation = Me.RotationDegrees;
        public static float _rot = Me.Rotation;
        public static double _radians = _rotation * (System.Math.PI / 180);
        public static double _theta = System.Math.Atan(_relY / _relX); // Radians
        public static double _thetadeg = RadtoDeg(_theta);

        #endregion

        #region Position

        //////////////////
        //// Position ////
        //////////////////
        
        // Cartesian
        public static double _tarX = Me.CurrentTarget.X;
        public static double _tarY = Me.CurrentTarget.Y;
        public static float _tarZ = Me.CurrentTarget.Z;

        public static float _meX = Me.X;
        public static float _meY = Me.Y;
        public static float _meZ = Me.Z;

        // Relative xyz (Coord system centered on player at (0,0,0))
        public static float _relX = Me.CurrentTarget.X - Me.X;
        public static float _relY = Me.CurrentTarget.Y - Me.Y;
        public static float _relZ = Me.CurrentTarget.Z - Me.Z;

        // Polar (R, theta, Z)
        public static double _tarR = System.Math.Sqrt(System.Math.Pow(_tarX, 2) + System.Math.Pow(_tarY, 2)); // (x^2 + Y^2)^(1/2)
        // theta and Z are the same as Rotation and Cartesian


        // Cylendrical (p, fi, theta)

        #endregion

        #region Vectors

        public static Vector3 _metoTar = new Vector3(_relX, _relY, _relZ);
        public static Vector3 _tartoMe = -_metoTar;

        // Unit Vectors
        public static Vector3 _unitMetoTar = _metoTar / _metoTar.Magnitude;
        
        #endregion

        #region Conversions

        static double RadtoDeg(double rads)
        {
            return (rads*(180/System.Math.PI));
        }

        static double DegtoRad(float deg)
        {
            return (deg*(System.Math.PI/180));
        }

        #endregion

    }
}
