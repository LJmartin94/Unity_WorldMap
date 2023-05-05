using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : Generator
{
    //Generation result
    List<SimpleMeshData> allCombinedMeshes;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void StartGenerating()
    {
        startGenerationState();

        allCombinedMeshes = new List<SimpleMeshData>();
        RenderTexture heightMap;


    }
    public override void Save()
    {
    }
    public override void Load()
    {
    }
}
