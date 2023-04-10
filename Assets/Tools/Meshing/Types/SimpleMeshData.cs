using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for holding data for a 'simple' mesh.
public class SimpleMeshData
{
    public string name;

    public int[] triangles = new int[0];
    public Vector3[] vertices = new Vector3[0];
    public Vector3[] normals = new Vector3[0];
    public Vector4[] texCoords = new Vector4[0];

    //Constructor (full):
    public SimpleMeshData(Vector3[] vertices, int[] triangles, Vector3[] normals, Vector4[] texCoords, string name = "Mesh")
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.normals = normals;
        this.texCoords = texCoords;
        this.name = name;
    }

    //Constructor (simplified):
    public SimpleMeshData(Vector3[] vertices, int[] triangles, string name = "Mesh")
    {
        this.vertices = vertices;
        this.triangles = triangles;
        this.name = name;
    }
}