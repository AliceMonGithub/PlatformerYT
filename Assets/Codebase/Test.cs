using Codebase.Services.InputLogic;
using System.Collections;
using UnityEngine;

namespace Assets.Codebase
{
    public class Test : MonoBehaviour
    {
        private MovementInput _input = new PCMovementInput();

        private void Update()
        {
            print(_input.Axis);
        }
    }
}