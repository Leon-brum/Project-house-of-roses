using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider slider;
    PlayerBehaviour player;

    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();   
    }

    void Update()
    {
        slider.value = player.health;
    }
}
