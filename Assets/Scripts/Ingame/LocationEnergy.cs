using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Location;
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