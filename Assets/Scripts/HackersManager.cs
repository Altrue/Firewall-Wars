using UnityEngine;
using System.Collections;
using System;

public class HackersManager : MonoBehaviour {

    public TourellesManager tourellesManager;
    public Ennemi ennemiPrefab;
    public GameObject shrinker;

    private float nextActionTime = 0.0f;
    private float period = 2f;

    public ArrayList coordinates = new ArrayList()
    {
        new Vector3(-4, 0, 4),  // Index 0 = Coordonnée de Spawn
        new Vector3(4, 0, 4),
        new Vector3(4, 0, -4),
        new Vector3(-4, 0, -4),
        new Vector3(-4, 0, 2),
        new Vector3(2, 0, 2)
    };

    public ArrayList ennemiList = new ArrayList();

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // Instantiate the missile at the position and rotation of this object's transform
            Ennemi clone = Instantiate(ennemiPrefab);
        }
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
