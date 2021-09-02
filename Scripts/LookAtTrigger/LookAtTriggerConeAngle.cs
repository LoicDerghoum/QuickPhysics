using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookAtTriggerConeAngle : MonoBehaviour
{
    public GameObject targetGameObject;

    public Color trueColor = new Color(255, 0, 0, 0.125f);
    public Color falseColor = new Color(98, 168, 200, 0.125f);
    public Color borderColor = new Color(0, 128, 255);

    [Range(0, 15)] public float distance = 5f;
    [Range(0, 360)] public float angle = 60f;

    [Range(-1, 2)] public float i = 0.5f;

    private void OnDrawGizmos()
    {
        Transform enemy = transform;
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = targetGameObject.transform.position;

        Vector3 ab = playerPos - enemyPos;
        float distSq = ab.x * ab.x + ab.y * ab.y;

        float opp = -Mathf.Sin((enemy.rotation.eulerAngles.z - angle / 2f) * QuickMath.Deg2Rad) * distance;
        float adj = Mathf.Cos((enemy.rotation.eulerAngles.z - angle / 2f) * QuickMath.Deg2Rad) * distance;
        Vector3 side = new Vector3(opp, adj, 0f);

        // a . b = || a || * || b || * cos(a,b)
        // a . b = a.x * b.x + a.y * b.y + a.z * b.z
        // cos(a,b) = cos(a.normalized, b.normalized)
        // cos(a,b) = arccos(a . b)
        float actualAngle = Mathf.Acos(Vector3.Dot(enemy.up.normalized, playerPos.normalized));

        #if UNITY_EDITOR

        if (actualAngle <= angle * QuickMath.Deg2Rad / 2 && distSq <= distance * distance)
            Handles.color = trueColor;
        else
            Handles.color = falseColor;

        Handles.DrawSolidArc(enemyPos, new Vector3(0, 0, 1), side, angle, distance);

        #endif
    }

    
}
