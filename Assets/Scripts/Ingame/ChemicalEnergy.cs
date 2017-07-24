using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalEnergy : Energy
{
	private static readonly float SPEED_DOWN = 1f;



	protected override void Start()
	{
		base.Start();
		energyType = Type.Chemical;
		SetMaterial(GameManager.Instance.energyMats[5]);
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.OnChangeMoveSpeed(player.moveSpeed - SPEED_DOWN);
	}

	protected override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.OnChangeMoveSpeed(player.moveSpeed + SPEED_DOWN);
	}
}