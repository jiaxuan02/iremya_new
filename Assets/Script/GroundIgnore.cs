using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundIgnore : MonoBehaviour
{
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (m_CrouchDisableCollider != null)
                m_CrouchDisableCollider.enabled = false;
            m_CrouchDisableCollider.enabled = true;
        }
    }
}
