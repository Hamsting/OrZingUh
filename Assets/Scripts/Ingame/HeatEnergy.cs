using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Heat;
	}

	protected override void Update()
	{
		base.Update();
	}

	protected override void OnCharacterEnter()
	{
		base.OnCharacterEnter();
	}
}