using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    public float lookSpeed;

    void Update()
    {
        Plane playerPLane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        
        if(playerPLane.Raycast(ray, out hitDist))
        {
            Vector3 lookTarget = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(lookTarget - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
        }
    }
}
