using UnityEngine;

namespace Codebase.Services.InputLogic
{
    public class PCMovementInput : MovementInput
    {
        public override Vector2 Axis => GetKeyboardAxis();

        private Vector2 GetKeyboardAxis()
        {
            return new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));
        }
    }
}