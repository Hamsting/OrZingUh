using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("GameManager Instance is null.");
			return _instance;
		}
	}

	[HideInInspector]
	public PlayerController player;
	[HideInInspector]
	public Block currentBlock;
	[HideInInspector]
	public float timer = 120f;
	// [HideInInspector]
	public float height = 0f;
	// [HideInInspector]
	public int direction = 0;

	public Transform tower;
	public Transform stemTop;

	private SpawnManager sm;



	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		timer = 120f;
		sm = SpawnManager.Instance;
	}

	private void Update()
	{
		if (timer > 0f)
			timer -= Time.deltaTime;

		int timerMin = (int)timer / 60;
		int timerSec = (int)timer % 60;
		string timerStr = string.Format("{0:D2}", timerMin) + " : " + string.Format("{0:D2}", timerSec);
		// GameUIManager.Instance.timerText.text = timerStr;
		CalculateHeight();

		if (Input.GetKeyDown(KeyCode.Q))
		{
			SpawnBlock();
		}
	}

	private void CalculateHeight()
	{
		height = 0f;
		int layerMask = -1 - (1 << LayerMask.NameToLayer("Ground")) - (1 << LayerMask.NameToLayer("Block"));
		RaycastHit hit;
		if (Physics.BoxCast(stemTop.position, new Vector3(3f, 1f, 3f), -stemTop.up, out hit, Quaternion.identity, 1000f, layerMask))
		{
			height = 1000f - hit.distance;
		}
	}

	private void SpawnBlock()
	{
		currentBlock = sm.SpawnNewBlock();
		direction = ++direction % 4;
		CameraController.instance.SetTarget(currentBlock.transform);
		CameraController.instance.SetBlockView();
	}
}
