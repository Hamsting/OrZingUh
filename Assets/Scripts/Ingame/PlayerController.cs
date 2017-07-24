using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Transform), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	Energy.Type energyType;
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    float jumpPower = 5f;
    [SerializeField]
    int jumpCount = 0, maxJumpCount = 1;

    [SerializeField]
    float groundDistance = 1f;
    [SerializeField]
    bool groundCheck = true, isGround = false, isMove = true;

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
    }


    void Move()
    {
        Vector3 pos = tr.forward * moveSpeed * h;
        ri.velocity = new Vector3(pos.x, ri.velocity.y, pos.z);
    }

    void Jump()
    {
        if (jumpCount >= maxJumpCount)
            return;

        ++jumpCount;
        ri.velocity = new Vector3(ri.velocity.x, jumpPower, ri.velocity.z);

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
    public void OnChangeMoveSpeed(float _changeSpeed)
    {
        moveSpeed = _changeSpeed;
    }

    /// <summary>
    /// 캐릭터의 최대 점프 횟수를 증가합니다.
    /// </summary>
    /// <param name="max">최대 값</param>
    public void OnChangeJumpCount(int _max)
    {
        maxJumpCount = _max;
    }
}
