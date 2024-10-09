using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Effects;

public class KillTarget : MonoBehaviour
{

    public GameObject target;
    public float timeToSelect = 3.0f; 
    public ParticleSystem hitEffect; 
    public GameObject killEffect;
    public Text scoreText;

    public int score;
    private float countDown;

    public GameObject textElement1;
    public GameObject textElement2;

    // Start is called before the first frame update
    void Start()
    {
        countDown = timeToSelect;
        var emission = hitEffect.emission;
        emission.enabled = false;

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        var emission = hitEffect.emission;
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.transform.rotation * Vector3.forward); RaycastHit hit;


        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject == target))
        {
            textElement1.SetActive(false);
            textElement2.SetActive(true);
            
            if (countDown < 0f)
            {
                //ToDo: Kill target. Instantiate kill Effect. Reset the countdown.

                float x = UnityEngine.Random.Range(-5f, 5f);

                float z = UnityEngine.Random.Range(0f, 15f);

                target.transform.position = new Vector3(x, -.75f, z);

                print("Destroyed");
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                countDown = timeToSelect;
                
                score += 1;

                scoreText.text = "Score: " + score;


            }   
            else
            {
                //ToDo: Decrement countdown with Time.deltaTime amount. Enable the hitEffect, and place it at hit.ponit.
                Instantiate(hitEffect, target.transform.position, target.transform.rotation);
                hitEffect.transform.position = hit.point;

                print("Time: " + countDown);
                countDown -= Time.deltaTime;
                emission.enabled = true;
                


            }
        }
        else
        {//ToDo: Reset countdown. Disable hitEffect.}
            emission.enabled = false;
            countDown = timeToSelect;


            textElement1.SetActive(true);
            textElement2.SetActive(false);
        }

    }
}
