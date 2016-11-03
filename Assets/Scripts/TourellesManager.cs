﻿using UnityEngine;
using System.Collections;

public class TourellesManager : MonoBehaviour {

    public HackersManager hackersManager;
    public Tourelle tourellePrefab;
    public Tourelle tourellePrefab2;
    public Tourelle tourellePrefab3;
    public ArrayList tourellesList = new ArrayList();
    public HexGrid hexGrid;

    // Use this for initialization
    void Start () {
        hackersManager = FindObjectOfType<HackersManager>();
        
        addTourelle1(40);
        addTourelle2(42);
        addTourelle3(38);
        
        /*Tourelle t2 = Instantiate(tourellePrefab2);
        t2.setPosition(2, 0, 0);

        Tourelle t3 = Instantiate(tourellePrefab3);
        t3.setPosition(-2, 0, 0);*/

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addTourelle(Tourelle _t1)
    {
        tourellesList.Add(_t1);
    }
    
    public void addTourelle1(int _index)
    {
        Tourelle t1 = Instantiate(tourellePrefab);
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        t1.setPosition(x, y, z);
        cell.setTurret();
        tourellesList.Add(t1);
    }

    public void addTourelle2(int _index)
    {
        Tourelle t2 = Instantiate(tourellePrefab2);
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        t2.setPosition(x, y, z);
        cell.setTurret();
        tourellesList.Add(t2);
    }

    public void addTourelle3(int _index)
    {
        Tourelle t3 = Instantiate(tourellePrefab3);
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        t3.setPosition(x, y, z);
        cell.setTurret();
        tourellesList.Add(t3);
    }
}
