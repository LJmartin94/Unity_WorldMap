using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RenderObject
{
    public readonly GameObject gameObject;
    public readonly MeshRenderer renderer;
    public readonly MeshFilter filter;
    public readonly Material mat;

    public RenderObject(GameObject gameObject, 
                        MeshRenderer renderer, 
                        MeshFilter filter, 
                        Material mat)
    {
        this.gameObject = gameObject;
        this.renderer = renderer;
        this.filter = filter;
        this.mat = mat;
    }
}