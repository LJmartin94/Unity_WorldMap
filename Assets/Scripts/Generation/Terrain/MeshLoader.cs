using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainGeneration
{
	public class MeshLoader : MonoBehaviour
	{
        public bool loadOnStart = false;
        public bool disableLoading = false;

        public TextAsset loadFile;
        public Material mat;
        public bool staticBatching = true;


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
            var sw = System.Diagnostics.Stopwatch.StartNew();
            
            LoadInfo info = new LoadInfo();
            SimpleMeshData[] meshes = MeshSerialiser.BytesToMeshes(loadFile.bytes);
            GameObject[] allObjects = new GameObject[meshes.Length];

            for (int i = 0; i < meshes.Length; i++)
            {
                var renderObject = MeshHelper.CreateRenderObject(meshes[i].name, meshes[i], mat, parent: parent, layer: layer);
                allObjects[i] = renderObject.gameObject;

                if (staticBatching)
                    allObjects[i].gameObject.isStatic = true;
                info.vertexCount += meshes[i].vertices.Length;
                info.numMeshes++;
            }
            if (staticBatching)
                StaticBatchingUtility.Combine(allObjects, parent.gameObject);
            
            info.loadDuration = sw.ElapsedMilliseconds;
            return info;
        }
	}
}