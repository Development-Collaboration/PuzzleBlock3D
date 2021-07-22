using UnityEngine;

public class PointsInTime
{
    // Transform
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
 
    public PointsInTime(Vector3 _position, Quaternion _rotation, Vector3 _sacle)
    {
        position = _position;
        rotation = _rotation;
        scale = _sacle;

    }
}
