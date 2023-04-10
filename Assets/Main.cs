using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Main : MonoBehaviour
{
    public Material testMaterial;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello?");
        SimpleMeshData[] dice = CubeSphere.GenerateFaces(800);
        //Mesh mesh = MeshHelper.CreateMesh(dice[0]);
        //MeshHelper.CreateRendererObject("new", mesh, testMaterial);
        Debug.Log("Bye...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
