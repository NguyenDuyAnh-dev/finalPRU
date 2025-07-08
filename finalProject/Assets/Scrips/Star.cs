using UnityEngine;

public class Star : MonoBehaviour
{
    public int scoreAmount = 1;
    public AudioClip collectSound; // Kéo file âm thanh vào đây trong Inspector
    public GameObject collectEffect; // Kéo prefab hiệu ứng vào đây trong Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // Tăng điểm
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
            // Xóa star khỏi scene
            Destroy(gameObject);
        }
    }
} 