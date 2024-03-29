using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    GameObject player;
    Vector3 PlayerPosition;
    Vector3 EnemyPosition;

    protected Rigidbody2D m_Rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected SpriteRenderer m_SpriteRender;
    protected Animator m_Animator;

    bool dieFlag = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        PlayerPosition = player.transform.position;
        EnemyPosition = transform.position;

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_CapsulleCollider = GetComponent<CapsuleCollider2D>();
        m_SpriteRender = GetComponent<SpriteRenderer>();
        m_Animator = GetComponent<Animator>();

    }

    void Update()
    {
        //画面内判定
        if (m_SpriteRender.isVisible)
        {
            PlayerPosition = player.transform.position;
            EnemyPosition = transform.position;

            //プレイヤーと敵のX座標の距離を判定
            if (PlayerPosition.x - EnemyPosition.x >= 3 && dieFlag == false)
            {
                //走る
                m_Animator.Play("Orc_boss_Run");

                //右に移動する
                transform.localScale = new Vector3(-2, 2, 1);
                EnemyPosition.x = EnemyPosition.x + 0.01f;

                if (PlayerPosition.x - EnemyPosition.x < 3)
                {
                    //攻撃する
                    m_Animator.Play("Orc_boss_Attack");

                }
            }

            //プレイヤーと敵のX座標の距離を判定
            else if (EnemyPosition.x - PlayerPosition.x >= 3 && dieFlag == false)
            {
                //走る
                m_Animator.Play("Orc_boss_Run");

                //左に移動する
                transform.localScale = new Vector3(2, 2, 1);
                EnemyPosition.x = EnemyPosition.x - 0.01f;

                if (EnemyPosition.x - PlayerPosition.x < 3)
                {
                    //攻撃する
                    m_Animator.Play("Orc_boss_Attack");

                }
            }

            transform.position = EnemyPosition;

        }
    }

    public void Die()
    {
        Destroy(m_Rigidbody);
        Destroy(m_CapsulleCollider);

        //倒れる
        m_Animator.Play("Orc_boss_Die");

        dieFlag = true;
    }
}
