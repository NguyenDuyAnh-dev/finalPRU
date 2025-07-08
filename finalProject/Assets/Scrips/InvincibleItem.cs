using UnityEngine;

public class InvincibleItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            VaCham player = other.GetComponent<VaCham>();
            if (player != null)
            {
                player.StartInvincible(5f); // Bất tử 5 giây
            }
            Destroy(gameObject); // Xóa item sau khi nhặt
        }
    }
} 