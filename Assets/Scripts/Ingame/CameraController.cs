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

	public bool camMoving = false;

    [SerializeField]
    float lerpTime;
	[SerializeField]
	AnimationCurve curve;

    Transform tr;

	/// <summary>
	///  0 : Normal, 1 : Player, 2 : Block.
	/// </summary>
	[SerializeField]
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
				tr.position = target.transform.forward * 12f + new Vector3(0f, GameManager.Instance.height + 4f, 0f);
			}
			tr.rotation = Quaternion.Euler(euler);
        }
    }

	public IEnumerator CameraMoveAnimate(Vector3 _dest)
	{
		camMoving = true;
        float timer = 0f;
		Camera cam = Camera.main;
		Vector3 originPos = cam.transform.position;
		Vector3 destPos = _dest;
		Quaternion originRot = cam.transform.rotation;
        Quaternion destRot = Quaternion.Euler(cam.transform.rotation.eulerAngles + new Vector3(0f, -90f, 0f));
		while (true)
		{
			float t = curve.Evaluate(timer / 0.5f);
			Vector3 pos = Vector3.Lerp(originPos, destPos, t);
			Quaternion rot = Quaternion.Lerp(originRot, destRot, t);
			cam.transform.position = pos;
			cam.transform.rotation = rot;
            timer += Time.deltaTime;
			if (timer >= 0.5f)
				break;
			yield return null;
		}
		camMoving = false;
    }
}
