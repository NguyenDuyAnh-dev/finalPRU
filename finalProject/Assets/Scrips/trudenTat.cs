using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trudenTat : MonoBehaviour
{
       void Start()
    {
         ani = GetComponent<Animator>();
    body = GetComponent<Rigidbody2D>();
    }
  private Animator ani;
    private Rigidbody2D body;
    // Update is called once per frame
    

   

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D o)
  {
    if(o.gameObject.tag== "player")
    {
   ani.SetBool("toeden",true);
     
    }

}
}
