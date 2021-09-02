using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class QuickMath
{
    public const float epsilon = 0.01f;

    public const float PI = 3.141592654f;
    public const float Deg2Rad = 0.0174532925f;
    public const float Rad2Deg = 57.29577951f;

    public static int Sign(float val)
    {
        if (val == 0)
            return 0;

        return val >= 0 ? 1 : -1;
    }

    private static float AltAbs(float val)
    {
        return val * Sign(val);
    }

    public static float Abs(float val)
    {
        return val > 0 ? val : -val;
    }

    public static float Pow(float a, int pow) // only works with int pow
    {
        float x = 1;

        if (pow < 0)
            a = 1 / a;

        for (int i = 0; i < Abs(pow); i++)
        {
            x *= a;
        }

        return x;
    }

    public static bool Approximately(float a, float b, float epsilon = epsilon)
    {
        // b - e < a < b + e
        bool approx = false;

        if (a >= (b - epsilon) && a <= (b + epsilon))
            approx = true;

        return approx;
    }

    public static int Int(float val)
    {
        return (int)val;
    }

    public static float Min(float a, float b)
    {
        if (a <= b)
            return a;
        else
            return b;
    }

    public static float Max(float a, float b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }

    public static int Floor(float val)
    {
        return Int(val) >= 0 ? Int(val) : Int(val) - 1;
    }

    public static int Ceil(float val)
    {
        return Int(val) >= 0 ? Int(val) + 1 : Int(val);
    }

    public static int Round(float val)
    {
        float _decimal = val * 10 % 10;
        return Abs(Int(_decimal)) >= 5 ? Int(val) + Sign(val) : Int(val);
    }

    public static float Sqrt(float t)
    {
        float r = t / 2;
        for (int i = 0; i <= 10; i++)
        {
            r = (r + t / r) / 2;
        }
        return r;
    }

    public static float Clamp(float min, float max, float val)
    {
        if (val > max)
            val = max;
        else if (val < min)
            val = min;

        return val;
    }

    public static float Lerp(float min, float max, float val, bool isClamped = true)
    {
        if (isClamped)
            val = Clamp(0, 1, val);

        float lerp = (max - min) * val + min;

        return lerp;
    }

    public static float Remap(float minA, float maxA, float minB, float maxB, float val, bool isClamped = true)
    {

        float x = ((val - minA) / (maxA - minA) * (maxB - minB) + minB);

        if (isClamped)
            x = Clamp(x, minB, maxB);

        return x;
    }

    public static Vector2 AngleToVector2(float magnitude, float angle, bool angleInDeg = false)
    {
        if (angleInDeg)
            angle *= Deg2Rad;

        angle -= PI / 2; // Because unit circle start in (0, 1) instead of (1, 0);
        magnitude *= -1; // Because unit circle is reversed;

        float opp = (float) Math.Sin(-angle) * -magnitude;
        float adj = (float) Math.Cos(-angle) * -magnitude;

        return new Vector2(opp,adj);
    }

    private static float Vector2ToAngle(Vector2 vector, bool inDeg = false)
    {
        float deg = (float) Math.Atan(vector.y / vector.x);

        if (inDeg)
            deg *= Rad2Deg;

        return deg;
    }

    private static float Vector2Magnitude(Vector2 vector)
    {
        float magnitudeSq = vector.x * vector.x + vector.y * vector.y;
        return Sqrt(magnitudeSq);
    }

    private static float Vector3Magnitude(Vector3 vector)
    {
        float magnitudeSq = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        return Sqrt(magnitudeSq);
    }

    private static float Vector4Magnitude(Vector4 vector)
    {
        float magnitudeSq = vector.x * vector.x + vector.y * vector.y + vector.z * vector.z + vector.w * vector.w;
        return Sqrt(magnitudeSq);
    }



}
