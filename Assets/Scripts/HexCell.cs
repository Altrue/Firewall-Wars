using UnityEngine;

public class HexCell : MonoBehaviour {
    public HexCoordinates coordinates;
    public Color color;
    public bool isFilled;
    public Light lightStart;
    public Light lightEnd;

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

    public void setTurret()
    {
        color = HexGrid.turretColor;
        isFilled = true;
    }
}