using UnityEngine;

public static class MatrixExtensions
{
    public static Vector3 ExtractPosition(this Matrix4x4 _matrix)
    {
        Vector3 position;
        position.x = _matrix.m03;
        position.y = _matrix.m13;
        position.z = _matrix.m23;
        return position;
    }

    public static Quaternion ExtractRotation(this Matrix4x4 _matrix)
    {
        Vector3 forward;
        forward.x = _matrix.m02;
        forward.y = _matrix.m12;
        forward.z = _matrix.m22;

        Vector3 upwards;
        upwards.x = _matrix.m01;
        upwards.y = _matrix.m11;
        upwards.z = _matrix.m21;

        return Quaternion.LookRotation(forward, upwards);
    }

    public static Vector3 ExtractScale(this Matrix4x4 _matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(_matrix.m00, _matrix.m10, _matrix.m20, _matrix.m30).magnitude;
        scale.y = new Vector4(_matrix.m01, _matrix.m11, _matrix.m21, _matrix.m31).magnitude;
        scale.z = new Vector4(_matrix.m02, _matrix.m12, _matrix.m22, _matrix.m32).magnitude;
        return scale;
    }

    public static bool ApproxEqual(this Matrix4x4 _matrix, Matrix4x4 _other, float _epsilon)
    {
        for (var i = 0; i < 16; i++)
        {
            if (Mathf.Abs(_matrix[i] - _other[i]) > _epsilon)
                return false;
        }

        return true;
    }
}
