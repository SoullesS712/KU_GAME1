using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
	NavMeshAgent agent;
	public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
	    agent = GetComponent<NavMeshAgent>();
	    agent.SetDestination(target.transform.position);
	    
	    InvokeRepeating("AiDestiantion",0.2f,0.2f);
    }
	void AiDestination()
	{
		agent.SetDestination(target.transform.position);
	}
    // Update is called once per frame
    void Update()
	{
		
	    
        
    }
}
