using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TourellesManager : MonoBehaviour {

    public HackersManager hackersManager;
    public Player player;
    public Tourelle tourellePrefab;
    public Tourelle tourellePrefab2;
    public Tourelle tourellePrefab3;
    public List<Tourelle> tourellesList = new List<Tourelle>();
    public List<HexCell> tourellesSlotList = new List<HexCell>();
    public HexGrid hexGrid;

    private bool isPaused;

    // Use this for initialization
    void Start () {
        hackersManager = FindObjectOfType<HackersManager>();

        addTourelleSlot(61);
        addTourelleSlot(25);
        addTourelleSlot(10);
        addTourelleSlot(37);
        addTourelleSlot(40);

        isPaused = false;

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addTourelle(Tourelle _t1)
    {
        tourellesList.Add(_t1);
    }

    public void addTourelleSlot(int _index)
    {
        HexCell cell = hexGrid.getCell(_index);
        cell.setTurretSlot();
        tourellesSlotList.Add(cell);
    }
    
    public void addTourelle1(int _index)
    {
        if (player.getCurrency() >= tourellePrefab.cost)
        {
            player.spendCurrency(tourellePrefab.cost);
            Tourelle t1 = Instantiate(tourellePrefab);
            HexCell cell = hexGrid.getCell(_index);
            float x = cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = cell.transform.localPosition.z * 0.08f;
            t1.setPosition(x, y, z);
            cell.setTurret(t1, 1);
            tourellesList.Add(t1);
        }
    }

    public void addTourelle1(HexCell _cell)
    {
        if (player.getCurrency() >= tourellePrefab.cost)
        {
            player.spendCurrency(tourellePrefab.cost);
            Tourelle t1 = Instantiate(tourellePrefab);
            float x = _cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = _cell.transform.localPosition.z * 0.08f;
            t1.setPosition(x, y, z);
            _cell.setTurret(t1, 1);
            tourellesList.Add(t1);
        }
    }

    public void addTourelle2(int _index)
    {
        if (player.getCurrency() >= tourellePrefab2.cost)
        {
            player.spendCurrency(tourellePrefab2.cost);
            Tourelle t2 = Instantiate(tourellePrefab2);
            HexCell cell = hexGrid.getCell(_index);
            float x = cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = cell.transform.localPosition.z * 0.08f;
            t2.setPosition(x, y, z);
            cell.setTurret(t2, 2);
            tourellesList.Add(t2);
        }
    }

    public void addTourelle2(HexCell _cell)
    {
        if (player.getCurrency() >= tourellePrefab2.cost)
        {
            player.spendCurrency(tourellePrefab.cost);
            Tourelle t2 = Instantiate(tourellePrefab2);
            float x = _cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = _cell.transform.localPosition.z * 0.08f;
            t2.setPosition(x, y, z);
            _cell.setTurret(t2, 2);
            tourellesList.Add(t2);
        }
    }

    public void addTourelle3(int _index)
    {
        if (player.getCurrency() >= tourellePrefab3.cost)
        {
            player.spendCurrency(tourellePrefab3.cost);
            Tourelle t3 = Instantiate(tourellePrefab3);
            HexCell cell = hexGrid.getCell(_index);
            float x = cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = cell.transform.localPosition.z * 0.08f;
            t3.setPosition(x, y, z);
            cell.setTurret(t3, 3);
            tourellesList.Add(t3);
        }
    }

    public void addTourelle3(HexCell _cell)
    {
        if (player.getCurrency() >= tourellePrefab3.cost)
        {
            player.spendCurrency(tourellePrefab3.cost);
            Tourelle t3 = Instantiate(tourellePrefab3);
            float x = _cell.transform.localPosition.x * 0.08f;
            float y = 0;
            float z = _cell.transform.localPosition.z * 0.08f;
            t3.setPosition(x, y, z);
            _cell.setTurret(t3, 3);
            tourellesList.Add(t3);
        }
    }

    public void startPause()
    {
        if (!isPaused)
        {
            isPaused = true;

            foreach (Tourelle _tourelle in tourellesList)
            {
                _tourelle.startPause();
            }
        }
    }

    public void stopPause()
    {
        if (isPaused)
        {
            isPaused = false;

            foreach (Tourelle _tourelle in tourellesList)
            {
                _tourelle.stopPause();
            }
        }
    }
}
