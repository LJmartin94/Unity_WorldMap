using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGeneration
{
	public class MeshLoader : MonoBehaviour
	{
        public bool loadOnStart;
        public bool disableLoading;

        public TextAsset loadFile;
        public Material mat;
        public bool staticBatching;


		public struct LoadInfo
        {
			public int vertexCount;
			public int numMeshes;
			public long loadDuration;
        }

        private void Start()
        {
            if (loadOnStart)
                Load(loadFile, mat, transform, staticBatching);
        }

        public LoadInfo Load()
        {
            if (disableLoading)
                return default;
            return Load(loadFile, mat, transform, staticBatching, gameObject.layer);
        }

        public static LoadInfo Load(TextAsset loadFile, Material mat, Transform parent, bool staticBatching, int layer = 0)
        {
            LoadInfo info = new LoadInfo();
            return info;
        }
	}
}