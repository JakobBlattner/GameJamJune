using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallDamageController : MonoBehaviour
{
    public GameObject DamagedWallPrefab;
	// Use this for initialization
	void Start ()
	{
	}

    public void Spawn()
    {
    }

    void FixedUpdate()
    {
    }

    private GameObject CreateNewDamaged()
    {
        var tilemap = GameObject.Find("Tilemap");
        var pos = GetRandomSpawnPosition(tilemap);
        var quaternion = Quaternion.identity;
        return Instantiate(DamagedWallPrefab, pos, quaternion);
    }


    public void ApplyDamage(float i)
    {
        var damageStorage = GetCurrentOrCreateDamageStorage();
        damageStorage.ApplyDamage(i);
    }

    public DamageStorage GetCurrentOrCreateDamageStorage()
    {
        foreach (var o in Damaged)
        {
            var damageStorage = o.GetComponent<DamageStorage>();
            if (damageStorage.CurrentDamage < 100)
                return damageStorage;
        }

        var newDamaged = CreateNewDamaged();
        Damaged.Add(newDamaged);

        return newDamaged.GetComponent<DamageStorage>();
    }

    List<GameObject> Damaged = new List<GameObject>();

    private Vector3 GetRandomSpawnPosition(GameObject go)
    {
        Tilemap tilemap = go.GetComponent<Tilemap>();
        var randomTilemapCell = GetRandomFloor(tilemap);

        var a = tilemap.CellToWorld(randomTilemapCell);
        var b = tilemap.CellToWorld(randomTilemapCell - new Vector3Int(-1, 1, 0));
        var findWallTile = (a + b) / 2;

        return findWallTile;
    }

    private static TileBase GetTile(TileBase[] allTiles, int x, int y, BoundsInt bounds)
    {
        var index0 = x + y * bounds.size.x;
        if (allTiles.Length <= index0 || index0 < 0)
            return null;
        return allTiles[index0];
    }

    private static Vector3Int GetRandomFloor(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        var walls = new List<Vector3Int>();
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = GetTile(allTiles, x, y, bounds);
                if (tile != null)
                {
                    var wall = new Vector3Int(x, y+1, 0);
                    walls.Add(wall + bounds.position);
                }
            }
        }

        var random = new System.Random();
        var randomTilemapCell = walls[random.Next(walls.Count)];
        return randomTilemapCell;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RemoveRepairedTiles()
    {
        var repaired = new List<GameObject>();
        foreach (var o in Damaged)
        {
            var damageStorage = o.GetComponent<DamageStorage>();
            if (damageStorage.CurrentDamage <= 0)
                repaired.Add(o);
        }

        foreach (var o in repaired)
        {
            Damaged.Remove(o);
            Destroy(o);
        }
    }
}
