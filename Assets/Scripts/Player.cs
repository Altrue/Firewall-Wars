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

    private int currency;
    private float hp;
    private bool isPaused;
    private bool isGameOver;

    // Use this for initialization 
    void Start()
    {
        isPaused = false;
        isGameOver = false;
        CanvasPause.SetActive(false);
        CanvasGameOver.SetActive(false);
        hp = maxHp;
        currency = startCurrency;
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

        }
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
            isPaused = true;
        }
    }

    // Resume the game
    public void stopPause()
    {
        if (isPaused)
        {
            CanvasPause.SetActive(false);
            CanvasUI.SetActive(true);
            hackersManager.stopPause();
            tourellesManager.stopPause();
            isPaused = false;
        }
    }

    public void gameOver()
    {
        //TODO: Game over 
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
    }

    public void spendCurrency(int cost)
    {
        currency -= cost;
    }

    public int getCurrency()
    {
        return currency;
    }

}