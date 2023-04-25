using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class MeshHelper
{
    static Material defaultMaterial;
    static Shader defaultShader;

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

    static Material GetDefaultMaterial()
    {
        if (defaultShader == null)
            defaultShader = Shader.Find("Unlit/Color");
        if (defaultMaterial == null || defaultMaterial.shader != defaultShader)
            defaultMaterial = new Material(defaultShader);
        return defaultMaterial;
    }
}