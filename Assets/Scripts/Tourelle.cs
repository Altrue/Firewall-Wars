using UnityEngine;
using System.Collections;

public class Tourelle : MonoBehaviour {

    TourellesManager tourellesManager;
    LineRenderer line;
    Ennemi closest;
    float distanceClosest;
    private float attackRange;

    public Light lightTourelle;

    // Use this for initialization
    void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        attackRange = 1.5f;

        tourellesManager = FindObjectOfType<TourellesManager>();
        tourellesManager.addTourelle(this);

        line.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        closest = tourellesManager.hackersManager.closestEnnemi(transform.position);
        distanceClosest = Vector3.Distance(closest.transform.position, transform.position);
        if (distanceClosest < attackRange)
        {
            line.enabled = true;

            var heading = closest.transform.position - lightTourelle.transform.position;
            Ray ray = new Ray(lightTourelle.transform.position, heading);

            line.SetPosition(0, ray.origin);
            line.SetPosition(1, ray.GetPoint(distanceClosest));
        }
        else
        {
            line.enabled = false;
        }
	}


}
