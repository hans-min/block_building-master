using UnityEngine;

public class CursorMovement : MonoBehaviour {
	RaycastHit hit;
	Ray ray;

	private GridElement lastHit;
	// Update is called once per frame
	void Update () {
		ray = Camera.main!.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit) && hit.collider.tag == "gridElement")
		{
			transform.position = hit.collider.transform.position;
			lastHit = hit.collider.gameObject.GetComponent<GridElement>();
			
			if (Input.GetMouseButtonDown(1)) {
				SetCursorButton(0);
			}
		}
	}

	public void SetCursorButton(int input) {
		Coord coord = lastHit.coord;
		print(coord.x + "-" + coord.y + "-" + coord.z);
		LevelGenerator generator = LevelGenerator.instance;
		int width = generator.width;
		int height = generator.height;
		switch (input) {
			case 0:
				//remove grid element
				if (coord.y > 0) {
					lastHit.SetDisabled();
				}
				break;
			case 1:
				//add X+
				if (coord.x < width - 1) {
					generator.gridElements[coord.x + width * (coord.z + width * coord.y)+1].SetEnabled();
				}
				break;
			case 2:
				if (coord.x >0) {
					generator.gridElements[coord.x + width * (coord.z + width * coord.y)-1].SetEnabled();
				}
				break;
			case 3:
				//add Z+
				if (coord.z < width - 1) {
					generator.gridElements[coord.x + width * (coord.z + 1 + width * coord.y)].SetEnabled();
				}
				break;
			case 4:
				//add Z-
				if (coord.z > 0) {
					generator.gridElements[coord.x + width * (coord.z - 1 + width * coord.y)].SetEnabled();
				}
				break;
			case 5:
				//add Y+
				if (coord.y < height - 1) {
					generator.gridElements[coord.x + width * (coord.z + width * (coord.y + 1))].SetEnabled();
				}
				break;
		}
	}
}