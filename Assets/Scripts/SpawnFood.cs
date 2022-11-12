using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] private GameObject _table;
    [SerializeField] private GameObject[] _tamplate;
    [SerializeField] protected Tank _tank;
    [SerializeField] protected ColorController _colorController;

    private void Start()
    {
        Spawn(_tamplate);
    }

    private void Spawn(GameObject[] tamplate)
    {        
        for (int i = 0; i < _tamplate.Length; i++)
        {
            Vector3 spawnPosition = _table.transform.position + GetRandomPos();
            Food[] food = Instantiate(tamplate[i], spawnPosition, tamplate[i].transform.rotation).GetComponentsInChildren<Food>();

            foreach (var foodPieces in food)
            {
                foodPieces.Init(_tank, _colorController);
            }
        }
    }
    
    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-10, 10), 0.1f, Random.Range(-10, 10));
    }    
}
