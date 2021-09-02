using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class QuickVector3
{
    private float _x;
    private float _y;
    private float _z;

    public QuickVector3()
    {
        _x = 0;
        _y = 0;
        _z = 0;
    }

    public QuickVector3(float x)
    {
        _x = x;
        _y = 0;
        _z = 0;
    }

    public QuickVector3(float x, float y)
    {
        _x = x;
        _y = y;
        _z = 0;
    }

    public QuickVector3(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public float x
    {
        get { return _x; }
        set { _x = value;  }
    }

    public float y
    {
        get { return _y; }
        set { _y = value; }
    }

    public float z
    {
        get { return _z; }
        set { _z = value; }
    }

    public static QuickVector3 zero
    {
        get { return new QuickVector3(0f, 0f, 0f) ; }
    }

    public static QuickVector3 one
    {
        get { return new QuickVector3(1f, 1f, 1f); }
    }

    public QuickVector3 normalize
    {
        get
        {
            float magnitude = Magnitude();

            if (magnitude != 0)
                return new QuickVector3(x / magnitude, y / magnitude, z / magnitude);
            else
                return new QuickVector3(0f, 0f, 0f);
        }
    }

    public float magnitudeSq
    {
        get { return x * x + y * y + z * z; }
    }

    public float magnitude
    {
        get { return QuickMath.Sqrt(magnitudeSq); }
    }

    public float min
    {
        get
        {
            return QuickMath.Min(x, QuickMath.Min(y, z));
        }
    }

    public float max
    {
        get
        {
            return QuickMath.Max(x, QuickMath.Max(y, z));
        }
    }

    public static float Dot(QuickVector3 a, QuickVector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    public static QuickVector3 Cross(QuickVector3 a, QuickVector3 b)
    {
        float x1 = a.x;
        float y1 = a.y;
        float z1 = a.z;

        float x2 = b.x;
        float y2 = b.y;
        float z2 = b.z;

        float xCross = y1 * z2 - z1 * y2;
        float yCross = z1 * x2 - x1 * z2;
        float zCross = x1 * y2 - y1 * x2;

        return new QuickVector3(xCross, yCross, zCross);
    }

    public static float Distance(QuickVector3 a, QuickVector3 b)
    {
        QuickVector3 ab = new QuickVector3(b.x - a.x, b.y - a.y, b.z - a.z);

        return ab.Magnitude();
    }

    public static QuickVector3 Lerp(QuickVector3 a, QuickVector3 b, float t, bool isClamped = true)
    {
        float lerpX = QuickMath.Lerp(a.x, b.x, t, isClamped);
        float lerpY = QuickMath.Lerp(a.y, b.y, t, isClamped);
        float lerpZ = QuickMath.Lerp(a.z, b.z, t, isClamped);

        return new QuickVector3(lerpX, lerpY, lerpZ);
    }

    public float MagnitudeSq()
    {
        return magnitudeSq;
    }

    public float Magnitude()
    {
        return magnitude;
    }

    public float Min()
    {
        return min;
    }

    public float Max()
    {
        return max;
    }

    public QuickVector3 Normalize()
    {
        return normalize;
    }

    public QuickVector3 Scale(float a)
    {
        return new QuickVector3(x * a, y * a, z * a);
    }

    public Vector3 ConvertToVector3()
    {
        return new Vector3(x, y, z);
    }

    public Vector4 ConvertToVector4()
    {
        return new Vector4(x, y, z, 0);
    }
}
