using UnityEngine;

namespace Codebase.Services.InputLogic
{
    public class InputSystem
    {
        private readonly MovementInput _input;

        public InputSystem(MovementInput input)
        {
            _input = input;
        }

        public Vector2 Axis => _input.Axis;
        public bool JumpButtonDown => Input.GetButtonDown("Jump");
    }
}