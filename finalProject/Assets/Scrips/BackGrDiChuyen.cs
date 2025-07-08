using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrDiChuyen : MonoBehaviour
{
     public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
         cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x , cam.position.y , 0);  
    }
}
