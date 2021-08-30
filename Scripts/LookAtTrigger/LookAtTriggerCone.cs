using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LookAtTriggerCone : MonoBehaviour
{
    public GameObject targetGameObject;

    public Color trueColor = new Color(255, 0, 0, 0.125f);
    public Color falseColor = new Color(98, 168, 200, 0.125f);
    public Color borderColor = new Color(0, 128, 255);

    [Range(0, 15)]
    public float distance = 5f;
    [Range(0, 360)]
    public float angle = 60;

    private void OnDrawGizmos()
    {
        Vector3 enemy = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;
        Vector3 target = targetGameObject.transform.position;

        float opp = -Mathf.Sin(rotation.z * Mathf.Deg2Rad) * distance; // x  Center
        float adj = Mathf.Cos(rotation.z * Mathf.Deg2Rad) * distance; // y

        float leftOpp = - Mathf.Sin((rotation.z + (angle / 2)) * Mathf.Deg2Rad) * distance; // x
        float leftAdj = Mathf.Cos((rotation.z + (angle / 2)) * Mathf.Deg2Rad) * distance; // y

        float rightOpp = - Mathf.Sin((rotation.z - (angle / 2)) * Mathf.Deg2Rad) * distance; // x
        float rightAdj = Mathf.Cos((rotation.z - (angle / 2)) * Mathf.Deg2Rad) * distance; // y

        Vector3 center = new Vector3(opp, adj);
        Vector3 leftEdge = new Vector3(leftOpp, leftAdj, 0);
        Vector3 rightEdge = new Vector3(rightOpp, rightAdj, 0);

        Vector3 ab = new Vector3(target.x - enemy.x, target.y - enemy.y, 0);

        float distSq = (ab.x * ab.x) + (ab.y * ab.y);

        //Handles.color = Color.green;
        //Handles.DrawLine(transform.position, center);

        if (distSq <= distance * distance && - Vector3.Cross(leftEdge, ab).z >= 0f && Vector3.Cross(rightEdge, ab).z >= 0f)
            Handles.color = trueColor;
        else
            Handles.color = falseColor;

        //Handles.DrawLine(enemy, ab);
        //Handles.DrawLine(enemy, leftEdge);
        //Handles.DrawLine(enemy, rightEdge);

        //Handles.DrawLine(leftEdge, rightEdge);
        Handles.DrawSolidArc(enemy, new Vector3(0, 0, 1), rightEdge, angle, distance);
    }
}
