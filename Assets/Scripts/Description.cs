using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] private GameObject _descriptionText;

    private void Start()
    {
        _descriptionText.SetActive(false);
    }


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
