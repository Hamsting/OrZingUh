using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Location;
		SetMaterial(GameManager.Instance.energyMats[3]);
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
	}

	protected override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
	}
}