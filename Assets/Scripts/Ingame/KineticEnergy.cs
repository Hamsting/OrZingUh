using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticEnergy : Energy
{



	private void Awake()
	{
		energyName = "운동 블럭";
	}

	protected override void Start()
	{
		base.Start();
		energyType = Type.Kinetic;
		energyName = "운동 블럭";
		SetMaterial(GameManager.Instance.energyMats[2]);
	}

	protected override void Update()
	{
		base.Update();
	}

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		player.ChangeJumpCount(2);
	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		player.ChangeJumpCount(1);
	}
}