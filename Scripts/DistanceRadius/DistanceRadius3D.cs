using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceRadius3D : MonoBehaviour
{
    public GameObject target;

    public bool wired = false;

    public Color trueColor = new Color(255, 0, 0, 0.125f);
    public Color falseColor = new Color(98, 168, 200, 0.125f);

    [Range(0, 10)]
    public float radius;

    private void OnDrawGizmos()
    {
        Vector3 enemy = transform.position;
        Vector3 player = target.transform.position;

        Vector3 ab = new Vector3(player.x - enemy.x, player.y - enemy.y, player.z - enemy.z);

        float distSq = ab.x * ab.x + ab.y * ab.y + ab.z * ab.z;

        //if (Vector3.Distance(enemy, player) <= radius)

        if(distSq <= radius * radius)
            Gizmos.color = trueColor;
        else
            Gizmos.color = falseColor;

        if(wired)
            Gizmos.DrawWireSphere(transform.position, radius); // Handles = 2D ; Gizmos = 2D & 3D;
        else
            Gizmos.DrawSphere(transform.position, radius);

        Gizmos.DrawLine(enemy, player);
    }
}
