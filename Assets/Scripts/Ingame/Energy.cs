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

	protected virtual void OnEnableEnergy()
	{
		isEnabled = true;
    }

	protected virtual void OnDisableEnergy()
	{
		isEnabled = false;
    }

	protected void OnCollisionEnter(Collision _col)
	{
		print(_col.gameObject);
		print(_col.gameObject.tag);
		if (_col.gameObject.tag == "Player")
			OnEnableEnergy();
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

	protected void SetMaterial(Material _mat)
	{
		MeshRenderer[] rens = this.GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < rens.Length; ++i)
			rens[i].material = _mat;
	}
}

/*

위치 - 텔레포트 (현재 위치의 위에서 가장 가까운것)
	*/
