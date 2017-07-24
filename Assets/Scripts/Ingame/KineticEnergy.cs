using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Kinetic;
		SetMaterial(GameManager.Instance.energyMats[2]);
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.ChangeJumpCount(2);
	}

	protected override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.ChangeJumpCount(1);
	}
}