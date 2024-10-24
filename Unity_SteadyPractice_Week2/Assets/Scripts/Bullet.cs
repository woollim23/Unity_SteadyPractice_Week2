using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if(this.transform.position.y > 5)
        {
            Destroy(this.gameObject);
        }
        this.transform.Translate(Vector2.up * this.speed * Time.deltaTime);
    }
}
