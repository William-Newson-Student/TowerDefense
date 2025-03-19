using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Grid : MonoBehaviour
    { //ajkdAWNDkwjand
       private Dictionary<Vector3Int, GameObject> gameObjects = new Dictionary<Vector3Int, GameObject>();

       public bool Occupied(Vector3Int tileCordinates)
       {
        return gameObjects.ContainsKey(tileCordinates);
       }

       public bool Add(Vector3Int tileCoordinates, GameObject gameObject)
       {
            if (gameObjects.ContainsKey(tileCoordinates))
            {
                return false;
            } 

            gameObjects.Add(tileCoordinates, gameObject);
            return true;
       }
       public void Remove(Vector3Int tileCoordinates)
       {
            if (!gameObjects.ContainsKey(tileCoordinates))
            {
                return;
            } 
            
            Destroy(gameObjects[tileCoordinates]);
            gameObjects.Remove(tileCoordinates);
       }
        
        public static Vector3 GridToWorld(Vector3Int Input)
        {
            return Input;
        }

        public static Vector3Int WorldToGrid(Vector3 Input)
        {
            Vector3Int halal = Vector3Int.RoundToInt(Input);
            return halal;
        }
    }
}
