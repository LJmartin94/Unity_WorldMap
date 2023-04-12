using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphereObject
{
	//Variables for CubeSphere as non static class
	MeshFilter[] mesh;
    SimpleMeshData[] info;

	//Constructor for non-static class
	public CubeSphereObject(MeshFilter[] meshFilter)
	{
        mesh = meshFilter;
    }

	public void ConstructMesh(int resolution)
    {
		info = CubeSphere.GenerateFaces(resolution);
		for (int i = 0; i < 6; i++)
		{
            mesh[i].sharedMesh.Clear();
            mesh[i].sharedMesh.vertices = info[i].vertices;
            mesh[i].sharedMesh.triangles = info[i].triangles;
            mesh[i].sharedMesh.RecalculateNormals();
		}
	}
}
