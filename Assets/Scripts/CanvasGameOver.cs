using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasGameOver : MonoBehaviour {

    public GameObject imageGameOver;
    public GameObject textGameOver;
    public Text scoreText;
    public Player player;
    public float delayBeforeAnimation;

    private float animationDuration;
    private float animationDuration2;
    private Image RTTextGameOver;
    private Image RTImageGameOver;
    private bool noticedGameOver;
    private float startActionTime;
    private float nextActionTime;
    private float nextActionTime2;
    private float endActionTime;
    private float BsodGreenBlue;
    private float BsodRed;
    private bool reachedEndScreen = false;


    // Use this for initialization
    void Awake()
    {
        noticedGameOver = false;
        animationDuration = 4f;
        animationDuration2 = 2f;
        BsodGreenBlue = 1f;
        BsodRed = 1f;
        RTTextGameOver = textGameOver.GetComponent<Image>();
        RTImageGameOver = imageGameOver.GetComponent<Image>();
        scoreText.text = "";

        // Set the scaling
        imageGameOver.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        textGameOver.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

        // Set the color (and opacity)
        RTTextGameOver.color = new Color32(255, 255, 255, 0);
        RTImageGameOver.color = new Color32(255, 255, 255, 0);
    }

    void Update()
    {
        if (player.getGameOver() && !noticedGameOver)
        {
            noticedGameOver = true;
            startActionTime = Time.time + 1f;
            nextActionTime = Time.time + delayBeforeAnimation + 1f;
            nextActionTime2 = Time.time + delayBeforeAnimation + animationDuration + 1f;
            endActionTime = Time.time + delayBeforeAnimation + animationDuration2 + animationDuration + 1f;
        }

        if (player.getGameOver() && (Time.time > endActionTime))
        {
            // After animation
            if (!reachedEndScreen)
            {
                reachedEndScreen = true;
                Color colorTemp = new Color32(0, 0, 0, 255);
                RTImageGameOver.color = colorTemp;
                Color colorTemp2 = new Color32(255, 255, 255, 255);
                RTTextGameOver.color = colorTemp2;
                scoreText.text = "Score : " + player.getCurrency() + " ¤";
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Application.Quit();
            }
        }
        else if (player.getGameOver() && (Time.time > nextActionTime2))
        {
            // During secondary Animation
            BsodRed = BsodRed - (animationDuration * Time.deltaTime * 0.15f);
            if (BsodRed < 0f)
            {
                BsodRed = 0f;
            }
            Color colorBSOD = new Color32(255, 0, 0, 255);
            colorBSOD.r = BsodRed;
            RTImageGameOver.color = colorBSOD;
        }
        else if (player.getGameOver() && (Time.time > nextActionTime))
        {
            // During animation
            BsodGreenBlue = BsodGreenBlue - (animationDuration * Time.deltaTime * 0.07f);
            if (BsodGreenBlue < 0f)
            {
                BsodGreenBlue = 0f;
            }
            Color colorBSOD = new Color32(255, 255, 255, 255);
            colorBSOD.g = BsodGreenBlue;
            colorBSOD.b = BsodGreenBlue;
            RTImageGameOver.color = colorBSOD;
        }
        else if (player.getGameOver() && (Time.time > startActionTime))
        {
            RTImageGameOver.color = new Color32(255, 255, 255, 255);
        }
    }
}
