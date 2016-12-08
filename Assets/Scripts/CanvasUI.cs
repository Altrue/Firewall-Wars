using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour {

    public Text currencyText;
    public AnimatedCurrency animatedCurrency; // For animations
    public Player player;
    public Image bgHp;
    public Image bgHpAura;
    public Image hpBar;

    private float maxHp;
    private float lastAnimation;
    private float lastY = -55f;
    private RectTransform rtHpBar;
    private float maxHpBarWidth;
    private float maxHpBarHeight;


    // Use this for initialization
    void Awake () {
        maxHp = player.getMaxHp();
        rtHpBar = hpBar.GetComponent<RectTransform>();
        maxHpBarWidth = rtHpBar.sizeDelta.x;
        maxHpBarHeight = rtHpBar.sizeDelta.y;
        updateUI();
	}
	
	// Update is called once per frame
	void Update () {
        updateUI();
	}

    void updateUI()
    {
        float currentHpRatio = player.getHP() / maxHp;
        currencyText.GetComponent<Text>().text = player.getCurrency() + "¤";
        rtHpBar.sizeDelta = new Vector2((currentHpRatio * maxHpBarWidth),maxHpBarHeight);

        if (currentHpRatio < 0.3f)
        {
            float time = Time.fixedTime * 2f;
            Color colorTempSlow = new Color32(255, 0, 0, 255);
            Color colorTempFast = new Color32(255, 0, 0, 255);
            colorTempSlow.a = 1.15f + ((float)System.Math.Sin(time)) * 0.35f;
            colorTempFast.a = 0.8f + ((float)System.Math.Sin(time * 1.682f)) * 0.3f;
            bgHpAura.color = colorTempFast;
            hpBar.color = colorTempSlow;
        }
        else if (currentHpRatio < 0.5f)
        {
            bgHpAura.color = new Color32(255, 255, 0, 255);
            hpBar.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            Color tempColor = new Color32(60,171,255,255);
            hpBar.color = new Color32(60, 171, 255, 255);
            bgHpAura.color = tempColor;
        }
    }

    public void animateCurrencyChange(int _value)
    {
        string prefix = "+";
        if (_value < 0)
        {
            prefix = "";
        }

        string textChange = prefix + _value + " ¤";

        if ((Time.time - lastAnimation < 0.5f))
        {
            lastY = lastY + 18f;
        }
        else
        {
            lastY = -70f;
        }
        lastAnimation = Time.time;
        AnimatedCurrency newAnimatedCurrency = Instantiate(animatedCurrency);
        newAnimatedCurrency.transform.SetParent(this.gameObject.transform);
        newAnimatedCurrency.setY(lastY);
        newAnimatedCurrency.setText(textChange);
    }
}
