using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_BackGround : MonoBehaviour
{
    public AudioClip TheInvasion;       // InGame BackGround ³ë·¡ = The Invasion
    private new AudioSource audio;  

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
