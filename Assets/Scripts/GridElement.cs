using UnityEngine;

public class Coord {
    public int x, y, z;

    public Coord(int setX, int setY, int setZ) {
        x = setX;
        y = setY;
        z = setZ;
    }
}

public class GridElement : MonoBehaviour {
    public Coord coord;
    private Collider _collider;
    private Renderer _renderer;

    public void Initialize(int setX, int setY, int setZ) {
        coord = new Coord(setX, setY, setZ);
        this.name = "GE_" + this.coord.x + "-" + this.coord.y + "-" + this.coord.z;
        this._collider = GetComponent<Collider>();
        this._renderer = GetComponent<Renderer>();
    }

    public Coord GetCoord() {
        return coord;
    }

    public void SetEnabled() {
        _collider.enabled = true;
        _renderer.enabled = true;
    }

    public void SetDisabled() {
        _collider.enabled = false;
        _renderer.enabled = false;
    }
}