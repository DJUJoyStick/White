using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject WaveGams;

    SpriteRenderer PlayerSr;
    Rigidbody2D PlayerRig;

    PLAYERDIRECT Direction;

    float fMoveSpeed;
    float fJumpPower;

    public bool bPlayerDie;
    public bool bJumpAccess;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSr = GetComponent<SpriteRenderer>();
        PlayerRig = GetComponent<Rigidbody2D>();
        fMoveSpeed = 5.0f;
        fJumpPower = 10.0f;
        bPlayerDie = false;
        bJumpAccess = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bTimePause)
        {
            State();
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !SGameMng.I.bMinGame)
            SGameMng.I.PauseGame();
    }

    void State()
    {
        if (!bPlayerDie)
        {
            Skill();

            if (Input.GetMouseButtonDown(0))
            {
                SGameMng.I.Raycast();
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (SGameMng.I.bIsSelecting)
                {
                    SGameMng.I.DropItem();
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerSr.flipX = false;
            if (bJumpAccess)
                Direction = PLAYERDIRECT.LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerSr.flipX = true;
            if (bJumpAccess)
                Direction = PLAYERDIRECT.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SGameMng.I.nColorCount = 1;
            SGameMng.I.ColorText.text = "현재 색상 : 빨간색";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SGameMng.I.nColorCount = 2;
            SGameMng.I.ColorText.text = "현재 색상 : 초록색";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SGameMng.I.nColorCount = 3;
            SGameMng.I.ColorText.text = "현재 색상 : 파란색";
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (!bJumpAccess)
        {
            if (Direction.Equals(PLAYERDIRECT.NONE))
                h = 0;
            else if (Direction.Equals(PLAYERDIRECT.LEFT))
                h = -1;
            else if (Direction.Equals(PLAYERDIRECT.RIGHT))
                h = 1;
        }

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
            Direction = PLAYERDIRECT.NONE;
        }

        if (bJumpAccess && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRig.AddForce(Vector2.up * fJumpPower, ForceMode2D.Impulse);
        }
    }

    void Skill()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(WaveGams, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("floor"))
        {
            bJumpAccess = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("floor"))
        {
            bJumpAccess = false;
        }
    }
}
