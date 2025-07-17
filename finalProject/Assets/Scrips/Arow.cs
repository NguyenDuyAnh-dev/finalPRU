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

	private float direc;

	private void Awake()
	{
		music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
	}

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
		sprite = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		sprite.flipX = player.GetComponent<SpriteRenderer>().flipX;

		// Tăng tốc độ bay
		rb.linearVelocity = new Vector2((direc = sprite.flipX ? -1 : 1) * force * 2f, 0);

		// Không va chạm với người chơi
		Collider2D playerCol = player.GetComponent<Collider2D>();
		Collider2D bulletCol = GetComponent<Collider2D>();
		if (playerCol != null && bulletCol != null)
		{
			Physics2D.IgnoreCollision(playerCol, bulletCol);
		}

		// Giảm thời gian tồn tại mũi tên
		Invoke("DestroyGameObject", 1.2f);
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
			Destroy(a.gameObject);
			DestroyGameObject();
			music.PlaySfnhac(music.nhacbanchetthuhoang);
		}
	}
}