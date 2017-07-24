using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Kinetic;
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