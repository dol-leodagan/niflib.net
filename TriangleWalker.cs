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

namespace Niflib.Extensions
{
	using System;
	using System.Text.RegularExpressions;
	using System.Linq;
	using System.Collections.Generic;
	using Niflib;
	#if OpenTK
	using OpenTK;
	using Matrix = OpenTK.Matrix4;
	#elif SharpDX
	using SharpDX;
	#elif MonoGame
	using Microsoft.Xna.Framework;
	#endif

	/// <summary>
	/// Triangle Indexes Struct
	/// </summary>
	public struct TriangleIndex
	{
		public uint A;
		public uint B;
		public uint C;
	}
	
	/// <summary>
	/// Triangles Collection Struct with TriangleIndex'ed Vertices
	/// </summary>
	public struct TriangleCollection
	{
		public Vector3[] Vertices;
		public TriangleIndex[] Indices;
	}
	
	/// <summary>
	/// Helper Class for Browsing Triangle Shape in a Nif File.
	/// </summary>
	public static class TriangleWalker
	{
		/// <summary>
		/// Retrieve Triangles Shapes in a Nif File following given Category nodes
		/// </summary>
		/// <param name="file">NiFile to parse</param>
		/// <param name="categories">NiObject Name (RegExp) from where to Browse for Triangles Shape</param>
		/// <returns>Dictionary of Category Indexed Triangle Collection</returns>
		public static IDictionary<string, TriangleCollection> GetTriangleFromCategories(this NiFile file, params string[] categories)
		{
			if (file == null)
				throw new ArgumentNullException("file");
			if (categories == null)
				throw new ArgumentNullException("categories");
			if (categories.Length < 1)
				throw new ArgumentException("No result will be searched with empty Categories", "categories");
			
			// Search every Root Nodes for Node Categories
			var result = new Dictionary<string, TriangleCollection>();
			foreach(var root in file.Footer.RootNodes.Where(rf => rf.IsValid()).Select(rf => rf.Object).OfType<NiNode>())
			{
				foreach(var category in categories)
				{
					// Retrieve Triangle Collection From Category
					var startingNodes = root.FindNodeWithCategory(category);
					foreach (var node in startingNodes)
					{
						var nodeTris = node.GetTrianglesFromNode();
						bool wrong = nodeTris.Indices.Any(tri => tri.A >= nodeTris.Vertices.Length || tri.B >= nodeTris.Vertices.Length || tri.C >= nodeTris.Vertices.Length);
						
						var nodeName = node.Name.Value;
						// Add or Concat
						TriangleCollection existing;
						if (result.TryGetValue(nodeName, out existing))
						{
							TriangleCollection triConcat;
							Concat(ref existing, ref nodeTris, out triConcat);
							result[nodeName] = triConcat;
						}
						else
						{
							result.Add(nodeName, nodeTris);
						}
					}
				}
			}
			
			return result;
		}
		
		/// <summary>
		/// Get Triangle From Node Root Retrieving Geometry Based Meshes
		/// </summary>
		/// <param name="node"></param>
		/// <param name="onlyDrawable"></param>
		/// <returns></returns>
		public static TriangleCollection GetTrianglesFromNode(this NiNode node, bool onlyDrawable = false)
		{
			var stack = new Stack<NiNode>();
			stack.Push(node);
			TriangleCollection result = new TriangleCollection { Vertices = new Vector3[0], Indices = new TriangleIndex[0], };
			
			foreach (var trinode in node.GetTriBasedNode())
			{
				// Filter drawable nodes
				if (onlyDrawable && trinode.IsInvisible())
					continue;
				
				var triangles = trinode.GetTrianglesFromGeometry();
					
				TriangleCollection intermediate;
				Concat(ref result, ref triangles, out intermediate);
				result = intermediate;

			}
			
			return result;
		}
		
		/// <summary>
		/// Retrieve Geometry Data as Triangle Collection
		/// </summary>
		/// <param name="geom"></param>
		/// <returns></returns>
		public static TriangleCollection GetTrianglesFromGeometry(this NiTriBasedGeometry geom)
		{
			if (geom.Data != null && geom.Data.IsValid() && geom.Data.Object != null)
			{
				Matrix transformation = geom.GetWorldMatrixFromNode();
				// Shape Parsing
				var shapeData = geom.Data.Object as NiTriShapeData;
				if (shapeData != null && shapeData.HasVertices && shapeData.NumVertices >= 3)
				{
					return shapeData.GetTrianglesFromGeometryShape(transformation);
				}
				
				// Strips Parsing
				var stripsData = geom.Data.Object as NiTriStripsData;
	            if (stripsData != null && stripsData.HasVertices && stripsData.NumVertices >= 3)
	            {
	            	return stripsData.GetTrianglesFromGeometryStrips(transformation);
	            }
			}
			return new TriangleCollection { Vertices = new Vector3[0], Indices = new TriangleIndex[0] };
		}
		
		public static TriangleCollection GetTrianglesFromGeometryShape(this NiTriShapeData shapeData, Matrix transformationMatrix)
		{
            return new TriangleCollection
            {
            	Vertices = shapeData.Vertices.Select(vert => { Vector3 trans; Vector3.Transform(ref vert, ref transformationMatrix, out trans); return trans; }).ToArray(),
            	Indices = shapeData.Triangles.Select(tri => new TriangleIndex { A = tri.X, B = tri.Y, C = tri.Z, }).ToArray()
            };
		}
		
		public static TriangleCollection GetTrianglesFromGeometryStrips(this NiTriStripsData stripsData, Matrix transformationMatrix)
		{
			var stripsLength = stripsData.Points.Length;
            var indices = stripsData.Points.Select(strip =>
                                                   {
                                                   	var points = strip;
                                                   	var pointsLength = points.Length;
                                                   	if (pointsLength > 2)
                                                   	{
                                                   		var tris = new List<TriangleIndex>();
                                                   		var a = points[0];
                                                   		var b = a;
                                                   		var c = points[1];
                                                   		
                                                   		for (int pts = 2 ; pts < pointsLength ; pts++)
                                                   		{
                                                   			a = b;
                                                   			b = c;
                                                   			c = points[pts];
                                                   			
                                                   			if (a != b && b != c && c != a)
                                                   				tris.Add(pts % 2 == 0 ? new TriangleIndex{ A = a, B = b, C = c } : new TriangleIndex{ A = a, B = c, C = b });
                                                   		}
                                                   		
                                                   		return tris;
                                                   	}
                                                   	return new List<TriangleIndex>();
                                                   });
			
            return new TriangleCollection
            {
            	Vertices = stripsData.Vertices.Select(vert => { Vector3 trans; Vector3.Transform(ref vert, ref transformationMatrix, out trans); return trans; }).ToArray(),
            	Indices = indices.SelectMany(tri => tri).ToArray()
            };
		}
		
		/// <summary>
		/// Compute World Matrix Starting From Node and Reading all Parents Transformations
		/// </summary>
		/// <param name="leaf"></param>
		/// <returns></returns>
		public static Matrix GetWorldMatrixFromNode(this NiAVObject leaf)
		{
			var current = leaf;
            var worldMatrix = Matrix.Identity;
            // For Each Parent Node
			while (current != null)
			{
				// Append Transformation To Matrix
				Matrix intermediate;
				
				#if SharpDX
				Matrix.Multiply(ref worldMatrix, ref current.Rotation, out intermediate);
				worldMatrix = intermediate;
				
				var scale = Matrix.Scaling(current.Scale);
				Matrix.Multiply(ref worldMatrix, ref scale, out intermediate);
				worldMatrix = intermediate;
				
				var translate = Matrix.Translation(current.Translation.X, current.Translation.Y, current.Translation.Z);
				Matrix.Multiply(ref worldMatrix, ref translate, out intermediate);
				worldMatrix = intermediate;
				#elif MonoGame
				Matrix.Multiply(ref worldMatrix, ref current.Rotation, out intermediate);
				worldMatrix = intermediate;
				
				var scale = Matrix.CreateScale(current.Scale);
				Matrix.Multiply(ref worldMatrix, ref scale, out intermediate);
				worldMatrix = intermediate;
				
				var translate = Matrix.CreateTranslation(current.Translation.X, current.Translation.Y, current.Translation.Z);
				Matrix.Multiply(ref worldMatrix, ref translate, out intermediate);
				worldMatrix = intermediate;
				#else
				Matrix.Mult(ref worldMatrix, ref current.Rotation, out intermediate);
				worldMatrix = intermediate;
				
				var scale = Matrix.CreateScale(current.Scale);
				Matrix.Mult(ref worldMatrix, ref scale, out intermediate);
				worldMatrix = intermediate;
				
				var translate = Matrix.CreateTranslation(current.Translation.X, current.Translation.Y, current.Translation.Z);
				Matrix.Mult(ref worldMatrix, ref translate, out intermediate);
				worldMatrix = intermediate;
				#endif
				
				current = current.Parent;
			}
			
			return worldMatrix;
		}
		
		/// <summary>
		/// Search Ninode Category From given Root
		/// </summary>
		/// <param name="node"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		public static NiNode[] FindNodeWithCategory(this NiNode node, string category)
		{
			var result = new List<NiNode>();
			var stack = new Stack<NiNode>();
			stack.Push(node);
			do
			{
				var current = stack.Pop();
				if (Regex.IsMatch(current.Name.Value, category, RegexOptions.IgnoreCase))
				{
					// Add Result and Don't Push Children !
					result.Add(current);
				}
				else if (current.Children != null)
				{
					foreach(var child in current.Children.Where(rf => rf.IsValid()).Select(rf => rf.Object).OfType<NiNode>())
						stack.Push(child);
				}
			}
			while (stack.Count > 0);
			
			return result.ToArray();
		}
		
		/// <summary>
		/// Browse Triangle Collection as Enumerable of T
		/// T is instanciated from given delegate using 3 Vector3
		/// </summary>
		/// <param name="tris">TriangleCollection to flatten</param>
		/// <param name="constructor">Delegate return object from three Vector3</param>
		/// <returns>Triangle Enumerable</returns>
		public static IEnumerable<T> AsEnumerable<T>(this TriangleCollection tris, Func<Vector3, Vector3, Vector3, T> constructor)
		{
			return tris.Indices.Select(tri => constructor(tris.Vertices[tri.A], tris.Vertices[tri.B], tris.Vertices[tri.C]));
		}
		
		/// <summary>
		/// Enumerate vertex normals for each triangle vertices
		/// </summary>
		/// <param name="tris">Triangle Collection for Normal Mapping</param>
		/// <param name="norms">Normalized Vector3 array for each Triangle Indexed vertex</param>
		/// <returns></returns>
		public static IEnumerable<Vector3> PerVertexNormalEnumerable(this TriangleCollection tris, Vector3[] norms)
		{
			if (norms.Length < tris.Vertices.Length)
				throw new NotSupportedException("Normals Collection is smaller than Vertices collection !");
			
			return tris.Indices.Select(tri => new [] { norms[tri.A], norms[tri.B], norms[tri.C] }).SelectMany(tri => tri);
		}
		
		/// <summary>
		/// Compute Normal Light Vector from Triangle Collection
		/// </summary>
		/// <param name="tris">Triangle Collection Object from which to Compute normals</param>
		/// <returns>Normalized Vector3 Light Normal array for each Triangle's vertex index</returns>
		public static Vector3[] ComputeNormalLighting(this TriangleCollection tris)
		{
			var lookup = tris.Indices.Select((tri, i) => new []{ new KeyValuePair<uint, int>(tri.A, i), new KeyValuePair<uint, int>(tri.B, i), new KeyValuePair<uint, int>(tri.C, i), })
				.SelectMany(tr => tr).ToLookup(kv => kv.Key, kv => kv.Value);
			return tris.Vertices.Select((vert, ind) =>
			                            lookup[(uint)ind].Select(i => tris.Indices[i])
			                            .Aggregate(new Vector3(0, 0, 0),
			                                       (v, t) => {
			                                       	Vector3 AB;
			                                       	Vector3 AC;
			                                       	Vector3.Subtract(ref tris.Vertices[t.B], ref tris.Vertices[t.A], out AB);
			                                       	Vector3.Subtract(ref tris.Vertices[t.C], ref tris.Vertices[t.A], out AC);
			                                       	Vector3 cross;
			                                       	Vector3.Cross(ref AB, ref AC, out cross);
			                                       	Vector3 crossnorms;
			                                       	Vector3.Normalize(ref cross, out crossnorms);
			                                       	Vector3 result;
			                                       	Vector3.Add(ref v, ref crossnorms, out result);
			                                       	return result;
			                                       }
			                                       , a => { Vector3 n; Vector3.Normalize(ref a, out n); return n; })
			                           ).ToArray();
		}
		
		/// <summary>
		/// Concat Two triangle Collections with indexed Vertices into One Collection
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="other"></param>
		/// <returns></returns>
		public static TriangleCollection Concat(this TriangleCollection collection, TriangleCollection other)
		{
			TriangleCollection result;
			Concat(ref collection, ref other, out result);
			return result;
		}
		
		/// <summary>
		/// Concat Two triangle Collections with indexed Vertices into One Collection
		/// </summary>
		/// <param name="collection"></param>
		/// <param name="other"></param>
		/// <param name="result"></param>
		public static void Concat(ref TriangleCollection collection, ref TriangleCollection other, out TriangleCollection result)
		{
			var collectionVerticesCount = (uint)collection.Vertices.Length;
			var otherIndices = other.Indices.Select(tri => new TriangleIndex {
			                                        	A = tri.A+collectionVerticesCount,
			                                        	B = tri.B+collectionVerticesCount,
			                                        	C = tri.C+collectionVerticesCount,
			                                        });
			var vertices = collection.Vertices.Concat(other.Vertices).ToArray();
			var indices = collection.Indices.Concat(otherIndices).ToArray();
			result = new TriangleCollection()
			{
				Vertices = vertices,
				Indices = indices,
			};
		}
	}
}
