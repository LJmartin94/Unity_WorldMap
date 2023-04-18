using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlanetScript : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;

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
        if (meshFilters == null || meshFilters.Length == 0)
            meshFilters = new MeshFilter[6];

        Material defaultMat = new Material(Shader.Find("Standard"));
        for (int i=0; i<6; i++)
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
        terrainFaces = new CubeSphereObject(meshFilters);
    }

    void GenerateMesh()
    {
        terrainFaces.ConstructMesh(resolution, heightMap);
    }
}
