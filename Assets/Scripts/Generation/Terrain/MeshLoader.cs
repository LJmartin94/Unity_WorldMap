using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGeneration
{
	public class MeshLoader : MonoBehaviour
	{
        public bool loadOnStart;
        public bool disableLoading;

		public struct LoadInfo
        {
			public int vertexCount;
			public int numMeshes;
			public long loadDuration;
        }

        private void Start()
        {
            if (loadOnStart)
                Load();
        }

        public LoadInfo Load()
        {
            if (disableLoading)
                return default;
			return new LoadInfo();
        }
	}
}