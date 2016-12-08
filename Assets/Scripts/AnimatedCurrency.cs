using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatedCurrency : MonoBehaviour {

    public float duration;

    private Text componentText;
    private RectTransform rt;
    private float deathTime;
    private float x;
    private float y;

	// Use this for initialization
	void Start () {
        deathTime = Time.time + duration;
    }
	
	// Update is called once per frame
	void Update () {
	    if (deathTime < Time.time)
        {
            Destroy(this.gameObject);
        }
        else
        {
            y = y - 15 * Time.deltaTime;
            rt.anchoredPosition = new Vector3(x, y, 0);
        }
	}

    public void setY(float _y)
    {
        y = _y;
    }

    public void setText(string _text)
    {
        componentText = gameObject.GetComponent<Text>();
        rt = gameObject.GetComponent<RectTransform>();
        x = 0;
        componentText.text = _text;
    }
}
