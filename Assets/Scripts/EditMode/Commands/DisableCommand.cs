using UnityEngine;

namespace EditMode.Commands
{
    public class DisableCommand : ICommand
    {
        private GameObject _target;

        public DisableCommand(GameObject target)
        {
            _target = target;
        }
        
        public void Apply()
        {
            _target.SetActive(false);
        }

        public void Rollback()
        {
            _target.SetActive(true);
        }
    }
}
