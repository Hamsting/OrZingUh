﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Transform), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Energy energy;
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    float jumpPower = 5f;
    [SerializeField]
    int jumpCount = 0, maxJumpCount = 1;
	[SerializeField]
	AnimationCurve rotationCurve;

    [SerializeField]
    float groundDistance = 1f;
    [SerializeField]
    bool groundCheck = true, isGround = false, isMove = false;

    [SerializeField]
    private float h, v;



    // 컴포넌트 캐싱
    Rigidbody ri;
    Transform tr;
    Animator ani;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody>();
        ani = tr.GetChild(0).GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.player = this;
        CameraController.instance.SetTarget(tr);
        CameraController.instance.SetPlayerView();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Jump();

    }

    private void FixedUpdate()
    {
        if (groundCheck)
            GroundCheck();

        if (isMove)
            Move();
        else
            ani.SetFloat("Run", Mathf.Abs(h));
    }


    void Move()
    {
        Vector3 pos = tr.forward * moveSpeed * h;
        ri.velocity = new Vector3(pos.x, ri.velocity.y, pos.z);
        ani.SetFloat("Run", Mathf.Abs(h));
    }

    void Jump()
    {
        if (jumpCount >= maxJumpCount)
            return;

        ++jumpCount;
        AudioManager.instance.PlayJump();
        ri.velocity = new Vector3(ri.velocity.x, jumpPower, ri.velocity.z);
        ani.SetBool("Jump", true);

        if (groundCheckDelay != null)
        {
            StopCoroutine(groundCheckDelay);
        }
        groundCheckDelay = StartCoroutine(GroundCheckDelay());
        isGround = false;
    }

    void GroundCheck()
    {
        int layerMask = -1 - (1 << LayerMask.NameToLayer("Foot"));
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance, layerMask))
        {
            isGround = true;
            jumpCount = 0;
            ani.SetBool("Jump", false);
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Block"))
            {
                Energy e = hit.collider.gameObject.GetComponentInParent<Energy>();
                if (energy != null)
                    energy.OnDisableEnergy();
                e.OnEnableEnergy();
                energy = e;
            }
        }
    }

    Coroutine groundCheckDelay = null;

    IEnumerator GroundCheckDelay()
    {
        groundCheck = false;
        yield return new WaitForSeconds(0.1f);
        groundCheck = true;
        groundCheckDelay = null;
    }

    /// <summary>
    /// 캐릭터의 이동속도를 변경합니다.
    /// </summary>
    /// <param name="changeSpeed">변화할 속도 값</param>
    public void ChangeMoveSpeed(float _changeSpeed)
    {
        moveSpeed = _changeSpeed;
    }

    /// <summary>
    /// 캐릭터의 최대 점프 횟수를 증가합니다.
    /// </summary>
    /// <param name="max">최대 값</param>
    public void ChangeJumpCount(int _max)
    {
        maxJumpCount = _max;
    }

    /// <summary>
    /// 캐릭터의 조종을 허가합니다.
    /// </summary>
    public void ChangeMove()
    {
        isMove = true;
        CameraController.instance.SetPlayerView();
    }

	private void OnCollisionEnter(Collision _col)
	{
		if (GameManager.Instance.blockPlaceMode)
			return;

		int dir = -1;
		string tag = _col.gameObject.tag;
		if (tag == "Wall_Forward")
			dir = 0;
		else if (tag == "Wall_Right")
			dir = 1;
		else if (tag == "Wall_Backward")
			dir = 2;
		else if (tag == "Wall_Left")
			dir = 3;

		if (dir != -1)
		{
			GameManager.Instance.direction = dir;
			if (rotationCoroutine != null)
				StopCoroutine(rotationCoroutine);
			rotationCoroutine = StartCoroutine(RotationAnimate(-90f * ((dir + 1) % 4)));

			// this.transform.rotation = Quaternion.Euler(0f, -90f * (dir + 1), 0f);
		}
	}

	Coroutine rotationCoroutine = null;

	private IEnumerator RotationAnimate(float _rot)
	{
		float timer = 0f;
		Vector3 euler = this.transform.rotation.eulerAngles;
		float originY = euler.y;
		while (true)
		{
			float t = rotationCurve.Evaluate(timer / 0.5f);
			float y = Mathf.LerpAngle(originY, _rot, t);
			euler.y = y;
			this.transform.rotation = Quaternion.Euler(euler);
			if (timer >= 0.5f)
				break;
			timer += Time.deltaTime;
			yield return null;
		}
	}
}
