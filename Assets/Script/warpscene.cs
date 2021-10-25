using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class warpscene : MonoBehaviour
{
	
		public string sceneName;
		public AudioSource warpSound;
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag == "Player")
			{
				Invoke("LoadNextScene", 1.0f);
				SceneManager.LoadScene(sceneName);
			}
		}

	//	void LoadNextScene()
	//{
		
	//		SceneManager.LoadScene(sceneName);
	//	if (sceneName == "End"){ Cursor.lockState = CursorLockMode.None; }
	//}
	}

