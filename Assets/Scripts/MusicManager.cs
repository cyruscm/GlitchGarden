using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audio;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsManager.GetMasterVolume();
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void SetVolume(float volume) {
        audio.volume = volume;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        int level = scene.buildIndex;
        if (levelMusicChangeArray.Length > level && levelMusicChangeArray[level] != null) {
            AudioClip clip = levelMusicChangeArray[level];
            if (audio.clip != clip) {
                Debug.Log("Playing " + level);
                audio.clip = clip;
                audio.Play();
            } else {
                Debug.Log("Continuing current song.");
            }
        } else {
            Debug.Log("no audio available for level " + level);
        }
    }
}
