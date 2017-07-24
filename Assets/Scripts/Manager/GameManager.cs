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
	[HideInInspector]
	public int direction = 0;
	[HideInInspector]
	public int blockCount = 0;
	[HideInInspector]
	public bool blockPlaceMode = true;

	public Transform tower;
	public Transform stemTop;
	public Material[] energyMats;

	private SpawnManager sm;
	private Coroutine coroutine;



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
		if (timer == 120f)
			NextBlock();

		if (timer > 0f)
			timer -= Time.deltaTime;

		int timerMin = (int)timer / 60;
		int timerSec = (int)timer % 60;
		string timerStr = string.Format("{0:D2}", timerMin) + " : " + string.Format("{0:D2}", timerSec);
		// GameUIManager.Instance.timerText.text = timerStr;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			currentBlock.StopBlock();
			NextBlock();
		}

		if (blockPlaceMode && currentBlock != null)
		{
			float h = Input.GetAxis("Horizontal");

			if (h != 0)
			{
				Vector3 pos = currentBlock.transform.position;
				pos += currentBlock.transform.right * -h * Time.deltaTime;
				currentBlock.transform.position = pos;
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				currentBlock.block.transform.Rotate(0f, 0f, 90f);
				currentBlock.RotateCubes(-90f);
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				currentBlock.block.transform.Rotate(0f, 0f, -90f);
				currentBlock.RotateCubes(90f);
			}
		
		}

	}

	private void CalculateHeight()
	{
		height = 0f;
		int layerMask = (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("Block"));
		RaycastHit hit;
		if (Physics.BoxCast(stemTop.position, new Vector3(3f, 1f, 3f), -stemTop.up, out hit, Quaternion.identity, 1000f, layerMask))
		{
			height = 1000f - hit.distance;
		}
	}

	public void NextBlock()
	{
		if (coroutine != null)
			StopCoroutine(coroutine);
		coroutine = StartCoroutine(NextBlockCoroutine());
	}

	private IEnumerator NextBlockCoroutine()
	{
		CalculateHeight();
		if (currentBlock != null)
		{
			Vector3 camDestPos = -currentBlock.transform.right * 12f + new Vector3(0f, GameManager.Instance.height + 4f, 0f);
			currentBlock = null;
			yield return StartCoroutine(CameraController.instance.CameraMoveAnimate(camDestPos));
		}

		currentBlock = sm.SpawnNewBlock();
		direction = ++direction % 4;
		++blockCount;
		CameraController.instance.SetTarget(currentBlock.transform);
		CameraController.instance.SetBlockView();
	}
}
