using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Rigidbody mRigidbody;
	private Vector3 mMovementVelocity;
	private Camera mMainCamera;
	private Vector3 mMoveInput;
	public float mMoveSpeed;
	public KeyCode fire = KeyCode.Mouse0;
	public GunControl mGun;

	// Use this for initialization
	void Start()
	{
		mRigidbody = GetComponent<Rigidbody>();
		mMainCamera = FindObjectOfType<Camera>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		mMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
		mMovementVelocity = mMoveInput * mMoveSpeed;
		mRigidbody.velocity = mMovementVelocity;
		Ray cameraRay = mMainCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;
		if (groundPlane.Raycast(cameraRay, out rayLength))
		{
			Vector3 pointToLookAt = cameraRay.GetPoint(rayLength);
			Debug.DrawLine(cameraRay.origin, pointToLookAt, Color.green);
			transform.LookAt(new Vector3(pointToLookAt.x,transform.position.y,pointToLookAt.z));
		}
	}
	private void Update()
	{
		if(Input.GetKey(fire))
		{
			mGun.isFiring = true;
		}
		else
		{
			mGun.isFiring = false;
		}
	}
}
