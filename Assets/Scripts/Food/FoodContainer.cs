using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour
{
    [SerializeField] private FoodPiece _food;

    public FoodPiece food => _food;

    public List<Component> Container = new List<Component>();

    private void Start()
    {
        Component[] foodPieces = GetComponentsInChildren<Renderer>();

        foreach (var piece in foodPieces)
        {
            Container.Add(piece);
            print(piece.name);
        }
    }
}
