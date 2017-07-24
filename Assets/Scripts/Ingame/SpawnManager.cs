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

	private Transform tower;
	private GameManager gm;



	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		tower = GameManager.Instance.tower;
		gm = GameManager.Instance;
	}

	private void Update()
	{
		
	}

	public Block SpawnNewBlock()
	{
		if (blocks == null)
			return null;

		int rand = Random.Range(0, blocks.Length);
		GameObject obj = Instantiate<GameObject>(blocks[rand], tower);
		float h = gm.height + 20f;
		Vector3 pos = SPAWNPOS[gm.direction];
		pos.y = h;
		obj.transform.localPosition = pos;
		Vector3 euler = new Vector3(0f, -90f * gm.direction, 0f);
		obj.transform.rotation = Quaternion.Euler(euler);

		return obj.GetComponent<Block>();
	}
}
