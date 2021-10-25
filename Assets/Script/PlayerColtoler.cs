using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerColtoler : MonoBehaviour
{
	Rigidbody rb;
	public float speed = 2f;
	public float RotationSpeed = 30f;
	float newRotY = 0;
	public float jumpPower = 3;
	public GameObject prefabBullet;
	public GameObject gunPosition;
	public float gunPower;
	public float guncd = 1f;
	float guncdcount = 0;
	public bool hasGun = false;
	public float horizontal;
	public float vertical;
	public int bulletCount = 0;
	public int coinCount = 0;
	public AudioSource audiocoin;
	public AudioSource audioshoot;
	public AudioSource audioreload;
	public Text uiTextCoin;
	public Text uiTextBullet;
	public PlaygroundScreenManager manager;
	private string coincoin;
	
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		
		if(manager == null)
		{
			//manager = FindObjectOfType(PlaygroundScreenManager);
		}
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//move
		
		/*if (Input.GetKey(KeyCode.UpArrow))
		{
			rb.AddForce(0, 0, speed, ForceMode.VelocityChange);
			newRotY = -180;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			rb.AddForce(0, 0, -speed,ForceMode.VelocityChange);
			newRotY = 0;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb.AddForce(-speed, 0, 0, ForceMode.VelocityChange);
			newRotY = 90;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			rb.AddForce(speed, 0, 0, ForceMode.VelocityChange);
			newRotY = -90;
		}*/
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		rb.AddForce(horizontal,0,vertical,ForceMode.VelocityChange ); 
		if(horizontal > 0)
		{
			newRotY = -90;
		}else if(horizontal < 0)
		{
			newRotY = 90;
		}
		if(vertical  > 0)
		{
			newRotY = 180;
		}else if(vertical  < 0)
		{
			newRotY = 0;
		}
		
		if (Input.GetButtonDown("Jump"))
		{
			rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
		}
		
		
		
		
		if(Input.GetButtonDown("Fire1") && (bulletCount>0) && (guncdcount >= guncd))
		{
			audioshoot.Play();
			guncdcount=0;
			bulletCount--;
			uiTextBullet.text=bulletCount.ToString();
			
			GameObject bullet=Instantiate(prefabBullet, gunPosition.transform.position, gunPosition.transform.rotation );
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * -gunPower,ForceMode.Impulse);
			//Rigidbody bRb = bullet.GetComponent<Rigidbody>();
			//bRb.AddForce(transform.forward * gunPower,ForceMode.Impulse);
			
			Destroy(bullet,3f);
		}
		guncdcount=guncdcount+ Time.fixedUnscaledDeltaTime;
		
		transform.rotation = Quaternion.Lerp(
			Quaternion.Euler(0, newRotY, 0),
			transform.rotation,
			Time.deltaTime * RotationSpeed);
	}
	/*	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
		if (collision.gameObject.name == "Ball")
		{
			//transform.localScale = new Vector3(2, 2, 2);
		}
		if (collision.gameObject.name == "Cube")
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		/*if (collision.gameObject.tag == "Collectable")
		{
		Destroy(collision.gameObject);
		}
	}*/

	private void OnTriggerEnter(Collider other)
	{
		
		print(other.gameObject.name);
		if(other.gameObject.tag == "coin")
		{
			
			coinCount++; 
			
			audiocoin.Play();
			Destroy(other.gameObject);

			coincoin=coinCount.ToString();
			uiTextCoin.text=coincoin;
	
	
		}
		
		if(other.gameObject.name == "Gun")
		{
			hasGun = true;
			bulletCount += 10;
			Destroy(other.gameObject); 
		}
		
		
	}
}