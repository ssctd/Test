using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LookMoveTo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        // RaycastHit hit;
        RaycastHit[] hits;
        GameObject hitObject;
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f, Color.red, 1, true);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;

            if (hitObject.transform.parent != null && hitObject.transform.parent.tag == "Floor")
            {
                transform.position = hit.point;
            }
        }
    }
}
