using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    float h;
    float v;
    bool isHorizonMove; //상하좌우만 움직이게 하고 싶음
    public float speed;
    Vector3 dirVec; //현재 바라보고 있는 방향 값을 가진 변수가 필요함
    GameObject scanObject;

    Rigidbody2D rigid;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //이부분 진짜 이해안감..ㅜㅜ 노션정리한거 참고
        if (hDown) isHorizonMove = true;
        else if (vDown) isHorizonMove = false;
        else if (hUp || vUp) isHorizonMove = h != 0;

        //애니메이션
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        //Direction
        if (vDown && v == 1) dirVec = Vector3.up; //위에 누른거
        else if (vDown && v == -1) dirVec = Vector3.down;
        else if (hDown && h == 1) dirVec = Vector3.right;
        else if (hDown && h == -1) dirVec = Vector3.left;

        //Scan
        if (Input.GetButtonDown("Jump") && scanObject != null) //유니티에서 스페이스바가 Jump로 등록되어있음.(input manager에서 확인해보셈)
        {
            Debug.Log($"This is : " + scanObject.name);
        }
    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed; //리지드의 속도설정

        //스킬류는 Ray씀(현재위치, 목표방향으로의 길이, 색깔)
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null) //null이 아니면 사물이 있다는 뜻
        {
            scanObject = rayHit.collider.gameObject; //RayCast된 오브젝트를 변수로 저장하여 활용;
        }
        else
        {
            scanObject = null;
        }
    }
}
