using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject DemonGO;
    public GameObject AngelGO;

    [HideInInspector]
    public bool isActive;
    Vector3 temp;

    // Use this for initialization
    void Start () {
        isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive == true)
            FixedCameraFollowSmooth(this.gameObject.GetComponent<Camera>(), DemonGO.transform, AngelGO.transform);
    }

    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 0.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;
        temp = new Vector3(0.0f, 0.0f, 0f);
        midpoint -= temp;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude * 1.0f;
        //Debug.Log(distance);
        if (distance <= 4.0f)
        {
            distance = 4.0f;
        }

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
        temp = new Vector3(cam.transform.position.x, 0.0f, -1.0f);
        cam.transform.position = temp;

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
