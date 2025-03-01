
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2f;
    public KeyCode interactKey = KeyCode.E;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(player.position, interactionRange);
            foreach (var hitCollider in hitColliders)
            {
                DialogueTrigger dialogueTrigger = hitCollider.GetComponent<DialogueTrigger>();
                if (dialogueTrigger != null)
                {
                    dialogueTrigger.TriggerDialogue();
                    break;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (player == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position, interactionRange);
    }
}