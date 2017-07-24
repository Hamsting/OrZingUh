using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnergy : Energy
{
	private static readonly float SPEED_UP = 1f;



	protected override void Start()
	{
		base.Start();
		energyType = Type.Light;
		SetMaterial(GameManager.Instance.energyMats[1]);
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed + SPEED_UP);
	}

	protected override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed - SPEED_UP);
	}
}