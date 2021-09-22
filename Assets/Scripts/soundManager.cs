using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    //Store all Sound Effects
    public static soundManager instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip hitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;
    //public AudioClip anotherOne;

    
    private AudioSource soundEffectAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (instance = null) {instance = this;}
        else if (instance != this) {Destroy(gameObject);}

        AudioSource[] sources = GetComponents<AudioSource>();
        foreach (AudioSource source in sources) {
            if (source.clip = null) {
                soundEffectAudio = source;
            }
        }
    }
     
    public void PlayOneShot(AudioClip clip)
    { 
        soundEffectAudio.PlayOneShot(clip);
    }

    // Update is called once per frame
  //  void Update()
  //  {
        
   // }
}
