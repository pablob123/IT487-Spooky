using UnityEngine;

public class Interactor : MonoBehaviour
{
   [SerializeField] private Transform _interactionPoint;
   [SerializeField] private float _interactionPointRadius = 0.5f;
   [SerializeField] private float _interactionDistance = 0.5f;
   [SerializeField] private LayerMask _interactableMask;

   private readonly Collider2D[] _colliders = new Collider2D[3];
   [SerializeField] private int _numFoundColliders;

   private Vector2 _facingDirection = Vector2.down;

   private void Update()
   {
        _numFoundColliders = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
   }

   public void SetFacingDirection(Vector2 direction)
   {
        if(direction != Vector2.zero)
        {
            _facingDirection = direction.normalized;
            _interactionPoint.localPosition = _facingDirection * _interactionDistance;
        }
   }

   private void OnDrawGizmos()
   {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
   }
}
