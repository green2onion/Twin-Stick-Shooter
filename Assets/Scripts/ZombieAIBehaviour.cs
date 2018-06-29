using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAIBehaviour : MonoBehaviour
{
	private Rigidbody mRigidbody;
	public float moveSpeed;
	public GameObject myPlayer;
	private Vector3 myPlayerPosition;
	public float health;

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
		transform.rotation = new Quaternion(90, transform.rotation.y, 0, 0);
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		mRigidbody.velocity = Vector3.zero;
		Invoke("Despawn", 1.5f);
	}
	void Despawn()
	{
		Destroy(gameObject);
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			// TODO: Damage player
			other.gameObject.GetComponent<PlayerController>().health -= 2f;
			print("cool");
			//Die();
		}
		if (other.gameObject.tag == "Bullet")
		{
			health -= 0.25f;
			if (health <= 0)
			{
				Die();
			}
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
