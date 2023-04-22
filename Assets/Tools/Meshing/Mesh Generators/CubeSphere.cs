using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;



public static class CubeSphere
{
	//Resolution = number of vertex-points per axis of a (sub)face (e.g. simplest cube == 2)
	//Divisions = number of times a face on the cube is divided (e.g. for 6 faced 'regular' cube == 0 divisions but for 2x2 subfaces per face == 1 division).
	//Radius = how much to inflate the unit sphere by.
	public static SimpleMeshData[] GenerateFaces(int resolution, int divisions = 0, float radius = 1)
	{
		//divisions are cuts per axis. 0 means whole. 1 means halved lengthways and width ways.
		int subfaces = (divisions + 1) * (divisions + 1);	// 1,   4,   9,  16...
		float axisFraction = 1f / (divisions + 1);			// 1, 1/2, 1/3, 1/4...
		SimpleMeshData[] all = new SimpleMeshData[6 * subfaces];
		int m = 0; //mesh index
		Vector3[] cubeFaces =
		{
			Vector3.up,
			Vector3.left,
			Vector3.back,
			Vector3.right,
			Vector3.forward,
			Vector3.down,
		};

		for (int f = 0; f < cubeFaces.Length; f++) // all main faces
		{
			for (int y = 0; y < (divisions + 1); y++) //all subfaces along y
            {
				for (int x = 0; x < (divisions + 1); x++) //all subfaces along x
				{
					Vector2 sfStart = new Vector2(x, y) * axisFraction;
					Vector2 sfEnd = new Vector2(x + 1, y + 1) * axisFraction;
					all[m] = CreateFace(cubeFaces[f], resolution, sfStart, sfEnd, radius);
					m++;
				}
			}
		}
		return all;
	}
	static SimpleMeshData CreateFace(Vector3 normal, int resolution, Vector2 start, Vector2 end, float radius)
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

        Vector4[] uvs = new Vector4[numVerts];
        Vector3[] normals = new Vector3[numVerts];

        int vertexIndex = 0;
		for (int y = 0; y < resolution; y++)
		{
			for (int x = 0; x < resolution; x++)
			{
                //uv-mapping: keeps track of what 'percentage done' the loop is between 0 and 1.
                Vector2 uv = new Vector2(x, y) / (resolution - 1f);
                uvs[vertexIndex] = uv;

                //when dealing with subfaces:
                //take start as offset.
                //take end - start as distance to cover
                //multiply this by old uv as 'percentage done'
				uv = start + (end - start) * uv;

				// We move 1 unit along localUp (normal) to get from centre of cube to the face we want.
				// Then we translate uv from a val between 0 and 1 to a value between -1 and 1,
				// and multiply it by its local x y equivalents.
				Vector3 pointOnUnitCube = normal + axisA * (2 * uv.x - 1) + axisB * (2 * uv.y - 1);

				Vector3 pointOnUnitSphere = CubeToSpherePoint(pointOnUnitCube);
                vertices[vertexIndex] = pointOnUnitSphere * radius;
                normals[vertexIndex] = pointOnUnitSphere;

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
                vertexIndex++;
            }
		}
		SimpleMeshData ret = new SimpleMeshData(vertices, triangles, normals, uvs, "Sphere Cube Face");
		return ret; 
	}

	public static Vector3 CubeToSpherePoint(Vector3 cubePoint)
    {
		Vector3 ret;

        ////Simple way of converting cube to sphere:
        ////divide vector by its own length, so all points are 1 unit away from centre.
        //ret = cubePoint.normalized;

        // Using method at: http://mathproofs.blogspot.com/2005/07/mapping-cube-to-sphere.html
		// This makes points closer to the cube's seams a little less clustered.
        float x2 = cubePoint.x * cubePoint.x;
        float y2 = cubePoint.y * cubePoint.y;
        float z2 = cubePoint.z * cubePoint.z;

        ret.x = cubePoint.x * (float)Sqrt(1 - (y2 + z2) / 2 + (y2 * z2) / 3);
        ret.y = cubePoint.y * (float)Sqrt(1 - (x2 + z2) / 2 + (x2 * z2) / 3);
        ret.z = cubePoint.z * (float)Sqrt(1 - (x2 + y2) / 2 + (x2 * y2) / 3);
        return ret;
    }

	//public static Vector3 SpherePointToCubePoint(Vector3 p)
	//{
	//	float absX = Mathf.Abs(p.x);
	//	float absY = Mathf.Abs(p.y);
	//	float absZ = Mathf.Abs(p.z);

	//	if (absY >= absX && absY >= absZ)
	//	{
	//		return CubifyFace(p);
	//	}
	//	else if (absX >= absY && absX >= absZ)
	//	{
	//		p = CubifyFace(new Vector3(p.y, p.x, p.z));
	//		return new Vector3(p.y, p.x, p.z);
	//	}
	//	else
	//	{
	//		p = CubifyFace(new Vector3(p.x, p.z, p.y));
	//		return new Vector3(p.x, p.z, p.y);
	//	}
	//}

	//// Thanks to http://petrocket.blogspot.com/2010/04/sphere-to-cube-mapping.html
	//static Vector3 CubifyFace(Vector3 p)
	//{
	//	const float inverseSqrt2 = 0.70710676908493042f;

	//	float a2 = p.x * p.x * 2.0f;
	//	float b2 = p.z * p.z * 2.0f;
	//	float inner = -a2 + b2 - 3;
	//	float innersqrt = -Mathf.Sqrt((inner * inner) - 12.0f * a2);

	//	if (p.x != 0)
	//	{
	//		p.x = Mathf.Min(1, Mathf.Sqrt(innersqrt + a2 - b2 + 3.0f) * inverseSqrt2) * Mathf.Sign(p.x);
	//	}

	//	if (p.z != 0)
	//	{
	//		p.z = Mathf.Min(1, Mathf.Sqrt(innersqrt - a2 + b2 + 3.0f) * inverseSqrt2) * Mathf.Sign(p.z);
	//	}

	//	// Top/bottom face
	//	p.y = Mathf.Sign(p.y);

	//	return p;
	//}

}
