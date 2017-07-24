using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private static readonly Vector3[] SPAWNPOS =
	{
		new Vector3(0, 0, 1),
		new Vector3(-1, 0, 0),
		new Vector3(0, 0, -1),
		new Vector3(1, 0, 0)
	};
	private static SpawnManager _instance;
	public static SpawnManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("SpawnManager Instance is null.");
			return _instance;
		}
	}

	public GameObject[] blocks;

	[HideInInspector]
	public Queue<Block> queue;

	private Transform tower;
	private GameManager gm;



	private void Awake()
	{
		_instance = this;
		queue = new Queue<Block>();
	}

	private void Start()
	{
		tower = GameManager.Instance.tower;
		gm = GameManager.Instance;
		Update();
	}

	private void Update()
	{
		if (queue.Count < 5)
		{
			for (int i = queue.Count; i <= 5; ++i)
			{
				int rand = Random.Range(0, blocks.Length);
				GameObject obj = Instantiate<GameObject>(blocks[rand], tower);
				Block b = obj.GetComponent<Block>();

				switch (Random.Range(0, 6))
				{
					case 0:
						obj.AddComponent<ElectricEnergy>();
						break;
					case 1:
						obj.AddComponent<LightEnergy>();
						break;
					case 2:
						obj.AddComponent<KineticEnergy>();
						break;
					case 3:
						obj.AddComponent<LocationEnergy>();
						break;
					case 4:
						obj.AddComponent<HeatEnergy>();
						break;
					case 5:
						obj.AddComponent<ChemicalEnergy>();
						break;
				}
				queue.Enqueue(b);
				obj.SetActive(false);
			}
		}
	}

	public Block SpawnNewBlock()
	{
		if (blocks == null)
			return null;
		
		Block b = queue.Dequeue();
		GameObject obj = b.gameObject;
		float h = gm.height + 12f;
		Vector3 pos = SPAWNPOS[gm.direction];
		pos.y = h;
		obj.transform.localPosition = pos;
		Vector3 euler = new Vector3(0f, -90f * gm.direction, 0f);
		obj.transform.rotation = Quaternion.Euler(euler);
		obj.layer = LayerMask.NameToLayer("MovingBlock");
		obj.SetActive(true);

		return b;
	}
}
