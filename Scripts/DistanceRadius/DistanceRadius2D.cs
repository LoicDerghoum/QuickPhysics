using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DistanceRadius2D : MonoBehaviour
{
    public GameObject target;

    public Color trueColor = Color.red;
    public Color falseColor = Color.green;

    [Range(0, 10)]
    public float radius;

    private void OnDrawGizmos()
    {
        Vector3 enemy = transform.position; // a
        Vector3 player = target.transform.position; // b

        Vector3 ab = new Vector3(player.x - enemy.x, player.y - enemy.y);

        //float dist = Vector3.Distance(a, b);

        float distSq = (ab.x * ab.x) + (ab.y * ab.y);

        if (distSq <= (radius * radius)) // faster because no square root
            Handles.color = trueColor;
        else
            Handles.color = falseColor;

        Handles.DrawWireDisc(enemy, new Vector3(0, 0, 1), radius);

        Handles.DrawLine(enemy, player, 1f);

    }
}
