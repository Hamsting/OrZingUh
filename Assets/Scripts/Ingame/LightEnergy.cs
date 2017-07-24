using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnergy : Energy
{
	private static readonly float SPEED_UP = 1f;



	private void Awake()
	{
		energyName = "빛 블럭";
	}

	protected override void Start()
	{
		base.Start();
		energyType = Type.Light;
		energyName = "빛 블럭";
		SetMaterial(GameManager.Instance.energyMats[1]);
	}

	protected override void Update()
	{
		base.Update();
	}

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed + SPEED_UP);
	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed - SPEED_UP);
	}
}