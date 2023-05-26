using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Dash : MonoBehaviour
{
    private bool onDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCd = 1f;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && onDash)
        {
            StartCoroutine(Dashs());
        }
    }

     private IEnumerator Dashs()
    {
        onDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCd);
        onDash = true;
    }

    void FixedUpdate(){

        if (isDashing)
        {
            return;
        }
    }

}
    

    

 
