using UnityEngine;
using System.Collections;

public class TourellesManager : MonoBehaviour {

    public HackersManager hackersManager;
    public Tourelle tourellePrefab;
    public Tourelle tourellePrefab2;
    public Tourelle tourellePrefab3;
    public ArrayList tourellesList = new ArrayList();

    // Use this for initialization
    void Start () {
        hackersManager = FindObjectOfType<HackersManager>();
        Tourelle t2 = Instantiate(tourellePrefab2);
        t2.setPosition(2, 0, 0);

        Tourelle t3 = Instantiate(tourellePrefab3);
        t3.setPosition(-2, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addTourelle(Tourelle _t1)
    {
        tourellesList.Add(_t1);
    }
}
