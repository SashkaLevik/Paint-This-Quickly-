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
            Food[] food = Instantiate(tamplate[i], _table.transform.position, _table.transform.rotation).GetComponentsInChildren<Food>();
            
            foreach (var foodPieces in food)
            {
                foodPieces.Init(_tank, _colorController);
            }
        }
    }
}
