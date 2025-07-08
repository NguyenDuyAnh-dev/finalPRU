using UnityEngine;

public class Heart : MonoBehaviour
{
    public int healAmount = 1;
    public AudioClip collectSound; // Âm thanh khi ăn Heart
    public GameObject collectEffect; // Hiệu ứng khi ăn Heart
    private static bool hasHealedThisFrame = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") && !hasHealedThisFrame)
        {
            VaCham player = other.GetComponent<VaCham>();
            if (player != null)
            {
                player.Heal(healAmount);
                // Tăng điểm khi ăn Heart
                GameObject scoreObj = GameObject.Find("text_thuhoang");
                if (scoreObj != null)
                {
                    Score score = scoreObj.GetComponent<Score>();
                    if (score != null)
                    {
                        score.UpdateScore();
                    }
                }
                // Hiệu ứng particle
                if (collectEffect != null)
                {
                    Instantiate(collectEffect, transform.position, Quaternion.identity);
                }
                // Phát âm thanh
                GameObject audioObj = GameObject.FindGameObjectWithTag("audio");
                if (audioObj != null && collectSound != null)
                {
                    audio audioScript = audioObj.GetComponent<audio>();
                    if (audioScript != null)
                    {
                        audioScript.PlaySfnhac(collectSound);
                    }
                }
                hasHealedThisFrame = true;
            }
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        hasHealedThisFrame = false; // Reset flag mỗi frame
    }
} 