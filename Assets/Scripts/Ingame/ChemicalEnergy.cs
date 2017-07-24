using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalEnergy : Energy
{
	private static readonly float SPEED_DOWN = 2f;


	private void Awake()
	{
		energyName = "화학 블럭";
	}

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

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed - SPEED_DOWN);
	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.ChangeMoveSpeed(player.moveSpeed + SPEED_DOWN);
	}
}