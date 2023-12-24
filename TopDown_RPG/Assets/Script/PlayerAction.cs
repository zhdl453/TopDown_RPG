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

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp) isHorizonMove = true;
        else if (vDown || hUp) isHorizonMove = false;

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed; //리지드의 속도설정
    }
}
