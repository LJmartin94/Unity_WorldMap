using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TempPlanetScript : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 70;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    CubeSphereObject terrainFaces;
    [SerializeField] Texture2D heightMap;
    

    private void OnValidate()
    {
        Initialise();
        GenerateMesh();
    }

    void Initialise()
    {
        int divisions = 4;
        int chunks = 6 * (divisions + 1) * (divisions + 1);
        if (meshFilters == null || meshFilters.Length == 0)
            meshFilters = new MeshFilter[chunks];

        Material defaultMat = new Material(Shader.Find("Standard"));
        for (int i=0; i < chunks; i++)
        {
            if (meshFilters[i] == null)
            { 
                GameObject meshObject = new GameObject("mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = defaultMat;
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
        }
        terrainFaces = new CubeSphereObject(meshFilters, divisions);
    }

    void GenerateMesh()
    {
        byte[] serialisedMeshes = terrainFaces.ConstructMesh(resolution, heightMap);
        File.WriteAllBytes("./Assets/TempFiles/myMeshes.bytes", serialisedMeshes);
    }
}
