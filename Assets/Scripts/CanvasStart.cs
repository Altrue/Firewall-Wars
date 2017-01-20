using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasStart : MonoBehaviour
{

    public GameObject imageStart;
    public GameObject textStart;
    public Player player;

    private Image RTTextStart;
    private Image RTImageStart;
    private bool gameHasStarted;
    private float opacity;

    // Use this for initialization
    void Awake()
    {
        gameHasStarted = false;
        RTTextStart = textStart.GetComponent<Image>();
        RTImageStart = imageStart.GetComponent<Image>();

        // Set the scaling
        imageStart.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        textStart.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        // Set the color (and opacity)
        RTTextStart.color = new Color32(255, 255, 255, 255);
        RTImageStart.color = new Color32(255, 255, 255, 255);
    }

    void Update()
    {
        if (!gameHasStarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                startGame();
            }
            else
            {
                float time = Time.fixedTime * 3f;
                Color colorText = new Color32(255, 255, 255, 255);
                colorText.a = 0.5f + ((float)System.Math.Sin(time)) * 0.5f;
                RTTextStart.color = colorText;
            }
        }
    }

    public bool getHasStarted()
    {
        return gameHasStarted;
    }

    public void startGame()
    {
        gameHasStarted = true;
        player.gameHasStarted = true;
        player.stopInitialPause();
        RTTextStart.color = new Color32(255, 255, 255, 0);
        RTImageStart.color = new Color32(255, 255, 255, 0);
    }
}
