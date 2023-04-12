using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

[System.Serializable]
public struct LatLongDegr //stored in degrees
{
    // You can go 90degr north from the Equator before you start heading south.
    // You can go 180degr west from the Prime Meridian before you start heading east.
    // This is why the range for longitude is twice that of latitude.

    [Range(-90, 90)]
    public float latitude; //degrees north or south
    [Range(-180, 180)]
    public float longitude; //degrees east or west

    public LatLongDegr(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public LatLongRad ConvertToRad()
    {
        return new LatLongRad(latitude * Deg2Rad, longitude * Deg2Rad);
    }
}

// Remember:
// Radians == the angle traced by 1 radius in length across the circle's circumference.
// Such that there are PI radians in half a circle.
[System.Serializable]
public struct LatLongRad //stored in radians
{
    // You can go 90degr north from the Equator before you start heading south.
    // You can go 180degr west from the Prime Meridian before you start heading east.
    // This is why the range for longitude is twice that of latitude.

    [Range(-PI / 2, PI / 2)] 
    public float latitude; //rad north or south
    [Range(-PI, PI)]
    public float longitude; //rad east or west

    public LatLongRad(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public LatLongDegr ConvertToDegr()
    {
        return new LatLongDegr(latitude * Rad2Deg, longitude * Rad2Deg);
    }
}