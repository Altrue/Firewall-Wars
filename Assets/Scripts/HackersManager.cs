using UnityEngine;
using System.Collections;

public class HackersManager : MonoBehaviour {

    public TourellesManager tourellesManager;

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
	    
	}

    public void addEnnemi(Ennemi _ennemi)
    {
        ennemiList.Add(_ennemi);
    }

    public Ennemi closestEnnemi(Vector3 _v3)
    {
        Ennemi closest = null;
        foreach (Ennemi ennemi in ennemiList)
        {
            if (true) // TODO : Loop and select closest
            {
                closest = ennemi;
            }
        }
        return closest;
    }
}
