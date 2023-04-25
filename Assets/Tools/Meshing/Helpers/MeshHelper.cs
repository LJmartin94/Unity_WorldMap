using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class MeshHelper
{
    static Material defaultMaterial;
    static Shader defaultShader;

    static Material GetDefaultMaterial()
    {
        if (defaultShader == null)
            defaultShader = Shader.Find("Unlit/Color");
        if (defaultMaterial == null || defaultMaterial.shader != defaultShader)
            defaultMaterial = new Material(defaultShader);
        return defaultMaterial;
    }

    public static RenderObject CreateRenderObject(string name,
                                                  SimpleMeshData meshData,
                                                  Material mat = null,
                                                  Transform parent = null,
                                                  int layer = 0)
    {
        Mesh mesh = CreateMesh(meshData); //Convert SimpleMeshData to Mesh
        return CreateRenderObject(name, mesh, mat, parent, layer); //then proceed with the below.
    }

    // Create GameObject with mesh renderer and filter components applied
    public static RenderObject CreateRenderObject(string name, 
                                                  Mesh mesh = null, 
                                                  Material mat = null, 
                                                  Transform parent = null, 
                                                  int layer = 0)
    {
        GameObject meshHolder = new GameObject(name);
        MeshFilter meshFilter = meshHolder.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = meshHolder.AddComponent<MeshRenderer>();

        if (mat == null)
            mat = GetDefaultMaterial();

        //When the application is running we reference an instance of the mesh directly,
        //otherwise we reference the shared mesh, which governs all instances.
        if (Application.isPlaying)
        {
            meshFilter.mesh = mesh;
            meshRenderer.material = mat;
        }
        else
        {
            meshFilter.sharedMesh = mesh;
            meshRenderer.sharedMaterial = mat;
        }

        meshHolder.transform.parent = parent;
        meshHolder.layer = layer;

        RenderObject ret = new RenderObject(meshHolder, meshRenderer, meshFilter, mat);
        return ret;
    }

    //Polymorphic version that allows function to be called without reference mesh.
    public static Mesh CreateMesh(SimpleMeshData meshData, bool recalcNormals = false)
    {
        Mesh mesh = new Mesh();
        CreateMesh(ref mesh, meshData, recalcNormals);
        return mesh;
    }

    //Main version of the CreateMesh function, which requires a reference Mesh.
    public static void CreateMesh(ref Mesh mesh, SimpleMeshData meshData, bool recalcNormals = false)
    {
        if (mesh == null)
            mesh = new Mesh();
        else
            mesh.Clear();

        mesh.name = meshData.name;
        
        int numVertices = meshData.vertices.Length;
        const int max16bit = (1 << 16) - 1; // Max value you can store in a signed 16 bit int.
        mesh.indexFormat = (numVertices <= max16bit) ? IndexFormat.UInt16 : IndexFormat.UInt32;

        mesh.SetVertices(meshData.vertices);
        mesh.SetTriangles(meshData.triangles, submesh: 0, calculateBounds: true);

        if (recalcNormals)
            mesh.RecalculateNormals();
        else if (meshData.normals.Length == numVertices)
            mesh.SetNormals(meshData.normals);

        if (meshData.texCoords.Length == numVertices)
            mesh.SetUVs(0, meshData.texCoords);
    }
}