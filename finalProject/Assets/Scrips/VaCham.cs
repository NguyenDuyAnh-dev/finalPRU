using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VaCham : MonoBehaviour
{

    public int heath = 5;
    public Image anhOver;
    public Image anhWin;
    public Text scoreOverText;
    public Text scoreWinText;
       private audio music;
    public bool isInvincible = false;
    private float invincibleTimer = 0f;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

  private void Awake()
  {
    music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
  }
    void Start()
    {

        Time.timeScale = 1;
     anhOver.gameObject.SetActive(false);
      anhWin.gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        //t.text = d.ToString();
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                isInvincible = false;
                spriteRenderer.color = originalColor;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isInvincible) return;
        if (other.tag == "thuhoang")
        {
            heath = heath - 1;
              music.PlaySfnhac(music.nhactrudiem);
        }

        if (other.tag == "nuoc")
        {
            heath = heath - 1;
            music.PlaySfnhac(music.nhactrudiem);
        }
        if (heath == 0)
        {
            Time.timeScale = 0;
            anhOver.gameObject.SetActive(true);
            GameObject scoreObj = GameObject.Find("text_thuhoang");
            if (scoreObj != null && scoreOverText != null)
            {
                Score score = scoreObj.GetComponent<Score>();
                if (score != null)
                {
                    scoreOverText.text = "Score: " + score.GetCurrentScore();
                }
            }
            music.StopG();
            music.PlaySfnhac(music.nhacOver);
        }
        if (other.tag == "win")
        {
            Time.timeScale = 0;
            anhWin.gameObject.SetActive(true);
            GameObject scoreObj = GameObject.Find("text_thuhoang");
            if (scoreObj != null && scoreWinText != null)
            {
                Score score = scoreObj.GetComponent<Score>();
                if (score != null)
                {
                    scoreWinText.text = "Score: " + score.GetCurrentScore();
                }
            }
            music.StopG();
            music.PlaySfnhac(music.nhacWin);
        }
    }

    public void Heal(int amount)
    {
        heath += amount;
        if (heath > 5) heath = 5;
    }

    public void StartInvincible(float duration)
    {
        isInvincible = true;
        invincibleTimer = duration;
        spriteRenderer.color = Color.yellow;
    }
}
