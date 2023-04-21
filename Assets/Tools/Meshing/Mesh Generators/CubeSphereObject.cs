using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphereObject
{
	//Variables for CubeSphere as non static class
	MeshFilter[] mesh;
    int divisions;
    SimpleMeshData[] info;

	//Constructor for non-static class
	public CubeSphereObject(MeshFilter[] meshFilter, int divs)
	{
        mesh = meshFilter;
        divisions = divs;
    }

	public void ConstructMesh(int resolution, Texture2D heightMap)
    {
        int chunks = 6 * (divisions + 1) * (divisions + 1);
		info = CubeSphere.GenerateFaces(resolution, divisions);
		for (int i = 0; i < chunks; i++)
		{
            mesh[i].sharedMesh.Clear();
            Vector3[] vertices = info[i].vertices;
            for (int v = 0; v < vertices.Length; v++)
            {
                LatLongDegr xy = GeoMaths.PointToLLR(vertices[v]).ConvertToDegr();
                int pixX = (int)((xy.longitude + 180) / 360 * heightMap.width);
                int pixY = (int)((xy.latitude + 90) / 180 * heightMap.height);
                float colour = heightMap.GetPixel(pixX, pixY).r + heightMap.GetPixel(pixX, pixY).g + heightMap.GetPixel(pixX, pixY).b;
                Debug.Log("Colour is: " + colour);
                float height = colour;

                //heightMap.GetPixel();
                vertices[v] = 1.0f * vertices[v] + 0.02f* vertices[v] * height;
            }
            mesh[i].sharedMesh.vertices = vertices;
            mesh[i].sharedMesh.triangles = info[i].triangles;
            mesh[i].sharedMesh.RecalculateNormals();

        }
	}
}
