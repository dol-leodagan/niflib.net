using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Niflib
{
	public class NiFile
	{
		[CompilerGenerated]
		private static class o__11
		{
			public static CallSite<Action<CallSite, object, NiFile>> p__0;

			public static CallSite<Func<CallSite, object, object>> p__1;

			public static CallSite<Func<CallSite, object, bool>> p__2;

			public static CallSite<Func<CallSite, object, object>> p__3;

			public static CallSite<Func<CallSite, object, object, object>> p__4;

			public static CallSite<Func<CallSite, object, bool>> p__5;

			public static CallSite<Action<CallSite, object, NiFile>> p__6;
		}

		public const uint INVALID_REF = 4294967295u;

		public const string CMD_TOP_LEVEL_OBJECT = "Top Level Object";

		public const string CMD_END_OF_FILE = "End Of File";

		public NiHeader Header;

		public NiFooter Footer;

		public Dictionary<uint, NiObject> ObjectsByRef;

		public eNifVersion Version
		{
			get
			{
				return this.Header.Version;
			}
		}

		public NiFile(BinaryReader reader)
		{
			this.Header = new NiHeader(this, reader);
			this.ReadNiObjects(reader);
			this.Footer = new NiFooter(this, reader);
			this.FixRefs();
		}

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

		private void FixRefs()
		{
			foreach (NiObject current in this.ObjectsByRef.Values)
			{
				this.FixRefs(current);
			}
		}

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

		private void PrintNifNode(NiAVObject root, int depth)
		{
			string text = "";
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
