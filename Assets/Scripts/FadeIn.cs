using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;

    private Image fadePanel;
    private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
        fadePanel = gameObject.GetComponent<Image>();
        currentColor = fadePanel.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
            currentColor.a = 1 - (Time.timeSinceLevelLoad / fadeInTime);
            fadePanel.color = currentColor;
        }
	}
}
