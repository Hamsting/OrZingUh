using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private static readonly Vector3 PLAYER_ROTATION = new Vector3(0f, -90f, 0f);
	private static readonly Vector3 BLOCK_ROTATION = new Vector3(0f, 180f, 0f);

	public static CameraController instance;

    public Transform target;
    public Vector3 margin;

    [SerializeField]
    float lerpTime;

    Transform tr;

	/// <summary>
	///  0 : Normal, 1 : Player, 2 : Block.
	/// </summary>
	private int viewMode = 0;



    private void Awake()
    {
        tr = GetComponent<Transform>();
        instance = this;
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }
	
	public void SetPlayerView()
	{
		viewMode = 1;
    }

	public void SetBlockView()
	{
		viewMode = 2;
	}

    private void FixedUpdate()
    {
		if (target != null)
		{
			Vector3 euler = target.transform.rotation.eulerAngles;
			if (viewMode == 1)
			{
				euler += PLAYER_ROTATION;
				tr.position = Vector3.Slerp(tr.position, target.position + 6f * target.transform.right, Time.deltaTime * lerpTime);
			}
			else if (viewMode == 2)
			{ 
				euler += BLOCK_ROTATION;
				tr.position = Vector3.Slerp(tr.position, target.position + 6f * target.transform.forward, Time.deltaTime * lerpTime);
			}
			tr.rotation = Quaternion.Euler(euler);
        }
    }



}
