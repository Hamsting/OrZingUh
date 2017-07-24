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

	// [HideInInspector]
	public PlayerController player;
	[HideInInspector]
	public Block currentBlock;
	// [HideInInspector]
	public float timer = 120f;
	// [HideInInspector]
	public float height = 0f;
	[HideInInspector]
	public int direction = 0;
	[HideInInspector]
	public int blockCount = 0;
	[HideInInspector]
	public bool blockPlaceMode = true;
	[HideInInspector]
	public bool gameover = false;

	public Transform tower;
	public Transform stemTop;
	public Transform minHeightCube;
	public Material[] energyMats;

	private SpawnManager sm;
	private UIInGameManager ui;
	private Coroutine coroutine;



	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		timer = 60f;
		sm = SpawnManager.Instance;
		ui = UIInGameManager.instance;
		ui.OnChangeMaxHeightViewer(100);
		ui.OnChangeHeightViewer(0, 100);
	}

	private void Update()
	{
		if (gameover)
			return;

		if (timer == 60f && blockPlaceMode)
			NextBlock();

		if (timer > 0f)
			timer -= Time.deltaTime;
		else if (timer <= 0f && blockPlaceMode)
		{
			StartPlayerMode();
		}
		else if (timer <= 0f && !blockPlaceMode)
		{
			ui.OnResult();
			UIResultManager.instance.SetResult(blockCount, (int)height, 100);
			gameover = true;
        }

		int timerMin = (int)timer / 60;
		int timerSec = (int)timer % 60;
		string timerStr = string.Format("{0:D2}", timerMin) + "  " + string.Format("{0:D2}", timerSec);
		ui.OnChangeTimer(timerStr);
		ui.OnChangeHeightViewer((int)height, 100);
		ui.OnChangeBlockInfo(sm.queue.Peek().gameObject.GetComponent<Energy>().energyName, sm.queue.Peek().icon);


		if (Input.GetKeyDown(KeyCode.Space) && blockPlaceMode)
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
		if (!blockPlaceMode)
		{
			CalculateHeight();
		}

		Vector3 minPos = minHeightCube.position;
		minPos.y = height - 0.5f;
		minHeightCube.position = minPos;
	}

	private void CalculateHeight()
	{
		height = 0f;
		int layerMask = 0;
		if (blockPlaceMode)
			layerMask = (1 << LayerMask.NameToLayer("Ground")) | (1 << LayerMask.NameToLayer("Block"));
		else
			layerMask = (1 << LayerMask.NameToLayer("Player"));

		RaycastHit hit;
		if (Physics.BoxCast(stemTop.position, new Vector3(3f, 0.025f, 3f), -stemTop.up, out hit, Quaternion.identity, 1000f, layerMask))
		{
			height = 1000f - hit.distance;
		}
	}

	public void NextBlock()
	{
		if (!blockPlaceMode)
			return;

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
		if (blockPlaceMode)
		{
			currentBlock = sm.SpawnNewBlock();
			direction = ++direction % 4;
			++blockCount;
			CameraController.instance.SetTarget(currentBlock.transform);
			CameraController.instance.SetBlockView();
		}
	}

	private void StartPlayerMode()
	{
		blockPlaceMode = false;
		minHeightCube.gameObject.SetActive(false);
		player.gameObject.SetActive(true);
		timer = 30f;
	}
}
