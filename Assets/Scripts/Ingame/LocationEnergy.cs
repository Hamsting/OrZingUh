using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnergy : Energy
{



	private void Awake()
	{
		energyName = "위치 블럭";
	}

	protected override void Start()
	{
		base.Start();
		energyType = Type.Location;
		energyName = "위치 블럭";
		SetMaterial(GameManager.Instance.energyMats[3]);
	}

	protected override void Update()
	{
		base.Update();
	}

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
	}
}