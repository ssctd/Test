using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class ButtonExecute : MonoBehaviour
{
    //public Button startButton, stopButton;
    Button hitButton, currentButton;
    private bool on = false;
    public float timeToSelect = 2;
    private float timer;
    public TMP_Text text;
    public Image circeOutline;


    // Use this for initialization
    void Start()
    {
        timer = timeToSelect;

    }
    // Update is called once per frame
    void Update()
    {
        text.text = timer.ToString();
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100, Color.red);
        RaycastHit hit;
        //GameObject hitObject;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Button")
            {
                if (timer < 0)
                {
                    hitButton = hit.transform.parent.gameObject.GetComponent<Button>();
                    print("name= " + hitButton.name);
                    timer = timeToSelect;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            else
            {
                hitButton = null;
                timer = timeToSelect;
            }
            if (currentButton != hitButton)
            {
                //unhighlight
                if (currentButton != null)
                {
                    currentButton.OnPointerExit(new PointerEventData(EventSystem.current));
                }
                //make changes
                currentButton = hitButton;
                if (currentButton != null)
                {
                    currentButton.onClick.Invoke();
                    currentButton.OnPointerEnter(new PointerEventData(EventSystem.current));
                }
            }
        }
    }
}
