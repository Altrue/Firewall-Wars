﻿using UnityEngine;

public class HexCell : MonoBehaviour {
    public HexCoordinates coordinates;
    public Color color;
    public bool isFilled;
    public bool isTourelleSlot = false;
    public Light lightStart;
    public Light lightEnd;
    public int tourelleType = 0;
    public Tourelle tourelleInstance;

    public void setStep()
    {
        color = HexGrid.touchedColor;
        isFilled = true;
    }

    public void setStart()
    {
        color = HexGrid.startColor;
        isFilled = true;
        Light light = Instantiate(lightStart);
        light.transform.SetParent(gameObject.transform);
        light.transform.localPosition = new Vector3(0, 1, 0);
    }

    public void setStop()
    {
        color = HexGrid.stopColor;
        isFilled = true;
        Light light = Instantiate(lightEnd);
        light.transform.SetParent(gameObject.transform);
        light.transform.localPosition = new Vector3(0, 1, 0);
    }

    public void setTurretSlot()
    {
        color = HexGrid.turretColor;
        isFilled = false;
        isTourelleSlot = true;
    }

    public void unsetTurret()
    {
        isFilled = false;
        tourelleType = 0;
        tourelleInstance = null;
    }

    public void setTurret(Tourelle tInstance, int tType)
    {
        if (isTourelleSlot)
        {
            isFilled = true;
            tourelleType = tType;
            tourelleInstance = tInstance;
        }
        else
        {
            Debug.Log("ERREUR : Pas d'emplacement à l'endroit où la tourelle souhaite être placée");
        }
    }
}