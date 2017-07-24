using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource aui;

    [SerializeField]
    AudioClip title, ingame;
    [SerializeField]
    AudioClip jump, touch, block;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            aui = GetComponent<AudioSource>();
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayTitle()
    {
        aui.Stop();
        aui.clip = title;
        aui.Play();
    }

    public void PlayInGame()
    {
        aui.Stop();
        aui.clip = ingame;
        aui.Play();
    }

    public void PlayJump()
    {
        aui.PlayOneShot(jump);
    }

    public void PlayTouch()
    {

        aui.PlayOneShot(touch);
    }

    public void PlayBlock()
    {

        aui.PlayOneShot(block);
    }

}
