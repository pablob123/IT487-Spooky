using UnityEngine;

public class Interactor : MonoBehaviour
{
   [SerializeField] private Transform _interactionPoint;
   [SerializeField] private float _interactionPointRadius = 0.5f;
   [SerializeField] private float _interactionDistance = 0.5f;
   [SerializeField] private LayerMask _interactableMask;

   [SerializeField] private Rigidbody2D _playerRigidbody;

   private readonly Collider2D[] _colliders = new Collider2D[3];
   [SerializeField] private int _numFoundColliders;

   private Vector2 _facingDirection = Vector2.down;

   private void Update()
   {
        _numFoundColliders = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFoundColliders <= 0)
            return;

        IInteractable interactable = _colliders[0].GetComponent<IInteractable>();

        if(interactable == null)
            return;

        if(Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact(this);
        }

        if(Input.GetKey(KeyCode.E) && !Input.GetKeyDown(KeyCode.E))
        {
            interactable.HoldInteract(this);
        }
   }

   public void SetFacingDirection(Vector2 direction)
   {
        if(direction != Vector2.zero)
        {
            _facingDirection = direction.normalized;
            _interactionPoint.localPosition = _facingDirection * _interactionDistance;
        }
   }

   public Vector2 GetFacingDirecton()
   {
        return _facingDirection;
   }

   public bool IsMoving()
   {
        return _playerRigidbody.linearVelocity.sqrMagnitude > 0.01f;
   }

   private void OnDrawGizmos()
   {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
   }
}
