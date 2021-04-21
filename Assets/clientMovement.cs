using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gamingCloud.Network;

public class clientMovement : MonoBehaviour
{
    NetworkMovment net;
    Animator animator;

    public float x;
    void Start()
    {
        net = GetComponent<NetworkMovment>();
        animator = GetComponent<Animator>();
    }
    public void changeTurn()
    {
        Debug.Log("get");
        this.transform.position = new Vector3(this.transform.position.x * -1, this.transform.position.y, this.transform.position.z);
    }
    public void changeSpcae(bool status)
    {

        animator.SetBool("jumping", status);
        Debug.Log("jump");
        StartCoroutine(setFalse());
    }
    IEnumerator setFalse()
    {
        yield return new WaitForSeconds(1.2f);
        changeSpcae(false);
    }
    void Update()
    {
        x = this.transform.position.x;
        // animator.SetBool("jumping", true);
        animator.SetFloat("xvel", net.isMoving ? 1 : 0);
    }
    public Sprite aout;
    private void OnCollisionEnter2D(Collision2D other)
    {
        RectCollider rect = other.gameObject.GetComponent<RectCollider>();
        if (rect != null)
        {

            if (rect.blockType == BlockType.breakable)
                Destroy(other.gameObject);
            if (rect.blockType == BlockType.coinblock)
            {
                other.gameObject.GetComponent<SpriteRenderer>().sprite = aout;
            }
        }
    }
}
