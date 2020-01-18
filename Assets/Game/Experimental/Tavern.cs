using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour
{
    public Transform player;
    AudioSource tavernMusic;
    bool inTavern;
    float sound_position;

    // Start is called before the first frame update
    void Start()
    {
        inTavern = false;
        tavernMusic = GetComponent<AudioSource>();
        sound_position = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inTavern);
        if(!inTavern && player.position.x < -188){
            //play music
            inTavern = true;
            tavernMusic.Play((ulong)sound_position);
        }

        if(inTavern && player.position.x > -188){
            //stop music
            inTavern = false;
            sound_position = tavernMusic.time;
            tavernMusic.Pause();
        }
    }
}
