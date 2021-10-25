using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColtoller : MonoBehaviour
{   
    public Light Light;
    public string lightName = "Living Room";

    private void Awake()
    {
        print ("Hello Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Hello "+ lightName);
    }
    public int countlight=0;
    private void OnMouseDown ()
    {   
        
        print("MouseDown"+countlight);
	    Light.enabled = !Light.enabled;
	    //Light.intensity = 5;
        /*if (countlight%2==0)
        {
            Light.color = Color.blue;
        }
        else
        {
            Light.color = Color.red;
        }*/
        countlight++;
        //box.SetActive(!box.activeSelf);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
