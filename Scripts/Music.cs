using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour {
    public AudioClip[] clips;
    public Slider slider;
    public static Music instance;
    private static AudioSource source;
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        source = instance.GetComponent<AudioSource>();
        source.loop = true;
        source.volume = (float) 0.5;
    }
    private void Update() {
        source.volume = (float) (slider.value / 10.0);
        switch (SceneManager.GetActiveScene().name) {
            case "Menu":
                playMusic(0);
                break;
            case "Game":
                playMusic(1);
                break;
        }
    }
    private void playMusic(int index) {
        if (source.clip.name == clips[index].name)
            return;
        source.clip = clips[index];
        source.Play();
    }
}
