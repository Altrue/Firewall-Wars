using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float maxHp;
    public int startCurrency;

    private int currency;
    private float hp;

    // Use this for initialization 
    void Start()
    {

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