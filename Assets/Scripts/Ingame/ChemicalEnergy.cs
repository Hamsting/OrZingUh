using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalEnergy : Energy
{



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
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}
}