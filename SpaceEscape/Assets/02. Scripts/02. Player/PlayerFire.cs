using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    public AudioClip fireSfx;       //SFX 음원
    private new AudioSource audio;  //AudioSource Component 저장 변수
    public GameObject muzzleEffect;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume -= 0.02f;
    }

    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused || GameManager.instance.isShowScript 
            || GameManager.instance.isShowPanel || GameManager.instance.isShowAlpha) return;

        if (Input.GetMouseButtonDown(0)) Fire();
    }

    void Fire()
    {
        GameObject muzzleCopied = Instantiate(muzzleEffect, firePos.position, firePos.rotation, firePos);
        Destroy(muzzleCopied, 0.5f);

        Instantiate(bullet, firePos.position, firePos.rotation);
        audio.PlayOneShot(fireSfx, 1.0f);
    }
}
