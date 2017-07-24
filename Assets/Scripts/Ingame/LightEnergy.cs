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
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
}