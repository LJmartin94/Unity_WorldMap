using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGeneration
{
	public class MeshLoader : MonoBehaviour
	{
		public struct LoadInfo
        {
			public int vertexCount;
			public int numMeshes;
			public long loadDuration;
        }

		public LoadInfo Load()
        {
			return new LoadInfo();
        }
	}
}