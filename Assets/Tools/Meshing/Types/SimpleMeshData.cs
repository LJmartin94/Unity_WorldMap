using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for holding data for a 'simple' mesh.
[System.Serializable]
public class SimpleMeshData
{
    public string name;

    public Mesh tempMesh;

    public int[] triangles = new int[0];
    public Vector3[] vertices = new Vector3[0];
    public Vector3[] normals = new Vector3[0];
    public Vector4[] texCoords = new Vector4[0];

    //Constructor (only name)
    public SimpleMeshData(string name)
    {
        this.name = name;
    }

    //Constructor (full):
    public SimpleMeshData(Vector3[] vertices, int[] triangles, Vector3[] normals, Vector4[] texCoords, string name = "Mesh")
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.normals = normals;
        this.texCoords = texCoords;
        this.name = name;
    }

    //Constructor (no texCoords)
    public SimpleMeshData(Vector3[] vertices, int[] triangles, Vector3[] normals, string name = "Mesh")
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.normals = normals;
        this.name = name;
    }

    //Constructor (no normals or texCoords):
    public SimpleMeshData(Vector3[] vertices, int[] triangles, string name = "Mesh")
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.name = name;
    }
}