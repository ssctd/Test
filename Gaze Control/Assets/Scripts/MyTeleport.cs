using System.Collections.Generic;
using UnityEngine;

public class MyTeleport : MonoBehaviour
{
    public Transform xrRig;
    public Transform teleportPosition;
    // Start is called before the first frame update
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100, Color.red);
        RaycastHit hit;
        //GameObject hitObject;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.name == "DoorSensor")
            {
                //replace the position values to what you would like to teleport to. 
                xrRig.position = teleportPosition.position;
            }
        }

    }
}
