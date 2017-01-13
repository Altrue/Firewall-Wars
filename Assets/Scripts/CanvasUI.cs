using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class CanvasUI : MonoBehaviour, IPointerClickHandler {

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
    private int buildMenuSlot; // 0 = Build menu not open

    private Color colorButtonInactive = new Color32(100, 100, 100, 255);
    private Color colorButtonActive1 = new Color32(10, 150, 255, 255);
    private Color colorButtonActive2 = new Color32(10, 255, 150, 255);
    private Color colorButtonActive3 = new Color32(255, 255, 50, 255);

    public Color hexColorSelected = new Color(255, 255, 100);
    public Color hexColorNormal = new Color(0, 0, 0);


    // Use this for initialization
    void Awake () {

    buildMenuSlot = 0;
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
            lastY = lastY + 45f;
        }
        else
        {
            lastY = -180f;
        }
        lastAnimation = Time.time;
        AnimatedCurrency newAnimatedCurrency = Instantiate(animatedCurrency);
        newAnimatedCurrency.transform.SetParent(this.gameObject.transform);
        newAnimatedCurrency.setY(lastY);
        newAnimatedCurrency.setText(textChange);
    }

    public void displayBuildMenu(int slotNumber)
    {
        List<HexCell> tourellesSlotList = player.tourellesManager.tourellesSlotList;
        buildMenuSlot = slotNumber;
        player.hackersManager.hexGrid.changeCellColor(tourellesSlotList[slotNumber - 1].coordinates, hexColorSelected);

        if (tourellesSlotList[slotNumber - 1].tourelleType > 0)
        {
            turretActionSell.enabled = true;
        }
        else
        {
            turretActionSell.enabled = false;
            if (tourellesSlotList[slotNumber - 1].tourelleType == 1 || player.getCurrency() < player.tourellesManager.tourellePrefab.cost)
            {
                turretActionBuild1.enabled = false;
            }
            else
            {
                turretActionBuild1.enabled = true;
            }

            if (tourellesSlotList[slotNumber - 1].tourelleType == 2 || player.getCurrency() < player.tourellesManager.tourellePrefab2.cost)
            {
                turretActionBuild2.enabled = false;
            }
            else
            {
                turretActionBuild2.enabled = true;
            }

            if (tourellesSlotList[slotNumber - 1].tourelleType == 3 || player.getCurrency() < player.tourellesManager.tourellePrefab3.cost)
            {
                turretActionBuild3.enabled = false;
            }
            else
            {
                turretActionBuild3.enabled = true;
            }
        }
        
        turretActionReturn.enabled = true;

        turretButton1.enabled = false;
        turretButton1Aura.enabled = false;
        turretButton2.enabled = false;
        turretButton2Aura.enabled = false;
        turretButton3.enabled = false;
        turretButton3Aura.enabled = false;
        turretButton4.enabled = false;
        turretButton4Aura.enabled = false;
        turretButton5.enabled = false;
        turretButton5Aura.enabled = false;
    }

    public void closeBuildMenu()
    {
        List<HexCell> tourellesSlotList = player.tourellesManager.tourellesSlotList;
        player.hackersManager.hexGrid.changeCellColor(tourellesSlotList[buildMenuSlot - 1].coordinates, hexColorNormal);
        buildMenuSlot = 0;

        turretActionBuild1.enabled = false;
        turretActionBuild2.enabled = false;
        turretActionBuild3.enabled = false;
        turretActionReturn.enabled = false;
        turretActionSell.enabled = false;

        turretButton1.enabled = true;
        turretButton1Aura.enabled = true;
        turretButton2.enabled = true;
        turretButton2Aura.enabled = true;
        turretButton3.enabled = true;
        turretButton3Aura.enabled = true;
        turretButton4.enabled = true;
        turretButton4Aura.enabled = true;
        turretButton5.enabled = true;
        turretButton5Aura.enabled = true;
    }

    public void tourelleSell()
    {
        List<HexCell> tourellesSlotList = player.tourellesManager.tourellesSlotList;
        int currencyToAdd = 0;
        switch (tourellesSlotList[buildMenuSlot - 1].tourelleType)
        {
            case 1:
                currencyToAdd = player.tourellesManager.tourellePrefab.cost;
                break;
            case 2:
                currencyToAdd = player.tourellesManager.tourellePrefab2.cost;
                break;
            case 3:
                currencyToAdd = player.tourellesManager.tourellePrefab3.cost;
                break;
            default:
                Debug.Log("ERROR : Pas de type de tourelle trouvé lors de la tentative de vente");
                return;
        }
        player.addCurrency(currencyToAdd - 5);
        Tourelle turretAboutToDie = tourellesSlotList[buildMenuSlot - 1].tourelleInstance;
        tourellesSlotList[buildMenuSlot - 1].unsetTurret();
        turretAboutToDie.kill();
        turretButtonList[buildMenuSlot - 1].color = colorButtonInactive;
        turretButtonAuraList[buildMenuSlot - 1].color = colorButtonInactive;
    }

    public void BuildTurret(int turretType)
    {
        List<HexCell> tourellesSlotList = player.tourellesManager.tourellesSlotList;
        switch (turretType)
        {
            case 1:
                player.tourellesManager.addTourelle1(tourellesSlotList[buildMenuSlot - 1]);
                break;
            case 2:
                player.tourellesManager.addTourelle2(tourellesSlotList[buildMenuSlot - 1]);
                break;
            case 3:
                player.tourellesManager.addTourelle3(tourellesSlotList[buildMenuSlot - 1]);
                break;
            default:
                Debug.Log("ERREUR : Type de tourelle non défini pour achat");
                return;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch(eventData.pointerPressRaycast.gameObject.name)
        {
            case "turretbt1":
                displayBuildMenu(1);
            break;
            case "turretbt2":
                displayBuildMenu(2);
                break;
            case "turretbt3":
                displayBuildMenu(3);
                break;
            case "turretbt4":
                displayBuildMenu(4);
                break;
            case "turretbt5":
                displayBuildMenu(5);
            break;
            case "turretbtBuild1":
                if (player.getCurrency() > player.tourellesManager.tourellePrefab.cost)
                {
                    BuildTurret(1);
                }
                closeBuildMenu();
            break;
            case "turretbtBuild2":
                if (player.getCurrency() > player.tourellesManager.tourellePrefab2.cost)
                {
                    BuildTurret(2);
                }
                closeBuildMenu();
            break;
            case "turretbtBuild3":
                if (player.getCurrency() > player.tourellesManager.tourellePrefab3.cost)
                {
                    BuildTurret(3);
                }
                closeBuildMenu();
            break;
            case "turretbtSell":
                tourelleSell();
                closeBuildMenu();
            break;
            case "turretbtReturn":
                closeBuildMenu();
            break;
        }
        
    }
}
