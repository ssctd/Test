using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlers : MonoBehaviour
{
    public GameObject Door;
    DoorControl doorControl;

    public GameObject DoorSensor;

    // Start is called before the first frame update
    void Start()
    {
        doorControl = Door.GetComponent<DoorControl>();

    }


    public void DoorButtonHandler()
    {
        doorControl.Open = !doorControl.Open;

        if (doorControl.Open)
        {
            DoorSensor.SetActive(true);
        }
    }
}
