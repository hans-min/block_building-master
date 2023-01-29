using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	public int width = 5;
	public int height = 10;
	public GridElement gridElementPrefab;

	public GridElement[] gridElements;
	//private float floorHeight = 0.25f, basementHeight;
	
	void Start () {
		instance = this;
		gridElements = new GridElement[width * width * height];

		for(int y = 0; y < height; y++) {
			for(int x = 0; x < width; x++) {
				for(int z = 0; z < width; z++) {
					GridElement gridElementInstance = Instantiate(gridElementPrefab, new Vector3(x,y,z), Quaternion.identity, transform);
					gridElementInstance.Initialize(x,y,z);
					gridElements[x+width*(z+width*y)] = gridElementInstance;
				}
			}
		}
	}
}
