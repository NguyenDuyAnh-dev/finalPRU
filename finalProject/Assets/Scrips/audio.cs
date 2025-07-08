using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class audio : MonoBehaviour
{
  public AudioSource music;
  public AudioSource sf;
  // Start is called before the first frame update
  public AudioClip nhacnen;
  public AudioClip nhacbancung;
  public AudioClip nhacbanchetthuhoang;
  public AudioClip nhacWin;
  public AudioClip nhactrudiem;
  public AudioClip nhacOver;
public AudioClip backG;

  void Start()
  {
    music.clip = nhacnen;
    music.Play();
  }
  public void PlaySfnhac(AudioClip sfclip)
  {
    sf.clip = sfclip;
    sf.Play();
  }
  public void Nhacnen(){
     music.clip = nhacnen;
    music.Play();
  }
  public void StopG()
  {
    if (music.isPlaying)
    {
      music.Stop();
    }
  }

}