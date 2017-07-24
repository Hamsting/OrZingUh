using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatEnergy : Energy
{
	private float timer = 2f;



	protected override void Start()
	{
		base.Start();
		energyType = Type.Heat;
	}

	protected override void Update()
	{
		base.Update();
		if (isEnabled)
		{
			if (timer > 0f)
				timer -= Time.deltaTime;
			else
				OnDisable();
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Destroy(this.gameObject);
	}
}