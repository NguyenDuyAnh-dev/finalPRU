using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traiphai : MonoBehaviour
{public float start, end;
public float speed = 1f; // Điều chỉnh tốc độ di chuyển
private bool movingRight = true; // Cờ để xác định hướng di chuyển
private Rigidbody2D rb; // Thành phần vật lý Rigidbody
private bool isPlayerOnTop = false; // Cờ để xác định người chơi có đứng bên trên không
private GameObject player; // Tham chiếu đến người chơi

void Start()
{
    // Lấy tham chiếu đến thành phần Rigidbody
    rb = GetComponent<Rigidbody2D>();

    // Lấy tham chiếu đến đối tượng người chơi
    player = GameObject.FindGameObjectWithTag("player");
}

void Update()
{
    // Kiểm tra xem người chơi có đứng bên trên không
    if (isPlayerOnTop)
    {
        // Xử lý di chuyển khi người chơi đứng bên trên
        // Ví dụ: Di chuyển theo input của người chơi
        float moveInput = Input.GetAxis("Horizontal");
        float moveSpeed = speed * moveInput;
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        // Di chuyển người chơi theo đối tượng
        player.transform.Translate(new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime);
    }
    else
    {
        // Xử lý di chuyển theo quy tắc hiện tại (ví dụ: di chuyển từ start đến end)
        float newPosition = transform.position.x + (speed * (movingRight ? 1 : -1) * Time.deltaTime);

        if (newPosition >= end)
        {
            newPosition = end;
            movingRight = false;
        }
        else if (newPosition <= start)
        {
            newPosition = start;
            movingRight = true;
        }

        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}

void OnCollisionEnter2D(Collision2D collision)
{
    // Kiểm tra xem có va chạm từ phía trên không
    foreach (ContactPoint2D contactPoint in collision.contacts)
    {
        if (contactPoint.normal.y > 0.8f && collision.gameObject.CompareTag("player"))
        {
            // Có va chạm từ phía trên (người chơi đứng bên trên)
            isPlayerOnTop = true;
            break;
        }
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    // Kiểm tra xem có va chạm từ phía trên không
    foreach (ContactPoint2D contactPoint in collision.contacts)
    {
        if (contactPoint.normal.y > 0.8f && collision.gameObject.CompareTag("player"))
        {
            // Không còn va chạm từ phía trên (người chơi không đứng bên trên)
            isPlayerOnTop = false;
            break;
        }
    }
}
}
