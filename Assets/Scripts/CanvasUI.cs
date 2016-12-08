using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour {

    public Text currencyText;
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
        currencyText.text = player.getCurrency() + "¤";
        hpText.text = player.getHP() + " / " + maxHp + " HP";
    }
}
