using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Transform), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	Energy.Type energyType;
    [SerializeField]
    float basicMoveSpeed = 5f, moveSpeed = 5f;
    [SerializeField]
    float basicJumpPower = 2f, jumpPower = 2f;
    [SerializeField]
    int basicJumpCount = 1, jumpCount = 0,maxJumpCount = 1;

    [SerializeField]
    float groundDistance = 1f;
    [SerializeField]
    bool groundCheck = false, isGround = false, isMove = true;

    [SerializeField]
    private float h, v;


    // 컴포넌트 캐싱
    Rigidbody ri;
    Transform tr;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody>();
    }

	private void Start()
	{
		GameManager.Instance.player = this;
	}

    void Update()
    {
        //h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Jump();

    }

    private void FixedUpdate()
    {
        if (groundCheck)
            GroundCheck();

        if (isMove)
            Move();
    }


    void Move()
    {
        ri.velocity = tr.forward * moveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (jumpCount >= maxJumpCount)
            return;

        ++jumpCount;
        ri.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        if (groundCheckDelay != null)
        {
            StopCoroutine(groundCheckDelay);
        }
        groundCheckDelay = StartCoroutine(GroundCheckDelay());
        isGround = false;
    }

    void GroundCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundDistance))
        {
            isGround = true;
            jumpCount = 0;
        }
    }

    Coroutine groundCheckDelay = null;

    IEnumerator GroundCheckDelay()
    {
        groundCheck = false;
        yield return new WaitForSeconds(1f);
        groundCheck = true;
        groundCheckDelay = null;
    }

    /// <summary>
    /// 캐릭터의 이동속도를 변경합니다.
    /// </summary>
    /// <param name="changeSpeed">변화할 속도 값</param>
    public void OnChangeMoveSpeed(float changeSpeed)
    {
        if (changeMoveSpeed != null)
            StopCoroutine(changeMoveSpeed);

        changeMoveSpeed = StartCoroutine(ChangeMoveSpeed(changeSpeed));
    }

    /// <summary>
    /// 캐릭터의 이동속도를 변경합니다.
    /// </summary>
    /// <param name="changeSpeed">변화할 속도 값</param>
    /// <param name="time">지속 시간</param>
    public void OnChangeMoveSpeed(float changeSpeed, float time)
    {
        if (changeMoveSpeed != null)
            StopCoroutine(changeMoveSpeed);

        changeMoveSpeed = StartCoroutine(ChangeMoveSpeed(changeSpeed, time));
    }

    Coroutine changeMoveSpeed = null;

    IEnumerator ChangeMoveSpeed(float changeSpeed, float time = 2f)
    {
        moveSpeed = changeSpeed;
        yield return new WaitForSeconds(time);
        moveSpeed = basicMoveSpeed;
        changeMoveSpeed = null;
    }

    /// <summary>
    /// 캐릭터의 최대 점프 횟수를 증가합니다.
    /// </summary>
    /// <param name="max">최대 값</param>
    public void OnChangeJumpCount(int max) {
        maxJumpCount = max;
    }
}
