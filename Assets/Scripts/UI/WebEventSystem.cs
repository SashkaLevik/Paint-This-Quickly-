
using UnityEngine.EventSystems;

public class WebEventSystem : EventSystem
{
    protected override void OnApplicationFocus(bool focus) => base.OnApplicationFocus(true);
}
