using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIBehaviour : MonoBehaviour
{
	private Rigidbody mRigidbody;
	public float moveSpeed;
	public GameObject myPlayer;
	private Vector3 myPlayerPosition;

	private void ChasePlayer()
	{
		myPlayerPosition = myPlayer.transform.position;
		if (Vector3.Distance(transform.position, myPlayerPosition) < 10 && Vector3.Distance(transform.position, myPlayerPosition) > 1) 
		{
			transform.LookAt(myPlayerPosition);
			mRigidbody.velocity = transform.forward * moveSpeed;
		}
		else if (Vector3.Distance(transform.position, myPlayerPosition) < 1)
		{
			mRigidbody.velocity = Vector3.zero;

		}
	}
	private void Die()
	{
		transform.rotation = new Quaternion(90, transform.rotation.y, 0,0);
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		Invoke("Despawn", 1.5f);
	}
	void Despawn()
	{
		Destroy(gameObject);
	}
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			// TODO: Damage player
			print("cool");
			Die();
		}
	}

	// Use this for initialization
	private void Start()
	{
		mRigidbody = GetComponent<Rigidbody>();
		//myPlayer = GameObject.FindGameObjectWithTag("Player");
		
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		ChasePlayer();
	}
	private void Update()
	{

	}
}
