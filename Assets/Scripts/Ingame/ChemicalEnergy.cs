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
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		player.OnChangeMoveSpeed(player.moveSpeed - SPEED_DOWN);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		player.OnChangeMoveSpeed(player.moveSpeed + SPEED_DOWN);
	}
}