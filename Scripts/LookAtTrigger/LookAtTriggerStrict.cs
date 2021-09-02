using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LookAtTriggerStrict : MonoBehaviour
{
    public GameObject targetGameObject;

    public Color trueColor = Color.red;
    public Color falseColor = Color.green;

    [Range(0, 15)]
    public float distance = 5f;

    private void OnDrawGizmos()
    {
        Vector3 enemy = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;

        float opp = - Mathf.Sin(rotation.z * Mathf.Deg2Rad) * distance; // x
        float adj = Mathf.Cos(rotation.z * Mathf.Deg2Rad) * distance; // y

        Vector3 vision = new Vector3(opp, adj, 0);

        Vector3 target = targetGameObject.transform.position;

        float dot = Vector3.Dot(vision.normalized, target.normalized);

        #if UNITY_EDITOR

        if (dot == 1) // very precise
            Handles.color = trueColor;
        else
            Handles.color = falseColor;

        Handles.DrawLine(enemy, vision);

        #endif

        //print(dot);
    }
}
