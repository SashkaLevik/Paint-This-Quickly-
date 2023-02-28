using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSelection : MonoBehaviour
{
    [SerializeField] private YandexInitialization _yandexInitialization;
    [SerializeField] private Player _player;
    [SerializeField] private Button _joystick;
    [SerializeField] private Button _keyboard;

    private void ChooseController()
    {
        //if (Agava.YandexGames.Device.Type == Agava.YandexGames.DeviceType.Desktop)
        //    _keyboard.SetActive(true);
        //else
        //    _touch.SetActive(true);
    }
}
