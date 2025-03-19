using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefense
{
    public class Cursorer : MonoBehaviour
    {
        private float currentX;
        private float currentZ;
        Vector3Int GetTargetTile()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3Int targetTile;
                targetTile = Grid.WorldToGrid(hit.point + hit.normal * 0.5f);
                Cursor.visible = false;
                return targetTile;
            }
            Cursor.visible = true;
            return Vector3Int.one * 10;
        }

        void Update()
        {
            transform.position = GetTargetTile();

            currentX = transform.position.x;
            currentZ = transform.position.z;
            
            transform.position = new Vector3(currentX, 0, currentZ);        
        }
    }
}

