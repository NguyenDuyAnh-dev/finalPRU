using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dichuyen : MonoBehaviour
{
  // Start is called before the first frame update
  private Animator ani;
  public float jump = 7f;
  private Rigidbody2D body;
  private audio music;
  public Vector3 offset; // Khai báo biến offset
  public Image back;
  public Image gameover;
  private bool isPaused = false;

  private void Awake()
  {
    music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
  }



  SpriteRenderer sprite;
  public float direction = 6f;
  bool checkGround = false;
  void Start()
  {
    sprite = GetComponent<SpriteRenderer>();
    ani = GetComponent<Animator>();
    body = GetComponent<Rigidbody2D>();
    offset = new Vector3(0f, 1f, 0f);
  }
  private bool isBanAnimationPlaying = false;
  public float speed = 8f;
  // Update is called once per frame
  void Update()
  {
    Vector2 move = new Vector2(Input.GetAxis("Horizontal"), 0f);
    transform.Translate(move * speed * Time.deltaTime);
    if (move.x < 0f)
    {
      sprite.flipX = true;
      direction = -1f;
    }
    else if (move.x > 0f)
    {
      sprite.flipX = false;
      direction = 1f;
    }


    if (Input.GetKey(KeyCode.Space) && checkGround == true)
    {
      body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
      checkGround = false;
    }
    // Kiểm tra nếu animation "ban" không đang phát và người chơi nhấn phím H
    if (Input.GetKeyDown(KeyCode.H) && !isBanAnimationPlaying)
    {
      StartCoroutine(PlayBanAnimation());
    }

    ani.SetBool("chay", Input.GetAxis("Horizontal") != 0);


    if (Input.GetKeyDown(KeyCode.P))
    {
      if (isPaused)
      {
        ResumeGame();
      }
      else
      {
        PauseTheGame();
      }
    }


    void PauseTheGame()
    {
      Time.timeScale = 0; // Dừng thời gian trong game
      isPaused = true;
      music.StopG();
    }

    void ResumeGame()
    {
      Time.timeScale = 1; // Tiếp tục thời gian trong game
      isPaused = false;
      music.Nhacnen();
    }
  }

  IEnumerator PlayBanAnimation()
  {
    // Phát animation "ban"
    ani.SetBool("ban", true);
    isBanAnimationPlaying = true;

    // Đợi cho đến khi animation "ban" kết thúc
    yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);

    // Tắt animation "ban" và đặt biến cờ isBanAnimationPlaying thành false
    ani.SetBool("ban", false);
    isBanAnimationPlaying = false;
    music.PlaySfnhac(music.nhacbancung);
  }
  void OnCollisionEnter2D(Collision2D obj)
  {
    if (obj.gameObject.tag == "ground")
    {
      checkGround = true;
    }



  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "back")
    {
      back.gameObject.SetActive(true);
      music.PlaySfnhac(music.backG);
      music.StopG();
    }
    if (other.tag == "back1")
    {
      back.gameObject.SetActive(true);
      music.PlaySfnhac(music.backG);
      music.StopG();
    }
    if (other.tag == "backmenu")
    {
      SceneManager.LoadScene(0);
    }
    if (other.tag == "wall")
    {
      gameover.gameObject.SetActive(true);
      music.PlaySfnhac(music.nhacOver);
      music.StopG();
    }
  }

}
