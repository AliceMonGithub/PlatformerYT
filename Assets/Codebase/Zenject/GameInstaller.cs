using Codebase.Services.InputLogic;

namespace Zenject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MovementInput input = new PCMovementInput();

            InputSystem inputSystem = new InputSystem(input);

            Container.Bind<InputSystem>().FromInstance(inputSystem);
        }
    }
}