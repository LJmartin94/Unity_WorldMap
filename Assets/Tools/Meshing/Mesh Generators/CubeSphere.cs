using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class CubeSphere
{
	public static SimpleMeshData[] GenerateFaces(int resolution)
	{
		SimpleMeshData[] all = new SimpleMeshData[6];
		Vector3[] cubeFaces =
		{
			Vector3.up,
			Vector3.down,
			Vector3.left,
			Vector3.right,
			Vector3.forward,
			Vector3.back
		};

		for (int i = 0; i < cubeFaces.Length; i++)
		{
			all[i] = CreateFace(cubeFaces[i], resolution);
		}
		return all;
	}
	static SimpleMeshData CreateFace(Vector3 normal, int resolution) //Vector2 startT, Vector2 endT, float radius)
	{
		// For every face of e.g. a cube, axisA & B are the dimensions
		// that express the width and length of a plane with that facing. 
		Vector3 axisA = new Vector3(normal.y, normal.z, normal.x);
		Vector3 axisB = Vector3.Cross(normal, axisA);
		
		int numVerts = resolution * resolution;
		Vector3[] vertices = new Vector3[numVerts];

		// (Resolution - 1)^2 is number of squares on a face.
		// Each square is 2 triangles with 3 vertices = 6.
		int numTris = (resolution - 1) * (resolution - 1) * 6; 
		int[] triangles = new int[numTris];
		int triIndex = 0;

		//Vector4[] uvs = new Vector4[numVerts];
		//Vector3[] normals = new Vector3[numVerts];

		//float ty = startT.y;
		//float dx = (endT.x - startT.x) / (resolution - 1);
		//float dy = (endT.y - startT.y) / (resolution - 1);

		for (int y = 0; y < resolution; y++)
		{
			//float tx = startT.x;
			for (int x = 0; x < resolution; x++)
			{
				//uv-mapping: keeps track of what 'percentage done' the loop is between 0 and 1.
				Vector2 uv = new Vector2(x / (resolution - 1f), y / (resolution - 1f));
				
				// We move 1 unit along localUp (normal) to get from centre of cube to the face we want.
				// Then we translate uv from a val between 0 and 1 to a value between -1 and 1,
				// and multiply it by its local x y equivalents.
				Vector3 pointOnUnitCube = normal + axisA * (2 * uv.x - 1) + axisB * (2 * uv.y - 1);
				
				int vertexIndex = x + y * resolution;
				vertices[vertexIndex] = pointOnUnitCube;

				//Vector3 pointOnUnitSphere = CubePointToSpherePoint(pointOnUnitCube);

				//vertices[vertexIndex] = pointOnUnitSphere * radius;
				//normals[vertexIndex] = pointOnUnitSphere;
				//uvs[vertexIndex] = uv;

				if (x != resolution - 1 && y != resolution - 1)
				{
					//Stores all three points of each of the
					//two triangles in a square, in clockwise order.
					triangles[triIndex] = vertexIndex;
					triangles[triIndex + 1] = vertexIndex + resolution + 1;
					triangles[triIndex + 2] = vertexIndex + resolution;

					triangles[triIndex + 3] = vertexIndex;
					triangles[triIndex + 4] = vertexIndex + 1;
					triangles[triIndex + 5] = vertexIndex + resolution + 1;
					triIndex += 6;
				}
				//tx += dx;
			}
			//ty += dy;
		}
		SimpleMeshData ret = new SimpleMeshData(vertices, triangles); //, normals, uvs, "Sphere Cube Face");
		//ret.tempMesh.Clear();
		//ret.tempMesh.vertices = vertices;
		//ret.tempMesh.triangles = triangles;
		//ret.tempMesh.RecalculateNormals();
		return ret; 
	}
}
