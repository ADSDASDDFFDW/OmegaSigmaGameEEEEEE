using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float targetSkyDistance;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetSkyDistance);
        }

        transform.LookAt(targetPoint.position);
    }
}
