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

	public PlayerController player;
	public float timer = 120f;



	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		timer = 120f;
	}

	private void Update()
	{
		if (timer > 0f)
			timer -= Time.deltaTime;

		int timerMin = (int)timer / 60;
		float timerSec = (int)timer % 60;
		string timerStr = string.Format("{0:D2}", timerMin) + " : " + string.Format("{0:D2}", timerSec);
		// GameUIManager.Instance.timerText.text = timerStr;
	}
}
