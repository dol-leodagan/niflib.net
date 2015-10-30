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
	using System.IO;

    /// <summary>
    /// Class NiStencilProperty.
    /// </summary>
    public class NiStencilProperty : NiProperty
	{
        /// <summary>
        /// The flags
        /// </summary>
        public ushort Flags;

        /// <summary>
        /// The is stencil enabled
        /// </summary>
        public bool IsStencilEnabled;

        /// <summary>
        /// The stencil function
        /// </summary>
        public eStencilCompareMode StencilFunction;

        /// <summary>
        /// The stencil reference
        /// </summary>
        public uint StencilRef;

        /// <summary>
        /// The stencil mask
        /// </summary>
        public uint StencilMask;

        /// <summary>
        /// The fail action
        /// </summary>
        public eStencilAction FailAction;

        /// <summary>
        /// The z fail action
        /// </summary>
        public eStencilAction ZFailAction;

        /// <summary>
        /// The pass action
        /// </summary>
        public eStencilAction PassAction;

        /// <summary>
        /// The face draw mode
        /// </summary>
        public eFaceDrawMode FaceDrawMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiStencilProperty"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiStencilProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version <= eNifVersion.VER_10_0_1_2)
			{
				this.Flags = reader.ReadUInt16();
			}
			if (this.File.Header.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.IsStencilEnabled = reader.ReadBoolean();
				this.StencilFunction = (eStencilCompareMode)reader.ReadUInt32();
				this.StencilRef = reader.ReadUInt32();
				this.StencilMask = reader.ReadUInt32();
				this.FailAction = (eStencilAction)reader.ReadUInt32();
				this.ZFailAction = (eStencilAction)reader.ReadUInt32();
				this.PassAction = (eStencilAction)reader.ReadUInt32();
				this.FaceDrawMode = (eFaceDrawMode)reader.ReadUInt32();
			}
			if (this.File.Header.Version >= eNifVersion.VER_20_1_0_3)
			{
				this.Flags = reader.ReadUInt16();
				this.StencilRef = reader.ReadUInt32();
				this.StencilMask = reader.ReadUInt32();
			}
		}
	}
}
