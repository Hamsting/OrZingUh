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

	// public Character cha;



	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		
	}
}
