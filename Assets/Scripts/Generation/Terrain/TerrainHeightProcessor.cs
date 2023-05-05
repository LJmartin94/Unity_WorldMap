using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class TerrainHeightProcessor : MonoBehaviour
{
    //[SerializeField] TerrainHeightSettings heightSettings;
    [SerializeField] ComputeShader heightMapCompute;
    [SerializeField] Texture2D heightMap;

    public RenderTexture processedHeightMap { get; private set; }

    public RenderTexture ProcessHeightMap()
    {
        const int worldHeightsKernel = 0;

        GraphicsFormat format = GraphicsFormat.R16_UNorm;
        processedHeightMap = ComputeHelper.CreateRenderTexture(heightMap.width, 
            heightMap.height, FilterMode.Bilinear, format, "World Heights", useMipMaps: true);

        return processedHeightMap;
    }

    private void OnDestroy()
    {
        Release();
    }
    public void Release()
    {
        ComputeHelper.Release(processedHeightMap);
        Resources.UnloadAsset(heightMap);
        heightMapCompute = null;
    }
}
