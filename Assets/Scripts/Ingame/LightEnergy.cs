using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnergy : Energy
{



	protected override void Start()
	{
		base.Start();
		energyType = Type.Light;
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