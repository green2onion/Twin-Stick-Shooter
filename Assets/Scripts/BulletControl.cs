using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
	public float speed;
	public float lifespan;
	private void OnCollisionEnter(Collision collision)
	{
		//Destroy(gameObject);
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	private void Update()
	{
		lifespan -= Time.deltaTime;
		if (lifespan <= 0)
		{
			Destroy(gameObject);
		}
	}
}
