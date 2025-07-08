using UnityEngine;

public class EnemyPatrolFollow : MonoBehaviour
{
    public Transform[] patrolPoints; // Các điểm tuần tra
    public float patrolSpeed = 2f;
    public float followSpeed = 3f;
    public float followRange = 5f; // Khoảng cách phát hiện player
    public float stopFollowRange = 7f; // Khoảng cách dừng đuổi
    public Transform player;

    private int currentPoint = 0;
    private bool isFollowing = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
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

        if (isFollowing)
        {
            // Đuổi theo player
            transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
        }
        else
        {
            // Tuần tra giữa các điểm
            if (patrolPoints.Length > 0)
            {
                Transform targetPoint = patrolPoints[currentPoint];
                transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    currentPoint = (currentPoint + 1) % patrolPoints.Length;
                }
            }
        }
    }
} 