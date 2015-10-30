/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

namespace Niflib
{
	using System;

    /// <summary>
    /// Enum eNifVersion
    /// </summary>
    public enum eNifVersion : uint
	{
        /// <summary>
        /// The ve R_2_3
        /// </summary>
        VER_2_3 = 33751040u,
        /// <summary>
        /// The ve R_3_0
        /// </summary>
        VER_3_0 = 50331648u,
        /// <summary>
        /// The ve R_3_03
        /// </summary>
        VER_3_03 = 50332416u,
        /// <summary>
        /// The ve R_3_1
        /// </summary>
        VER_3_1 = 50397184u,
        /// <summary>
        /// The ve R_3_3_0_13
        /// </summary>
        VER_3_3_0_13 = 50528269u,
        /// <summary>
        /// The ve R_4_0_0_0
        /// </summary>
        VER_4_0_0_0 = 67108864u,
        /// <summary>
        /// The ve R_4_0_0_2
        /// </summary>
        VER_4_0_0_2 = 67108866u,
        /// <summary>
        /// The ve R_4_1_0_12
        /// </summary>
        VER_4_1_0_12 = 67174412u,
        /// <summary>
        /// The ve R_4_2_0_2
        /// </summary>
        VER_4_2_0_2 = 67239938u,
        /// <summary>
        /// The ve R_4_2_1_0
        /// </summary>
        VER_4_2_1_0 = 67240192u,
        /// <summary>
        /// The ve R_4_2_2_0
        /// </summary>
        VER_4_2_2_0 = 67240448u,
        /// <summary>
        /// The ve R_5_0_0_1
        /// </summary>
        VER_5_0_0_1 = 83886081u,
        /// <summary>
        /// The ve R_10_0_1_0
        /// </summary>
        VER_10_0_1_0 = 167772416u,
        /// <summary>
        /// The ve R_10_0_1_2
        /// </summary>
        VER_10_0_1_2 = 167772418u,
        /// <summary>
        /// The ve R_10_0_1_3
        /// </summary>
        VER_10_0_1_3,
        /// <summary>
        /// The ve R_10_1_0_0
        /// </summary>
        VER_10_1_0_0 = 167837696u,
        /// <summary>
        /// The ve R_10_1_0_101
        /// </summary>
        VER_10_1_0_101 = 167837797u,
        /// <summary>
        /// The ve R_10_1_0_106
        /// </summary>
        VER_10_1_0_106 = 167837802u,
        /// <summary>
        /// The ve R_10_2_0_0
        /// </summary>
        VER_10_2_0_0 = 167903232u,
        /// <summary>
        /// The ve R_10_4_0_1
        /// </summary>
        VER_10_4_0_1 = 168034305u,
        /// <summary>
        /// The ve R_20_0_0_4
        /// </summary>
        VER_20_0_0_4 = 335544324u,
        /// <summary>
        /// The ve R_20_0_0_5
        /// </summary>
        VER_20_0_0_5,
        /// <summary>
        /// The ve R_20_1_0_3
        /// </summary>
        VER_20_1_0_3 = 335609859u,
        /// <summary>
        /// The ve R_20_2_0_7
        /// </summary>
        VER_20_2_0_7 = 335675399u,
        /// <summary>
        /// The ve R_20_2_0_8
        /// </summary>
        VER_20_2_0_8,
        /// <summary>
        /// The ve R_20_3_0_1
        /// </summary>
        VER_20_3_0_1 = 335740929u,
        /// <summary>
        /// The ve R_20_3_0_2
        /// </summary>
        VER_20_3_0_2,
        /// <summary>
        /// The ve R_20_3_0_3
        /// </summary>
        VER_20_3_0_3,
        /// <summary>
        /// The ve R_20_3_0_6
        /// </summary>
        VER_20_3_0_6 = 335740934u,
        /// <summary>
        /// The ve R_20_3_0_9
        /// </summary>
        VER_20_3_0_9 = 335740937u,
        /// <summary>
        /// The ve r_ unsupported
        /// </summary>
        VER_UNSUPPORTED = 4294967295u,
        /// <summary>
        /// The ve r_ invalid
        /// </summary>
        VER_INVALID = 4294967294u
	}
}
