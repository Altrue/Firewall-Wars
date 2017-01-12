using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CanvasUI : MonoBehaviour {

    public Text currencyText;
    public AnimatedCurrency animatedCurrency; // For animations
    public Player player;
    public Image bgHp;
    public Image bgHpAura;
    public Image hpBar;

    public List<Image> turretButtonList = new List<Image>();
    public List<Image> turretButtonAuraList = new List<Image>();

    public Image turretButton1;
    public Image turretButton1Aura;

    public Image turretButton2;
    public Image turretButton2Aura;

    public Image turretButton3;
    public Image turretButton3Aura;

    public Image turretButton4;
    public Image turretButton4Aura;

    public Image turretButton5;
    public Image turretButton5Aura;

    public Image turretActionBuild1;
    public Image turretActionBuild2;
    public Image turretActionBuild3;
    public Image turretActionReturn;
    public Image turretActionSell;

    private float maxHp;
    private float lastAnimation;
    private float lastY = -55f;
    private RectTransform rtHpBar;
    private float maxHpBarWidth;
    private float maxHpBarHeight;

    private Color colorButtonInactive = new Color32(100, 100, 100, 255);
    private Color colorButtonActive1 = new Color32(10, 150, 255, 255);
    private Color colorButtonActive2 = new Color32(10, 255, 150, 255);
    private Color colorButtonActive3 = new Color32(255, 255, 50, 255);


    // Use this for initialization
    void Awake () {
        maxHp = player.getMaxHp();
        rtHpBar = hpBar.GetComponent<RectTransform>();
        maxHpBarWidth = rtHpBar.sizeDelta.x;
        maxHpBarHeight = rtHpBar.sizeDelta.y;

        turretButton1.color = colorButtonInactive;
        turretButton1Aura.color = colorButtonInactive;

        turretButton2.color = colorButtonInactive;
        turretButton2Aura.color = colorButtonInactive;

        turretButton3.color = colorButtonInactive;
        turretButton3Aura.color = colorButtonInactive;

        turretButton4.color = colorButtonInactive;
        turretButton4Aura.color = colorButtonInactive;

        turretButton5.color = colorButtonInactive;
        turretButton5Aura.color = colorButtonInactive;

        turretButtonList.Add(turretButton1);
        turretButtonList.Add(turretButton2);
        turretButtonList.Add(turretButton3);
        turretButtonList.Add(turretButton4);
        turretButtonList.Add(turretButton5);

        turretButtonAuraList.Add(turretButton1Aura);
        turretButtonAuraList.Add(turretButton2Aura);
        turretButtonAuraList.Add(turretButton3Aura);
        turretButtonAuraList.Add(turretButton4Aura);
        turretButtonAuraList.Add(turretButton5Aura);

    turretActionBuild1.enabled = false;
    turretActionBuild2.enabled = false;
    turretActionBuild3.enabled = false;
    turretActionReturn.enabled = false;
    turretActionSell.enabled = false;

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

        List<HexCell> tourellesSlotList = player.tourellesManager.tourellesSlotList;
        int counter = 0;
        foreach (HexCell tourelleSlot in tourellesSlotList)
        {
            switch (tourelleSlot.tourelleType)
            {
                case 0:
                turretButtonList[counter].color = colorButtonInactive;
                turretButtonAuraList[counter].color = colorButtonInactive;
                break;
                case 1:
                turretButtonList[counter].color = colorButtonActive1;
                turretButtonAuraList[counter].color = colorButtonActive1;
                break;
                case 2:
                turretButtonList[counter].color = colorButtonActive2;
                turretButtonAuraList[counter].color = colorButtonActive2;
                break;
                case 3:
                turretButtonList[counter].color = colorButtonActive3;
                turretButtonAuraList[counter].color = colorButtonActive3;
                break;
            }
            counter++;
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
