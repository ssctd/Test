using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CursorPositioner : MonoBehaviour
{
    public GameObject target;
    public GameObject reticle;
    float defaultPosZ;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosZ = transform.localPosition.z;
        print(defaultPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            reticle.transform.localPosition = new Vector3(0, 0, hit.distance - 0.1f);
            reticle.transform.localScale = Vector3.one * hit.distance * 0.001f;
        }
        else
        {
            reticle.transform.localPosition = new Vector3(0, 0, 1);
            reticle.transform.localScale = new Vector3(0.00135f, 0.00135f, 0.00135f);
        }



    }
}