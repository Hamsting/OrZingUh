using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		SetMaterial(GameManager.Instance.energyMats[0]);
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