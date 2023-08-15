using CobaltRoleplay.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CobaltRoleplay.Controllers
{
    public class TokenController : MonoBehaviour
    {

        SpriteRenderer spriteRenderer;


        // Start is called before the first frame update
        void Start()
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetToken(Token token)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }


        }
    }

}