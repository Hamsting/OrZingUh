using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public bool isGround = false;

	private Rigidbody rb;



	private void Awake()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		if (!isGround)
			Fall();
	}

	private void Fall()
	{
		this.rb.velocity = -this.transform.up * 7.5f;
	}

	private void OnCollisionEnter(Collision _col)
	{
		if (_col.gameObject.layer == LayerMask.NameToLayer("Ground") ||
			_col.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			isGround = true;
			rb.isKinematic = true;
		}
	}
}
