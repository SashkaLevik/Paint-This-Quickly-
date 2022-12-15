using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : Tube
{
    public override void OnTankApproached()
    {
        _view.DrainTank(_tubeColor, _tank.EmtyTank);
    }
}
