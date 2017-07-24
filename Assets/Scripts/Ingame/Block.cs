using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public bool isGround = false;
	public GameObject block;
    public Sprite icon;

	private Rigidbody rb;
	private MeshRenderer[] cubes;



	private void Awake()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	private void Start()
	{
		cubes = this.GetComponentsInChildren<MeshRenderer>();
	}

	private void Update()
	{
		if (!isGround)
			Fall();
	}

	private void Fall()
	{
		this.rb.velocity = -this.transform.up * 4f;
	}

	private void OnCollisionEnter(Collision _col)
	{
		if (isGround)
			return;

		if (_col.gameObject.layer == LayerMask.NameToLayer("Ground") ||
			_col.gameObject.layer == LayerMask.NameToLayer("Block"))
		{
			StopBlock();
			GameManager.Instance.NextBlock();
		}
	}

	public void StopBlock()
	{
		isGround = true;
		rb.isKinematic = true;
		this.gameObject.layer = LayerMask.NameToLayer("Block");
	}

	public void RotateCubes(float _rot)
	{
		for (int i = 0; i < cubes.Length; ++i)
			cubes[i].transform.Rotate(_rot, 0f, 0f);
	}
}
