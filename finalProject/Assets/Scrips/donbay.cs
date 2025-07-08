using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donbay : MonoBehaviour
{
   public float doNay = 13.0f;
    public SpriteRenderer mauSac;
    // Start is called before the first frame update
    void Start()
    {
        mauSac = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * doNay, ForceMode2D.Impulse);
            // Addforce : dùng ?? tác ??ng m?t cái l?c (Vector2.up tác ??ng lên trên)
            // ForceMode2D.Impulse : giúp tác ??ng ngay t?c thì
            mauSac.color = Color.red;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            mauSac.color = Color.white;
        }
    }
}
