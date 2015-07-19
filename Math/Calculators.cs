using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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
    internal class Calculators
    {
        private static readonly LocalPlayer Me = StyxWoW.Me;

        #region Rotation

        // Rotation
        public static float _rotation(WoWObject obj)
        {
            return obj.RotationDegrees;
        }

        public static float _rot(WoWObject obj)
        {
            return Me.Rotation;
        }

        public static double _radians(WoWObject obj)
        {
            return _rotation(obj)*(System.Math.PI/180);
        }

        public static double _theta(WoWObject obj)
        {
            return System.Math.Atan(_Y(obj)/_X(obj)); // Radians
        }

        public static double _thetadeg(WoWObject obj)
        {
            return RadtoDeg(_theta(obj));
        }

        #endregion

        #region Position

        //////////////////
        //// Position ////
        //////////////////

        // Cartesian
        public static double _X(WoWObject obj) 
        {
            return obj.X;
        }

        public static double _Y(WoWObject obj)
        {
            return obj.Y;
        }

        public static float _Z(WoWObject obj)
        {
            return obj.Z;
        }

        /// <summary>
        /// Relative X. (coordinate system centered on obj1 at (0,0,0)
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>obj2 - obj1</returns>
        public static float _relX(WoWObject obj1, WoWObject obj2)
        {
            return obj2.X - obj1.X;
        }
        
        /// <summary>
        /// Relative Y. (coordinate system centered on obj1 at (0,0,0)
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>obj2 - obj1</returns>
        public static float _relY(WoWObject obj1, WoWObject obj2)
        {
            return obj2.Y - obj1.Y;
        }

        /// <summary>
        /// Relative Z. (coordinate system centered on obj1 at (0,0,0)
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>obj2 - obj1</returns>
        public static float _relZ(WoWObject obj1, WoWObject obj2)
        {
            return obj2.Z - obj1.Z;
        }

        // Polar (R, theta, Z)
        public static double _R(WoWObject obj1, WoWObject obj2)
        {
            return System.Math.Sqrt(System.Math.Pow(_relX(obj1, obj2), 2) + System.Math.Pow(_relY(obj1, obj2), 2)); // (x^2 + Y^2)^(1/2)
        }
        // theta and Z are the same as Rotation and Cartesian

        #endregion

        #region Vectors        

        /// <summary>
        /// The Vector from obj1 to obj2
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>A Vector <x, y, z></returns>
        public static Vector3 _obj1ToObj2(WoWObject obj1, WoWObject obj2)
        {
            return new Vector3(_relX(obj1, obj2), _relY(obj1, obj2), _relZ(obj1, obj2));
        }

        /// <summary>
        /// Unit Vector obj1 towards obj2 with a length of 1 unit.
        /// </summary>
        /// <param name="obj1">The obj1.</param>
        /// <param name="obj2">The obj2.</param>
        /// <returns>A Vector of length 1 unit</returns>
        public static Vector3 _unitVector(WoWObject obj1, WoWObject obj2)
        {
            return _obj1ToObj2(obj1, obj2) / _obj1ToObj2(obj1, obj2).Magnitude;
        }

        public static Vector3 _B(Vector3 targetVector3, double theta)
        {
            
            var Xcoord = (System.Math.Cos(theta) * targetVector3.X) - (System.Math.Sin(theta) * targetVector3.X);
            var Ycoord = (System.Math.Sin(theta) * targetVector3.Y) + (System.Math.Cos(theta) * targetVector3.Y);


            return new Vector3((float) Xcoord, (float) Ycoord, Me.Z);
        }


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
