using UnityEngine;

public class TestElementOne : ElementBase
{
    [SerializeField] private Animator _animatorUniqueFeature;
    
    public override void EnableUniqueFeature(bool activate)
    {
        _animatorUniqueFeature.Play(activate ? "On" : "Off");
    }
}