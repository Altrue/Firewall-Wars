using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float maxHp;
    public int startCurrency;
    public HackersManager hackersManager;
    public TourellesManager tourellesManager;
    public GameObject CanvasPause;
    public GameObject CanvasUI;
    public GameObject CanvasGameOver;
    public CanvasStart CanvasStart;
    public GameObject shrinker;
    public CanvasUI CanvasUIData;

    private int currency;
    private float hp;
    public bool isPaused;
    public bool isGameOver;
    public bool gameHasStarted;
    public bool isReadyToStart;
    //private float nextActionTime; // DEBUG!

    // Use this for initialization 
    void Start()
    {
        isPaused = false;
        isGameOver = false;
        gameHasStarted = false;
        isReadyToStart = false;
        hp = maxHp;
        currency = startCurrency;

        CanvasPause.SetActive(false);
        CanvasUI.SetActive(false);
        hackersManager.startPause();
        tourellesManager.startPause();
        shrinker.SetActive(false);
        isPaused = true;
    }

    // Update is called once per frame 
    void Update()
    {
        if (hp <= 0)
        {
            gameOver();
        }
        else
        {
            // Nothing to do yet
        }

        // DEBUG !
        /*
        if (isPaused && Time.time > nextActionTime)
        {
            stopPause();
        }*/
    }

    // Pause the game
    public void startPause()
    {
        if (!isPaused)
        {
            CanvasPause.SetActive(true);
            CanvasUI.SetActive(false);
            hackersManager.startPause();
            tourellesManager.startPause();
            shrinker.SetActive(false);
            isPaused = true;
            //nextActionTime = Time.time + 3f; // DEBUG !
        }
    }

    // star the game
    public void stopInitialPause()
    {
        CanvasUI.SetActive(true);
        shrinker.SetActive(true);
        if (isReadyToStart)
        {
            CanvasPause.SetActive(false);
            stopPause();
        }
        else
        {
            CanvasPause.SetActive(true);
        }
    }

    // Resume the game
    public void stopPause()
    {
        CanvasPause.SetActive(false);
        CanvasUI.SetActive(true);
        hackersManager.stopPause();
        tourellesManager.stopPause();
        shrinker.SetActive(true);
        isPaused = false;
    }

    public void gameOver()
    {
        hackersManager.startPause();
        tourellesManager.startPause();
        CanvasUI.SetActive(false);
        CanvasGameOver.SetActive(true);
        isGameOver = true;
    }

    public bool getGameOver()
    {
        return isGameOver;
    }

    public void takeDamage(float dmg)
    {
        hp -= dmg;
        if (hp < 0)
        {
            hp = 0;
            gameOver();
        }
    }

    public float getHP()
    {
        return hp;
    }

    public float getMaxHp()
    {
        return maxHp;
    }

    public void addCurrency(int newCurrency)
    {
        currency += newCurrency;
        CanvasUIData.animateCurrencyChange(newCurrency);
    }

    public void spendCurrency(int cost)
    {
        currency -= cost;
        CanvasUIData.animateCurrencyChange(cost * -1);
    }

    public int getCurrency()
    {
        return currency;
    }

}