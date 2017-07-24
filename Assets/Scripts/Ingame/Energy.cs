using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
	public Type energyType;



	protected virtual void Start()
	{
		energyType = Type.Electric;
	}

	protected virtual void Update()
	{
		
	}

	protected virtual void OnCharacterEnter()
	{

	}

	protected void OnCollisionEnter(Collision _col)
	{
		if (_col.gameObject.tag == "Character")
			OnCharacterEnter();
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
