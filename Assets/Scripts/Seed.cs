using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool isMergeFlag = false;
    public bool isDrop = false;
    public int seedNo;
    private float dropInterval = 3.0f;
    private float timeSinceLastDrop = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colobj = collision.gameObject;
        if (colobj.CompareTag("seed"))
        {
            seed colseed = collision.gameObject.GetComponent<seed>();
            if (seedNo == colseed.seedNo &&
                !isMergeFlag &&
                !colseed.isMergeFlag &&
                seedNo < GameManager.Instance.MaxSeedNo - 1)
            {
                isMergeFlag = true;
                colseed.isMergeFlag = true;
                GameManager.Instance.MergeNext(transform.position, seedNo);
                Destroy(gameObject);
                Destroy(colseed.gameObject);
            }
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeSinceLastDrop += Time.deltaTime;

        if (timeSinceLastDrop >= dropInterval && isDrop == false)
        {
            Drop();
            timeSinceLastDrop = 0.0f;
        }

        if (isDrop) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = Mathf.Clamp(mousePos.x, -1f, 1f);
        mousePos.y = 3.5f;

        transform.position = mousePos;
    }

    private void Drop()
    {
        isDrop = true;
        _rb.simulated = true;
        GameManager.Instance.isNext = true;
    }
}