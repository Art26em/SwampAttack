public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (!Target)
        {
            NeedTransit = true;
        }
    }
}
