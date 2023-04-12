using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSphereObject
{
	//Variables for CubeSphere as non static class
	MeshFilter[] mesh;
	//int[] resolution;
	//Vector3[] localUp;
	//Vector3[] axisA;
	//Vector3[] axisB;
	SimpleMeshData[] info;

	//Constructor for non-static class
	public CubeSphereObject(MeshFilter[] mesh, int resolution)
	{
		this.mesh = mesh;
		//this.resolution = new int[6];
		//this.localUp = normal;
		//this.axisA = new Vector3[6];
		//this.axisB = new Vector3[6];

		//for (int i = 0; i < 6; i++)
	 //   {
		//	this.resolution[i] = resolution;
		//	this.axisA[i] = new Vector3(localUp[i].y, localUp[i].z, localUp[i].x);
		//	this.axisB[i] = Vector3.Cross(localUp[i], axisA[i]);
		//}

		//this.info = CubeSphere.GenerateFaces(resolution);
		//for (int i = 0; i < 6; i++)
  //      {
		//	this.mesh[i].sharedMesh.Clear();
		//	this.mesh[i].sharedMesh.vertices = info[i].vertices;
		//	this.mesh[i].sharedMesh.triangles = info[i].triangles;
		//	this.mesh[i].sharedMesh.RecalculateNormals();
  //      }
	}
	public void ConstructMesh(int resolution)
    {
		this.info = CubeSphere.GenerateFaces(resolution);
		for (int i = 0; i < 6; i++)
		{
			this.mesh[i].sharedMesh.Clear();
			this.mesh[i].sharedMesh.vertices = info[i].vertices;
			this.mesh[i].sharedMesh.triangles = info[i].triangles;
			this.mesh[i].sharedMesh.RecalculateNormals();
		}
	}
}
