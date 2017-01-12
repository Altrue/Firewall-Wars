using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public bool showCoordinates;

	public int width;
	public int height;

    public static Color defaultColor = new Color(0.05f, 0.05f, 0.05f);
    public static Color touchedColor = new Color(0.1f, 0.1f, 0.1f);
    public static Color turretColor = new Color(0, 0, 0);
    public static Color startColor = new Color(0.05f, 0.7f, 0.1f);
    public static Color stopColor = new Color(0.8f, 0.0f, 0.0f);

    public HexCell cellPrefab;
	public Text cellLabelPrefab;

	HexCell[] cells;

	Canvas gridCanvas;
	HexMesh hexMesh;

	void Awake () {
		gridCanvas = GetComponentInChildren<Canvas>();
		hexMesh = GetComponentInChildren<HexMesh>();

		cells = new HexCell[height * width];

		for (int z = -4, i = 0; z < 5; z++) {
			for (int x = -4; x < 5; x++) {
				CreateCell(x, z, i++);
			}
		}
	}

	void Start () {
		hexMesh.Triangulate(cells);
	}
    /*
	void Update () {
		if (Input.GetMouseButton(0)) {
			HandleInput();
		}
	}
    */
    public HexCell getCell(int index)
    {
        return cells[index];
    }
    // On a plus besoin de ça vu qu'on génère le chemin tout seul.
    // Mais s'il faut interragir avec le terrain on peut remttre ce code
    /*
	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point);
		}
	}

	void TouchCell (Vector3 position) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        int index = (coordinates.X + coordinates.Z * width + coordinates.Z / 2) + 40;
        HexCell cell = cells[index];
		cell.color = touchedColor;
		hexMesh.Triangulate(cells);
	}
    */

    public void changeCellColor(HexCoordinates coordinates, Color32 pColor)
    {
        int index = (coordinates.X + coordinates.Z * width + coordinates.Z / 2) + 40;
        HexCell cell = cells[index];
        cell.color = pColor;
        hexMesh.Triangulate(cells);
    }

	void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
		cell.color = defaultColor;
        
        if (showCoordinates)
        {
            Text label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition = new Vector2(position.x + 4.5f, position.z - 4.5f);
            //label.text = cell.coordinates.ToStringOnSeparateLines();
            //label.text = cell.transform.localPosition.x.ToString() + "\n" + cell.transform.localPosition.z.ToString();
            //label.text = i.ToString();
        }
    }
}