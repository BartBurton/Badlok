using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Static class of data are used different game objects
    /// </summary>
    public static class Values
    {
        /// <summary>
        /// Bottom position of top BoxCollider ground
        /// </summary>
        public const float GROUND_TOP_POSITION = 1.8f;
        /// <summary>
        /// Top position of bottom BoxCollider ground
        /// </summary>
        public const float GROUND_BOTTOM_POSITION = -1.4f;
        /// <summary>
        /// Speed moving of obstacles
        /// </summary>
        public static float SpeedOfGame = 2f;
    }
}
