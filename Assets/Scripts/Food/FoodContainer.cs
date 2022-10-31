using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour
{
    [SerializeField] private Food _food;

    public Food food => _food;

    public List<Component> foodContainer = new List<Component>();

    private void Start()
    {
        Component[] foodPieces = GetComponentsInChildren<Renderer>();

        foreach (var piece in foodPieces)
        {
            foodContainer.Add(piece);
            print(piece.name);
        }
    }
}
