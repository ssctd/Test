using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public bool open = false;
    private Vector3 initalPosition;

    public bool Open { get => open; set => open = value; }

    private void Start()
    {
        initalPosition = transform.position;
    }

    void Update()
    {
        if (Open)
        {
            transform.position = Vector3.Lerp(transform.position, initalPosition + new Vector3(0f, 3f, 0f), 5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initalPosition, 5f * Time.deltaTime);
        }
    }
}

