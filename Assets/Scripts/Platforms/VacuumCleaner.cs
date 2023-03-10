public class VacuumCleaner : Tube
{
    
    public override void OnTankApproached()
    {
        _view.DrainTank(_tubeColor, _tank.EmtyTank);
        _pistol.Drain(_tubeColor);
    }
}
