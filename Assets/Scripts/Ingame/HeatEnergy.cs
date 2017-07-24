using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatEnergy : Energy
{
	private float timer = 2f;



	private void Awake()
	{
		energyName = "열 블럭";
	}

	protected override void Start()
	{
		base.Start();
		energyType = Type.Heat;
		energyName = "열 블럭";
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
			{
				Destroy(this.gameObject);
			}
		}
	}

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
	}
}