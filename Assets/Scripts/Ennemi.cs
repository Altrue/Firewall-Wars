using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ennemi : MonoBehaviour {

    private ArrayList coordinates = new ArrayList();
    public Hackers hackers;
    public int speed;
    public int rotateSpeed;
    public Text coordinatesCountText;
    public Text coordinatesTargetText;
    public Text coordinatesPosText;
    public GameObject Parent;

    private int pathPosition;
    private int coordinatesCount;
    private Vector3 nextTargetPosition;
    private bool hasWon;

	// Use this for initialization
	void Start () {
        hasWon = false;
        pathPosition = 0;
        coordinates = hackers.coordinates;
        coordinatesCount = coordinates.Count;
        coordinatesCountText.text = "CoordinatesCount : " + coordinatesCount.ToString();
        transform.localPosition = (Vector3) coordinates[pathPosition]; // Spawn à la première coordonnée
        transform.SetParent(Parent.transform);
        pathPosition++;

        setNextTargetPosition();
    }
	
	// Update is called once per frame
	void Update () {
        coordinatesTargetText.text = "Target: " + nextTargetPosition.x.ToString() + ", " + nextTargetPosition.y.ToString() + ", " + nextTargetPosition.z.ToString();
        coordinatesPosText.text = "POS: " + transform.localPosition.x.ToString() + ", " + transform.localPosition.y.ToString() + ", " + transform.localPosition.z.ToString();
        if (!hasWon) {
            transform.localPosition = movePosition();
            if (transform.localPosition.x == nextTargetPosition.x && transform.localPosition.z == nextTargetPosition.z)
            {
                setNextTargetPosition();
            }
        }
        else
        {
            Destroy(this);
        }
    }

    Vector3 movePosition()
    {
        float x;
        float z;
        float y;

        // X Coord
        if (transform.localPosition.x < nextTargetPosition.x)
        {
            x = System.Math.Min(transform.localPosition.x + speed * Time.deltaTime, nextTargetPosition.x);
        }
        else if (transform.localPosition.x > nextTargetPosition.x)
        {
            x = System.Math.Max(transform.localPosition.x - speed * Time.deltaTime, nextTargetPosition.x);
        }
        else
        {
            x = nextTargetPosition.x;
        }

        // Z Coord
        if (transform.localPosition.z < nextTargetPosition.z)
        {
            z = System.Math.Min(transform.localPosition.z + speed * Time.deltaTime, nextTargetPosition.z);
        }
        else if (transform.localPosition.z > nextTargetPosition.z)
        {
            z = System.Math.Max(transform.localPosition.z - speed * Time.deltaTime, nextTargetPosition.z);
        }
        else
        {
            z = nextTargetPosition.z;
        }

        // Y Coord
        float time = Time.fixedTime * 3f;
        y = ((float)System.Math.Sin(time) + 1f) * 0.1f ;

        setOrientation(x - transform.localPosition.x, z - transform.localPosition.z);

        return new Vector3(x, y, z);
    }
    
    void setOrientation(float _x, float _z)
    {
        if (_x != 0 || _z != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(_x, 0, _z)), Time.deltaTime * rotateSpeed);
        }
    }
    
    void setNextTargetPosition()
    {
        if (pathPosition >= coordinatesCount)
        {
            hasWon = true;
        }
        else
        {
            nextTargetPosition = (Vector3)coordinates[pathPosition];
            pathPosition++;
        }
    }
}
