using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class button : MonoBehaviour
{
    public Image anhHD;
    public Image menu;
    public Image back;
   private audio music;
    void Start()
    {
        // anhHD.gameObject.SetActive(false);
        // menu.gameObject.SetActive(true);
     back.gameObject.SetActive(false);
    }

  private void Awake()
  {
    music = GameObject.FindGameObjectWithTag("audio").GetComponent<audio>();
  }


    void Update()
    {

    }
    public void chuyenHD()
    {
        anhHD.gameObject.SetActive(true);

    }
    public void playman1()
    {

        SceneManager.LoadScene(1);

    }

    public void backHD()
    {
        anhHD.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
   public void ChoilaiMan1(){

        SceneManager.LoadScene(0);
   }
      public void Menu(){

        SceneManager.LoadScene(0);
   }
      public void playman2(){

        SceneManager.LoadScene(2);
   }
    public void playman3(){

        SceneManager.LoadScene(3);
   }

public void bt_back(){
back.gameObject.SetActive(true);
music.PlaySfnhac(music.backG);
music.StopG();
}
   
   
}
