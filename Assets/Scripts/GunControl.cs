using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
	public bool isFiring { get; set; }
	public BulletControl bullet;
	public float bulletSpeed;
	public float timeBetweenShots;
	public Transform muzzleTransform;
	private float mShotCounter;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isFiring)
		{
			
			mShotCounter -= Time.deltaTime;
			if (mShotCounter <= 0.0f)
			{
				print("firing");
				mShotCounter = timeBetweenShots;
				BulletControl tempBullet = Instantiate(bullet, muzzleTransform.position,muzzleTransform.rotation);
				tempBullet.speed = bulletSpeed;
			}
		}
		else
		{
			mShotCounter = 0.0f;
		}
	}
}
