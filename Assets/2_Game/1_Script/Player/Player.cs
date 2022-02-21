using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer PlayerSr;
    Rigidbody2D PlayerRig;

    float fMoveSpeed;
    float fJumpPower;

    public bool bJumpAccess;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSr = GetComponent<SpriteRenderer>();
        PlayerRig = GetComponent<Rigidbody2D>();
        fMoveSpeed = 5.0f;
        fJumpPower = 7.0f;
        bJumpAccess = true;
    }

    // Update is called once per frame
    void Update()
    {
        State();
        Move();
    }

    void State()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            PlayerSr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            PlayerSr.flipX = true;
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        PlayerRig.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (PlayerRig.velocity.x > fMoveSpeed)
        {
            PlayerRig.velocity = new Vector2(fMoveSpeed, PlayerRig.velocity.y);
        }
        else if (PlayerRig.velocity.x < fMoveSpeed * -1)
        {
            PlayerRig.velocity = new Vector2(fMoveSpeed * -1, PlayerRig.velocity.y);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            PlayerRig.velocity = new Vector2(PlayerRig.velocity.normalized.x * 0.5f, PlayerRig.velocity.y);
        }


        if (bJumpAccess && Input.GetKeyDown(KeyCode.Space))
        {
            bJumpAccess = false;
            PlayerRig.AddForce(Vector2.up * fJumpPower, ForceMode2D.Impulse);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("floor"))
        {
            bJumpAccess = true;
        }
    }

}
