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

    private int currency;
    private float hp;
    private bool isPaused;

    // Use this for initialization 
    void Start()
    {
        isPaused = false;
        CanvasPause.SetActive(false);
        hp = maxHp;
        currency = startCurrency;
    }

    // Update is called once per frame 
    void Update()
    {
        if (hp <= 0)
        {
            GameOver();
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

    void GameOver()
    {
        //TODO: Game over 
    }

    void TakeDamage(float dmg)
    {
        hp -= dmg;
    }

    void addCurrency(int newCurrency)
    {
        currency += newCurrency;
    }

    void spendCurrency(int cost)
    {
        currency -= cost;
    }

    int getCurrency()
    {
        return currency;
    }

}