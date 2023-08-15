using CobaltRoleplay.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CobaltRoleplay.Controllers
{

    public class BackgroundController : MonoBehaviour
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

        public void SetBackGround(GridImage backgroundModel)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            }

            byte[] imageData = backgroundModel.SourceImage;

            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());

            spriteRenderer.sprite = sprite;

            float widthScaleFactor = backgroundModel.Width / sprite.bounds.size.x;
            float heightScaleFactor = backgroundModel.Height / sprite.bounds.size.y;

            gameObject.transform.localScale = new Vector2(widthScaleFactor, heightScaleFactor);
            gameObject.transform.position = new Vector2(backgroundModel.XPosition, backgroundModel.YPosition);


            spriteRenderer.enabled = true;
        }
    }

}