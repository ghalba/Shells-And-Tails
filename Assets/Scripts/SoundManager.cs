using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider MusicSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MusicVolume()
    {
        AudioListener.volume = MusicSlider.value;
    }
}
