using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
	public Sprite[] walk; //プレイヤーの歩くスプライト配列
    public LayerMask GroundLayer;
    int animIndex; //歩くアニメーションのインデックス
	bool walkCheck; //歩いているかのチェック
    bool isGround = false;

	// Use this for initialization
	void Start ()
	{
		animIndex = 0;
		walkCheck = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
        Vector2 move;
        move.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 250;
        move.y = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Rigidbody2D>().velocity = move;
        Console.WriteLine(isGround);

        ////歩いていたら歩くアニメーションの再生
        //if (walkCheck)
        //{
        //    animIndex++;
        //    if (animIndex >= walk.Length)
        //    {
        //        animIndex = 0;
        //    }
        //    GetComponent<SpriteRenderer>().sprite = walk[animIndex];
        //}

        isGround = Physics2D.Linecast(this.transform.position, this.transform.position - transform.up * 1.2f, GroundLayer);

        if (Input.GetButtonDown("Jump") && isGround)
		{
            Vector2 jump = new Vector2(move.x, 500);
            this.GetComponent<Rigidbody2D>().AddForce(jump);
		}
	}
}