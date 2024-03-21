using UnityEngine;

public class TestElementTwo : ElementBase
{
    [SerializeField] private Animator _animatorUniqueFeature;
    
    public override void EnableUniqueFeature(bool activate)
    {
        //TODO: Вданном случае я сделал по аналогии с первым элементом, но подразумивается, что у каждого здесь своя реализация.
        _animatorUniqueFeature.Play(activate ? "On" : "Off");
    }
}