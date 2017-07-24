using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
	public Type energyType;

	protected PlayerController player;



	protected virtual void Start()
	{
		energyType = Type.Electric;
		player = GameManager.Instance.player;
	}

	protected virtual void Update()
	{
		
	}

	protected virtual void OnEnable()
	{

	}

	protected virtual void OnDisable()
	{

	}

	protected void OnCollisionEnter(Collision _col)
	{
		if (_col.gameObject.tag == "Character")
			OnEnable();
	}

	public enum Type
	{
		Electric,
		Light,
		Kinetic,
		Location,
		Heat,
		Chemical,
	}
}
