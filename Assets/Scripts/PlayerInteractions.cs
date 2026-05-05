using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float interactionDistance;
    public LayerMask interactableLayer;
    public Transform Eyes;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Eyes.position, Eyes.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
            {
                Debug.Log("Hit" + hit.transform.name);
                if (hit.collider.TryGetComponent<Item>(out Item item))
                {
                    item.Interact();
                }
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Eyes.position, Eyes.forward * interactionDistance);
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
