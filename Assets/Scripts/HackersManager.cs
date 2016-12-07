using UnityEngine;
using System.Collections;
using System;

public class HackersManager : MonoBehaviour {

    public TourellesManager tourellesManager;
    public Player player;
    public Ennemi ennemiPrefab;
    public Ennemi ennemiPrefab2;
    public GameObject shrinker;
    public HexGrid hexGrid;

    private float nextActionTime = 0.0f;
    private float period = 1.5f;

    public ArrayList coordinates = new ArrayList()
    {
        /*new Vector3(-4, 0, 4),  // Index 0 = Coordonnée de Spawn
        new Vector3(4, 0, 4),
        new Vector3(4, 0, -4),
        new Vector3(-4, 0, -4),
        new Vector3(-4, 0, 2),
        new Vector3(2, 0, 2)*/
    };

    public ArrayList ennemiList = new ArrayList();

	// Use this for initialization
	void Start () {

    }

    void Awake()
    {
         // Chemin en spirale
        addStart(64);
        addStep(65);
        addStep(66);
        addStep(67);
        addStep(68);
        addStep(69);
        addStep(70);
        addStep(62);
        addStep(53);
        addStep(44);
        addStep(35);
        addStep(26);
        addStep(17);
        addStep(16);
        addStep(15);
        addStep(14);
        addStep(13);
        addStep(12);
        addStep(11);
        addStep(1);
        addStep(0);
        addStep(9);
        addStep(18);
        addStep(28);
        addStep(36);
        addStep(45);
        addStep(45);
        addStep(46);
        addStep(47);
        addStep(48);
        addStep(49);
        addStep(50);
        addEnd(51);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // Instantiate the missile at the position and rotation of this object's transform
            if (UnityEngine.Random.Range(0, 2) > 0)
            {
                Ennemi clone = Instantiate(ennemiPrefab);
            }
            else
            {
                Ennemi clone = Instantiate(ennemiPrefab2);
                clone.disableRotation();
            }
        }
    }

    public void addStep(int _index)
    {
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        coordinates.Add(new Vector3(x, y, z));
        cell.setStep();
    }

    public void addStart(int _index)
    {
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        coordinates.Insert(0, new Vector3(x, y, z));
        cell.setStart();
    }

    public void addEnd(int _index)
    {
        HexCell cell = hexGrid.getCell(_index);
        float x = cell.transform.localPosition.x * 0.08f;
        float y = 0;
        float z = cell.transform.localPosition.z * 0.08f;
        coordinates.Add(new Vector3(x, y, z));
        cell.setStop();
    }

    public int countEnnemis()
    {
        return ennemiList.Count;
    }

    public void addEnnemi(Ennemi _ennemi)
    {
        ennemiList.Add(_ennemi);
    }

    public void removeEnnemi(Ennemi _ennemi)
    {
        ennemiList.Remove(_ennemi);
    }

    public Ennemi closestEnnemi(Vector3 _v3, Tourelle _t)
    {
        Ennemi closest = null;
        float bestDistance = 10000f;
        float candidateDistance;
        foreach (Ennemi ennemi in ennemiList)
        {
            candidateDistance = Vector3.Distance(_t.transform.position, ennemi.transform.position);
            if (bestDistance > candidateDistance)
            {
                bestDistance = candidateDistance;
                closest = ennemi;
            }
        }
        return closest;
    }

    public void damageEnnemi(Ennemi _ennemi, float _dmg)
    {
        _ennemi.takeDamage(_dmg);
    }
}
