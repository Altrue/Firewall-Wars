using UnityEngine;
using System.Collections;

public class CanvasPause : MonoBehaviour {

    public RectTransform rt;

    // Use this for initialization
    void Awake () {
        // set the scaling
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);

        Debug.Log(Screen.width);
    }
}
