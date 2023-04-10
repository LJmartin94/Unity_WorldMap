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
		Vector3 axisA = new Vector3(normal.y, normal.z, normal.x);
		Vector3 axisB = Vector3.Cross(normal, axisA);
		
		int numVerts = resolution * resolution;
		Vector3[] vertices = new Vector3[numVerts];

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
				int vertexIndex = x + y * resolution;
				Vector2 uv = new Vector2(x / (resolution - 1f), y / (resolution - 1f));
				Vector3 pointOnUnitCube = normal + axisA * (2 * uv.x - 1) + axisB * (2 * uv.y - 1);
				vertices[vertexIndex] = pointOnUnitCube;

				//Vector3 pointOnUnitSphere = CubePointToSpherePoint(pointOnUnitCube);

				//vertices[vertexIndex] = pointOnUnitSphere * radius;
				//normals[vertexIndex] = pointOnUnitSphere;
				//uvs[vertexIndex] = uv;

				if (x != resolution - 1 && y != resolution - 1)
				{
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
		return new SimpleMeshData(vertices, triangles); //, normals, uvs, "Sphere Cube Face");
	}
}
