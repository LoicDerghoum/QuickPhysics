using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateNormals : MonoBehaviour
{
    public float distance;
    public bool showPlaceholder;
    public GameObject placeholder;
    public Color placeHolderColor = new Color(1, 1, 1, 0.25f);


    private void OnValidate()
    {
        MeshRenderer _renderer = GetComponent<MeshRenderer>();
        MeshRenderer placeholderRenderer = placeholder.GetComponent<MeshRenderer>();

        _renderer.sharedMaterial.color = Color.red;
        placeholderRenderer.sharedMaterial.color = placeHolderColor; // Set rendering mode of material of placeholder to fade
        placeholder.layer = 2;

        placeholder.SetActive(showPlaceholder);
    }

    private void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        if(Physics.Raycast(headPos, lookDir, out RaycastHit hit, distance))
        {
            Vector3 hitPoint = hit.point;

            Vector3 normal = hit.normal.normalized;
            Vector3 right = Vector3.Cross(lookDir, normal).normalized;
            Vector3 forward = Vector3.Cross(normal, right);

            Gizmos.DrawLine(headPos, hitPoint);

            DrawRay(hitPoint, normal, Color.green);
            DrawRay(hitPoint, right, Color.red);
            DrawRay(hitPoint, forward, Color.cyan);

            placeholder.transform.position = new Vector3(hitPoint.x, hitPoint.y, hitPoint.z) + normal / 2;
            placeholder.transform.up = normal;
            placeholder.transform.right = right;
            placeholder.transform.forward = forward;

            if (!placeholder.activeSelf)
                placeholder.SetActive(true);
        }
        else
        {
            DrawRay(headPos, lookDir * distance);
            placeholder.SetActive(false);
        }
    }

    private void DrawRay(Vector3 p, Vector3 dir, Color? color = null)
    {
        if (color == null)
            color = Color.white;

        Gizmos.color = (Color)color;

        Gizmos.DrawLine(p, p + dir);
    }
}
