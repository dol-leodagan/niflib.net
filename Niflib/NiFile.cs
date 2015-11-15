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
	using Microsoft.CSharp.RuntimeBinder;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Runtime.CompilerServices;

    /// <summary>
    /// Class NiFile.
    /// </summary>
    public class NiFile
	{
        /// <summary>
        /// Class o__11.
        /// </summary>
        [CompilerGenerated]
		private static class o__11
		{
            /// <summary>
            /// The P__0
            /// </summary>
            public static CallSite<Action<CallSite, object, NiFile>> p__0;

            /// <summary>
            /// The P__1
            /// </summary>
            public static CallSite<Func<CallSite, object, object>> p__1;

            /// <summary>
            /// The P__2
            /// </summary>
            public static CallSite<Func<CallSite, object, bool>> p__2;

            /// <summary>
            /// The P__3
            /// </summary>
            public static CallSite<Func<CallSite, object, object>> p__3;

            /// <summary>
            /// The P__4
            /// </summary>
            public static CallSite<Func<CallSite, object, object, object>> p__4;

            /// <summary>
            /// The P__5
            /// </summary>
            public static CallSite<Func<CallSite, object, bool>> p__5;

            /// <summary>
            /// The P__6
            /// </summary>
            public static CallSite<Action<CallSite, object, NiFile>> p__6;
		}

        /// <summary>
        /// The invali d_ reference
        /// </summary>
        public const uint INVALID_REF = 4294967295u;

        /// <summary>
        /// The cm d_ to p_ leve l_ object
        /// </summary>
        public const string CMD_TOP_LEVEL_OBJECT = "Top Level Object";

        /// <summary>
        /// The cm d_ en d_ o f_ file
        /// </summary>
        public const string CMD_END_OF_FILE = "End Of File";

        /// <summary>
        /// The header
        /// </summary>
        public NiHeader Header;

        /// <summary>
        /// The footer
        /// </summary>
        public NiFooter Footer;

        /// <summary>
        /// The objects by reference
        /// </summary>
        public Dictionary<uint, NiObject> ObjectsByRef;

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public eNifVersion Version
		{
			get
			{
				return this.Header.Version;
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NiFile"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public NiFile(BinaryReader reader)
		{
			this.Header = new NiHeader(this, reader);
			this.ReadNiObjects(reader);
			this.Footer = new NiFooter(this, reader);
			this.FixRefs();
		}

        /// <summary>
        /// Reads the ni objects.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="Exception">
        /// Check value is not zero! Invalid file?
        /// or
        /// Invalid object type string length!
        /// </exception>
        /// <exception cref="NotImplementedException"></exception>
        private void ReadNiObjects(BinaryReader reader)
		{
			this.ObjectsByRef = new Dictionary<uint, NiObject>();
			int num = 0;
			string text;
			while (true)
			{
				if (this.Version >= eNifVersion.VER_5_0_0_1)
				{
					if (this.Version <= eNifVersion.VER_10_1_0_106 && reader.ReadUInt32() != 0u)
					{
						break;
					}
					text = this.Header.BlockTypes[(int)this.Header.BlockTypeIndex[num]].Value;
				}
				else
				{
					uint num2 = reader.ReadUInt32();
					if (num2 > 30u || num2 < 6u)
					{
						goto IL_74;
					}
					text = new string(reader.ReadChars((int)num2));
					if (this.Header.Version < eNifVersion.VER_3_3_0_13)
					{
						if (text == "Top Level Object")
						{
							continue;
						}
						if (text == "End Of File")
						{
							return;
						}
					}
				}
				uint key;
				if (this.Version < eNifVersion.VER_3_3_0_13)
				{
					key = reader.ReadUInt32();
				}
				else
				{
					key = (uint)num;
				}
				Type expr_E7 = Type.GetType("Niflib." + text);
				if (expr_E7 == null)
				{
					goto Block_8;
				}
				NiObject value = (NiObject)Activator.CreateInstance(expr_E7, new object[]
				{
					this,
					reader
				});
				this.ObjectsByRef.Add(key, value);
				if (this.Version >= eNifVersion.VER_3_3_0_13)
				{
					num++;
					if ((long)num >= (long)((ulong)this.Header.NumBlocks))
					{
						return;
					}
				}
			}
			throw new Exception("Check value is not zero! Invalid file?");
			IL_74:
			throw new Exception("Invalid object type string length!");
			Block_8:
			throw new NotImplementedException(text);
		}

        /// <summary>
        /// Fixes the refs.
        /// </summary>
        private void FixRefs()
		{
        	// Fix Object Refs
			foreach (NiObject current in this.ObjectsByRef.Values)
			{
				this.FixRefs(current);
			}
			
			// Fix Footer Refs
			foreach (var niRef in Footer.RootNodes)
			{
				niRef.SetRef(this);
			}
		}

        /// <summary>
        /// Fixes the refs.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="Exception">no child</exception>
        private void FixRefs(object obj)
		{
			FieldInfo[] fields = obj.GetType().GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				if (fieldInfo.FieldType.Name.Contains("NiRef"))
				{
					if (fieldInfo.FieldType.IsArray)
					{
						IEnumerable enumerable = (IEnumerable)fieldInfo.GetValue(obj);
						if (enumerable == null)
						{
							goto IL_303;
						}
						IEnumerator enumerator = enumerable.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object current = enumerator.Current;
								if (NiFile.o__11.p__0 == null)
								{
									NiFile.o__11.p__0 = CallSite<Action<CallSite, object, NiFile>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetRef", null, typeof(NiFile), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
									}));
								}
								NiFile.o__11.p__0.Target(NiFile.o__11.p__0, current, this);
								if (fieldInfo.Name == "Children")
								{
									if (NiFile.o__11.p__2 == null)
									{
										NiFile.o__11.p__2 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(NiFile), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									Func<CallSite, object, bool> arg_16A_0 = NiFile.o__11.p__2.Target;
									CallSite arg_16A_1 = NiFile.o__11.p__2;
									if (NiFile.o__11.p__1 == null)
									{
										NiFile.o__11.p__1 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "IsValid", null, typeof(NiFile), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
										}));
									}
									if (arg_16A_0(arg_16A_1, NiFile.o__11.p__1.Target(NiFile.o__11.p__1, current)))
									{
										if (NiFile.o__11.p__3 == null)
										{
											NiFile.o__11.p__3 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Object", typeof(NiFile), new CSharpArgumentInfo[]
											{
												CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
											}));
										}
										NiAVObject expr_1C2 = NiFile.o__11.p__3.Target(NiFile.o__11.p__3, current) as NiAVObject;
										if (expr_1C2 == null)
										{
											throw new Exception("no child");
										}
										expr_1C2.Parent = (NiNode)obj;
									}
								}
							}
							goto IL_303;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					object value = fieldInfo.GetValue(obj);
					if (NiFile.o__11.p__5 == null)
					{
						NiFile.o__11.p__5 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(NiFile), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, bool> arg_2A0_0 = NiFile.o__11.p__5.Target;
					CallSite arg_2A0_1 = NiFile.o__11.p__5;
					if (NiFile.o__11.p__4 == null)
					{
						NiFile.o__11.p__4 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(NiFile), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					if (!arg_2A0_0(arg_2A0_1, NiFile.o__11.p__4.Target(NiFile.o__11.p__4, value, null)))
					{
						if (NiFile.o__11.p__6 == null)
						{
							NiFile.o__11.p__6 = CallSite<Action<CallSite, object, NiFile>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SetRef", null, typeof(NiFile), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						NiFile.o__11.p__6.Target(NiFile.o__11.p__6, value, this);
					}
				}
				IL_303:;
			}
		}

        /// <summary>
        /// Finds the root.
        /// </summary>
        /// <returns>NiAVObject.</returns>
        public NiAVObject FindRoot()
		{
			NiAVObject niAVObject = (from obj in this.ObjectsByRef.Values.OfType<NiAVObject>()
			select obj).FirstOrDefault<NiAVObject>();
			if (niAVObject == null)
			{
				return null;
			}
			while (niAVObject.Parent != null)
			{
				niAVObject = niAVObject.Parent;
			}
			return niAVObject;
		}

        /// <summary>
        /// Prints the nif tree.
        /// </summary>
        private void PrintNifTree()
		{
			NiAVObject niAVObject = this.FindRoot();
			if (niAVObject == null)
			{
				Console.WriteLine("No Root!");
				return;
			}
			int depth = 0;
			this.PrintNifNode(niAVObject, depth);
		}

        /// <summary>
        /// Prints the nif node.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="depth">The depth.</param>
        private void PrintNifNode(NiAVObject root, int depth)
		{
			string text = string.Empty;
			for (int i = 0; i < depth; i++)
			{
				text += "*";
			}
			text += " ";
			Console.WriteLine(text + " " + root.Name);
			NiNode niNode = root as NiNode;
			if (niNode != null)
			{
				NiRef<NiAVObject>[] children = niNode.Children;
				for (int j = 0; j < children.Length; j++)
				{
					NiRef<NiAVObject> niRef = children[j];
					if (niRef.IsValid())
					{
						this.PrintNifNode(niRef.Object, depth + 1);
					}
				}
			}
		}
	}
}
