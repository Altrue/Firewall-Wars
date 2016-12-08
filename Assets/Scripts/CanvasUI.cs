using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour {

    public Text currencyText;
    public AnimatedCurrency animatedCurrency; // For animations
    public Text hpText; // <- DEBUG
    public Player player;

    private float maxHp;

	// Use this for initialization
	void Awake () {
        maxHp = player.getMaxHp();
        updateUI();
	}
	
	// Update is called once per frame
	void Update () {
        updateUI();
	}

    void updateUI()
    {
        currencyText.GetComponent<Text>().text = player.getCurrency() + "¤";
        hpText.text = player.getHP() + " / " + maxHp + " HP";
    }

    public void animateCurrencyChange(int _value)
    {
        string prefix = "+";
        if (_value < 0)
        {
            prefix = "-";
        }

        string textChange = prefix + _value + " ¤";

        AnimatedCurrency newAnimatedCurrency = Instantiate(animatedCurrency);
        newAnimatedCurrency.transform.parent = this.gameObject.transform;
        newAnimatedCurrency.setText(textChange);
    }
}
