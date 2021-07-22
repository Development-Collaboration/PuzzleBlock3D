using UnityEngine;

public class PointsInTime
{
    // Transform
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    //
    public int movementCounts;

    /*
    public PointsInTime(Vector3 _position, Quaternion _rotation, Vector3 _scale,
        int _movementCounts)
    {
        position = _position;
        rotation = _rotation;
        scale = _scale;

        movementCounts = _movementCounts;
    }
    */

    public PointsInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
