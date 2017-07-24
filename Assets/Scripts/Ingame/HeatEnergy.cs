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
		SetMaterial(GameManager.Instance.energyMats[4]);
	}

	protected override void Update()
	{
		base.Update();
		if (isEnabled)
		{
			if (timer > 0f)
				timer -= Time.deltaTime;
			else
				OnDisableEnergy();
		}
	}

	protected override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
	}

	protected override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
		Destroy(this.gameObject);
	}
}