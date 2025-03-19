using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        public GameObject towerPrefab;
        public int gold;

        private Grid grid;
        private Cursorer cursor;

        private void Awake()
        {
            grid = FindFirstObjectByType<Grid>();
            cursor = GetComponentInChildren<Cursorer>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryPlaceTower(grid, Grid.WorldToGrid(cursor.transform.position));
            }
        }
        public bool TryPlaceTower(Grid grid, Vector3Int tileCordinates)
        {
            if (gold < Tower_SO.GetCost(towerPrefab)) return false;
            if (grid.Occupied(tileCordinates)) return false;
            
            GameObject newTower = Instantiate(towerPrefab, tileCordinates + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
            grid.Add(tileCordinates, newTower);
            gold -= Tower_SO.GetCost(towerPrefab);

            return true;
        }
    }
}

