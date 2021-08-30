using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedChildCoords : MonoBehaviour
{
    public GameObject p2GO;
    public Vector3 target = new Vector3(1, 2, 3);

    private Vector3 origin = new Vector3(0, 0, 0);

    public Color color1 = Color.blue;
    public Color color2 = Color.red;
    public Color color3 = Color.magenta;

    private void OnDrawGizmos()
    {
        Vector3 p1 = transform.position;
        Vector3 p2World = p2GO.transform.position;
        Vector3 p2Local = p2World - p1;

        p2GO.transform.position = target;

        Gizmos.color = color1;
        Gizmos.DrawLine(origin, p1);
        Gizmos.color = color2;
        Gizmos.DrawLine(p1, p2World);
        Gizmos.color = color3;
        Gizmos.DrawLine(origin, p2World);
    }
}
