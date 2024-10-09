using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    float count = 0;

    // Update is called once per frame
    void Update()
    {
        if (count < 5f)
        {
            count += Time.deltaTime;
        }
        else
        {
            float x = Random.Range(-5f, 5f);

            float z = Random.Range(0f, 15f);

            transform.position = new Vector3(x, -.75f, z);

            count = 0;
        }
    }
}
