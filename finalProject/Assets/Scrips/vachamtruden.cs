using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vachamtruden : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }public GameObject door1; // Tham chiếu tới GameObject của cánh cửa số 1
    public GameObject door2; // Tham chiếu tới GameObject của cánh cửa số 2
     public GameObject door3; // Tham chiếu tới GameObject của cánh cửa số 3

   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "truden1") // Kiểm tra va chạm với trụ đèn số 1
        {
            Destroy(door1); // Hủy bỏ GameObject của cánh cửa
        }
        else if (collision.gameObject.tag == "truden2") // Kiểm tra va chạm với trụ đèn số 2
        {
            Destroy(door2); // Hủy bỏ GameObject của cánh cửa
        }
         else if (collision.gameObject.tag == "truden3") // Kiểm tra va chạm với trụ đèn số 2
        {
            Destroy(door3); // Hủy bỏ GameObject của cánh cửa
        }
    }
}
