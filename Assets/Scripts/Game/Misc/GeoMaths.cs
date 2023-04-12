using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class GeoMaths
{
    public static LatLongRad PointToLLR(Vector3 pointOnUnitSphere)
    {
        //Asin == inverse sine -> returns the angle, in radians, for a given opposite/hypothenuse ratio
        float lat = Asin(pointOnUnitSphere.y);
        //Atan2 == arctan == inverse tangent -> returns counterclockwise angle between the positive x-axis and the point (y, x)
        float l0ng = Atan2(pointOnUnitSphere.x, -pointOnUnitSphere.z); 
        
        return new LatLongRad(lat, l0ng);
    }

    public static Vector3 LLRToPoint(LatLongRad latlong)
    {
        Vector3 ret = new Vector3();
        //r is the radius of a circle cut through the globe at y.
        float r = Cos(latlong.latitude);
        ret.x = Sin(latlong.longitude) * r;
        ret.y = Sin(latlong.latitude);
        ret.z = -Cos(latlong.longitude) * r;
        return ret;
    }
}
