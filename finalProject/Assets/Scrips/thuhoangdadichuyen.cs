using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thuhoangdadichuyen : MonoBehaviour
{
    public float start;
    public float end;
    public float speed = 1f; // Tốc độ di chuyển của vật thể
    private bool movingRight = true; // Cờ để xác định hướng di chuyển
    private SpriteRenderer spriteRenderer;
    public Transform player; // Tham chiếu tới player
    public float followRange = 5f; // Khoảng cách phát hiện player
    public float stopFollowRange = 7f; // Khoảng cách dừng đuổi
    private bool isFollowing = false;
    private Vector3 startPos;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    private void Update()
    {
        float distToPlayer = player != null ? Vector2.Distance(transform.position, player.position) : Mathf.Infinity;
        float distToStart = Vector2.Distance(transform.position, startPos);
        // Nếu player trong vùng phát hiện và quái chưa ra khỏi vùng tuần tra
        if (distToPlayer < followRange && distToStart < stopFollowRange)
        {
            isFollowing = true;
        }
        // Nếu player ra xa hoặc quái ra khỏi vùng tuần tra thì dừng đuổi
        if (distToPlayer > stopFollowRange || distToStart > stopFollowRange)
        {
            isFollowing = false;
        }
        if (isFollowing && player != null)
        {
            // Đuổi theo player chỉ theo trục X
            Vector3 targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            spriteRenderer.flipX = (player.position.x < transform.position.x);
        }
        else
        {
            // Tuần tra như cũ
            float newPosition = transform.position.x + (speed * (movingRight ? 1 : -1) * Time.deltaTime);
            if (newPosition >= end)
            {
                newPosition = end;
                movingRight = false;
                spriteRenderer.flipX = true;
            }
            else if (newPosition <= start)
            {
                newPosition = start;
                movingRight = true;
                spriteRenderer.flipX = false;
            }
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
    }
}
