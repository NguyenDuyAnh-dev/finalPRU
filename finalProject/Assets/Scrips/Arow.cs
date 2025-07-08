using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class Arow : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float force;
    private audio music;
  private void Awake()
  {
    music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
  }


    private float direc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sprite.flipX = player.GetComponent<SpriteRenderer>().flipX;
        rb.linearVelocity = new Vector2((direc = sprite.flipX ? -1 : 1) * force, rb.linearVelocity.y);
        //Hủy object sau 3s - chỉnh từ 1f lên 2f
        Invoke("DestroyGameObject", 2f);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "thuhoang")
        {
            GameObject.Find("text_thuhoang").GetComponent<Score>().UpdateScore();
// Điểm tăng khi va chạm
           
            Destroy(a.gameObject);
            DestroyGameObject();
            music.PlaySfnhac(music.nhacbanchetthuhoang);
        } 

    }
}
