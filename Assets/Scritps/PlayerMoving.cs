using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public enum State { Stand, Run, Jump, Hit, Slide }
    public float JumpPower;
    public bool isGround;
    int JumpScore = 0;
    public int Life = 5;


    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            ChangeAnim(State.Run);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        }
        if (Input.GetButtonDown("Jump") && JumpPower != 2 && !Input.GetButton("Fire1"))
        {
            isGround = false;
            ChangeAnim(State.Jump);
            rigid.velocity = Vector2.up * JumpPower;
            ++JumpScore;

        }
        else if (Input.GetButton("Fire1"))
        {
            ChangeAnim(State.Slide);
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }

    }

    // 3. 착지 (물리 충돌 이벤트)
    void OnCollisionStay2D(Collision2D collision) // 충돌 발생시 호출되는 함수
    {
        if (isGround)
        {
            ChangeAnim(State.Run);
        }
        JumpScore = 0;
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }

    // 4. 장애물 터치 (트리거 충돌 이벤트)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            --Life;
            if (Life == 0)
            {
                ChangeAnim(State.Hit);
                rigid.simulated = false;
            }
        }
    }

    // 5. 애니메이션
    void ChangeAnim(State state)
    {
        anim.SetInteger("State", (int)state); 
    }
}
