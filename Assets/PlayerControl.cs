using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public int speed = 10;
    public string spriteNameSuffix = "Pad";
    public string spriteColors;

    private Rigidbody2D rigidBody;
    private SpritePicker spritePicker;

    private class SpritePicker
    {
        private List<string> spriteColors;
        private int spriteIndex = 0;
        private string spriteNameSuffix;

        public SpritePicker(string spriteNameSuffix, string spriteColors)
        {
            this.spriteNameSuffix = spriteNameSuffix;
            this.spriteColors = spriteColors.Split(',').ToList();
        }

        public Sprite NextSprite()
        {
            spriteIndex = (spriteIndex + 1) % spriteColors.Count;
            return Resources.Load(spriteColors[spriteIndex] + spriteNameSuffix, typeof(Sprite)) as Sprite;
        }

        public string CurrentSpriteName()
        {
            return spriteColors[spriteIndex] + spriteNameSuffix;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spritePicker = new SpritePicker(spriteNameSuffix, spriteColors);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * (-speed) * Time.deltaTime;
            rigidBody.MovePosition(transform.position + tempVect);

        }
        else if (Input.GetKey(rightKey))
        {
            Vector3 tempVect = new Vector3(1, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rigidBody.MovePosition(transform.position + tempVect);

        }
        else
        {
            rigidBody.velocity.Set(0, 0);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(spritePicker.NextSprite());
        GetComponent<SpriteRenderer>().sprite = spritePicker.NextSprite();
        Debug.Log("Sprite name: " + spritePicker.CurrentSpriteName());
    }
}
