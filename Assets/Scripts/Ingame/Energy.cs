using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
	public Type energyType;

	protected PlayerController player;
	protected bool isEnabled = false;



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
		isEnabled = true;
    }

	protected virtual void OnDisable()
	{
		isEnabled = false;
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

/*

위치 - 텔레포트 (현재 위치의 위에서 가장 가까운것)
열 - 블럭이 부서쥠

	*/
