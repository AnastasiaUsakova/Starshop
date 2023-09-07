using UnityEngine;

namespace Player
{
    public class PlayerAnimationController: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStyleSetupHelper styleHelper;

        private bool _isMoving;
        private static readonly int IsPlayerMoving = Animator.StringToHash("isMoving");
        
        public bool IsMoving {
            set
            {
                _isMoving = value;
                animator.SetBool(IsPlayerMoving, _isMoving);
                styleHelper.SwitchAnimationFlag(_isMoving);
            }
        }
    }
}