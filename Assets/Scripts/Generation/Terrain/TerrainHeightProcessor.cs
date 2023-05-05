using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeightProcessor : MonoBehaviour
{
    //[SerializeField] TerrainHeightSettings heightSettings;
    [SerializeField] ComputeShader heightMapCompute;
    [SerializeField] Texture2D heightMap;

    public RenderTexture processedHeightMap { get; private set; }

    public RenderTexture ProcessHeightMap()
    {
        return processedHeightMap;
    }

    private void OnDestroy()
    {
        Release();
    }
    public void Release()
    {
        //ComputeHelper.Release(processedHeightMap);
        Resources.UnloadAsset(heightMap);
        heightMapCompute = null;
    }
}
