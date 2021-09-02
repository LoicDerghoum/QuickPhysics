using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class QuickVector2
{

    private float _x;
    private float _y;

    public QuickVector2()
    {
        _x = 0;
        _y = 0;
    }

    public QuickVector2(float x)
    {
        _x = x;
        _y = 0;
    }

    public QuickVector2(float x, float y)
    {
        _x = x;
        _y = y;
    }

    public QuickVector2(float magnitude, float angle, bool coordUnknown = true)
    {
        _x = (float)Math.Cos(angle) * magnitude;
        _y = (float)Math.Sin(angle) * magnitude;
    }

    public float x
    {
        get { return _x; }
        set { _x = value; }
    }

    public float y
    {
        get { return _y; }
        set { _y = value; }
    }

    public static QuickVector2 zero
    {
        get { return new QuickVector2(0f, 0f); }
    }

    public static QuickVector2 one
    {
        get { return new QuickVector2(1f, 1f);  }
    }

    public static QuickVector2 up
    {
        get { return new QuickVector2(0f, 1f); }
    }

    public static QuickVector2 down
    {
        get { return new QuickVector2(0f, -1f); }
    }

    public static QuickVector2 left
    {
        get { return new QuickVector2(-1f, 0f); }
    }

    public static QuickVector2 right
    {
        get { return new QuickVector2(1f, 0f); }
    }

    public QuickVector2 normalize
    {
        get
        {
            float magnitude = Magnitude();

            if (magnitude != 0)
                return new QuickVector2(x / magnitude, y / magnitude);
            else
                return new QuickVector2(0f, 0f);
        }
    }

    public float magnitudeSq
    {
        get { return x * x + y * y; }
    }

    public float magnitude
    {
        get { return QuickMath.Sqrt(magnitudeSq); }
    }

    public float min
    {
        get
        {
            return QuickMath.Min(x, y);
        }
    }

    public float max
    {
        get
        {
            return QuickMath.Max(x, y);
        }
    }

    public static float Dot(QuickVector2 a, QuickVector2 b)
    {
        return a.x * b.x + a.y * b.y;
    }

    public static float Distance(QuickVector2 a, QuickVector2 b)
    {
        QuickVector2 ab = new QuickVector2(b.x - a.x, b.y - a.y);

        return ab.Magnitude();
    }

    public static QuickVector2 Lerp(QuickVector2 a, QuickVector2 b, float t, bool isClamped = true)
    {
        float lerpX = QuickMath.Lerp(a.x, b.x, t, isClamped);
        float lerpY = QuickMath.Lerp(a.y, b.y, t, isClamped);

        return new QuickVector2(lerpX, lerpY);
    }

    public float Angle()
    {
        return (float) Math.Atan(y / x);
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

    public QuickVector2 Normalize()
    {
        return normalize;
    }

    public QuickVector2 Scale(float a)
    {
        return new QuickVector2(x * a, y * a);
    }

    public Vector2 ConvertToVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ConvertToVector3()
    {
        return new Vector3(x, y, 0);
    }

    public Vector4 ConvertToVector4()
    {
        return new Vector4(x, y, 0, 0);
    }
}
