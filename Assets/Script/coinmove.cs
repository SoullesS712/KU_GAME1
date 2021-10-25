using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmove : MonoBehaviour
{
	public float speed=2f;
	float newy ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	
	    newy = transform.position.y + speed * Time.deltaTime;
	    
    }
}
