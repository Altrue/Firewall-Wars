using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasPause : MonoBehaviour {

    
    public GameObject imagePause;
    public GameObject textPause;

    private Image RTTextPause;

    // Use this for initialization
    void Awake () {
        RTTextPause = textPause.GetComponent<Image>();

        // Set the scaling
        imagePause.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        textPause.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        // Set the color (and opacity)
        RTTextPause.color = new Color32(255, 255, 255, 255);
    }

    void Update ()
    {
        float time = Time.fixedTime * 2f;
        Color colorTemp = new Color32(255, 255, 255, 255);
        colorTemp.a = 0.85f + ((float)System.Math.Sin(time)) * 0.25f;
        RTTextPause.color = colorTemp;
    }
}
