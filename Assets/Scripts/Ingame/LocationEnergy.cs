using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEnergy : Energy
{
	public bool teleportOn = true;



	private void Awake()
	{
		energyName = "위치 블럭";
	}

	protected override void Start()
	{
		base.Start();
		energyType = Type.Location;
		energyName = "위치 블럭";
		SetMaterial(GameManager.Instance.energyMats[3]);
	}

	protected override void Update()
	{
		base.Update();
	}

	public override void OnEnableEnergy()
	{
		base.OnEnableEnergy();
		if (teleportOn)
		{
			LocationEnergy min = null;
			LocationEnergy[] les = GameObject.FindObjectsOfType<LocationEnergy>();
			for (int i = 0; i < les.Length; ++i)
			{
				LocationEnergy le = les[i];
				if (le.transform.position.y <= player.transform.position.y)
					continue;

				if (min == null)
					min = le;
				else if (min.transform.position.y > le.transform.position.y)
					min = le;
			}

			if (min != null)
			{
				player.transform.position = min.transform.position + new Vector3(0f, 1.5f, 0f);
				this.teleportOn = false;
				min.teleportOn = false;
			}
		}

	}

	public override void OnDisableEnergy()
	{
		base.OnDisableEnergy();
	}
}