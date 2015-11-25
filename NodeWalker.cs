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
	
	/// <summary>
	/// Helper Class for Browsing Nodes in a Nif File
	/// </summary>
	public static class NodeWalker
	{
		/// <summary>
		/// Retrieves Roots from this File
		/// </summary>
		/// <param name="nif"></param>
		/// <returns></returns>
		public static IEnumerable<NiNode> GetRoots(this NiFile nif)
		{
			return nif.Footer.RootNodes.Where(rf => rf.IsValid()).Select(rf => rf.Object).OfType<NiNode>();
		}
		
		/// <summary>
		/// Retrieve Direct Children from this Node
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static IEnumerable<NiAVObject> GetChildren(this NiNode node)
		{
			return node.Children.Where(rf => rf.IsValid() && rf.Object != null).Select(rf => rf.Object);
		}
		
		/// <summary>
		/// Retrieve LOD Children given Distance
		/// </summary>
		/// <param name="node"></param>
		/// <param name="dist"></param>
		/// <returns></returns>
		public static IEnumerable<NiNode> GetChildrenFromLOD(this NiLODNode node, float dist)
		{
			var lods = node.GetChildren().OfType<NiNode>().ToArray();
			
			var lodlevels = node.LODLevels;
			if (lodlevels == null && node.LODLevelData.IsValid() && node.LODLevelData.Object != null)
			{
				var lodData = node.LODLevelData.Object as NiRangeLODData;
				if (lodData != null)
					lodlevels = lodData.LODLevels;
			}
			
			if (lodlevels == null)
			{
				// Default to first LOD Level for other LOD mechanisms
				var result = lods.FirstOrDefault();
				if (result != null)
					yield return result;
				yield break;
			}
			
			foreach (var match in lodlevels
			         .Select((l, i) => new { Ind = i, Lod = l })
			         .Where(o => dist >= o.Lod.NearExtent && dist < o.Lod.FarExtent  && o.Ind < lods.Length))
				yield return lods.ElementAt(match.Ind);
			yield break;
		}
		
		/// <summary>
		/// Retrieve Tri Based Nodes with 0f LoD Distance in all tree Depth
		/// </summary>
		/// <param name="node">Starting Lookup Node</param>
		/// <returns>NiTriBasedGeometry Collection</returns>
		public static IEnumerable<NiTriBasedGeometry> GetTriBasedNode(this NiNode node)
		{
			var stack = new Stack<NiNode>();
			stack.Push(node);
			do
			{
				var current = stack.Pop();
				
				var nilod = current as NiLODNode;
				if (nilod != null)
				{
					foreach (var child in nilod.GetChildrenFromLOD(0f))
						stack.Push(child);
				}
				else
				{
					foreach (var child in current.GetChildren())
					{	
						var childNode = child as NiNode;
						if (childNode != null)
							stack.Push(childNode);
						
						var childGeom = child as NiTriBasedGeometry;
						if (childGeom != null)
							yield return childGeom;
					}
				}
			}
			while(stack.Count > 0);
			yield break;
		}
		
		/// <summary>
		/// Is This Node Invisible
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsInvisible(this NiAVObject obj)
		{
			// Invisible Flag
			return (obj.Flags & 1) == 1;
		}
	}
}
