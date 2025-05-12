using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locateCreature : MonoBehaviour
{
    public Sprite MyCreature;
    public Sprite sprite;
    public SpriteRenderer creature;
    string streamFolder;


    private void Awake(){

    }

    // Start is called before the first frame update
    void Start()
    {
        //MY CREATURE
        creature.sprite = MyCreature;
        //get from resource folder(does not stay/visable in build)
        //sprite = Resources.Load<Sprite>("creaturestill");

        //from streaming folder but it's unloaded
        //sprite = Application.streamingAssetsPath, "cat7";

/*
        // I don't know, get from streaming folder, unload image, then put as sprite.
        streamFolder = Directory.GetFiles(Application.streamingAssetsPath);
        bytes[] pngBytes = System.IO.File.ReadAllBytes(streamFolder);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height));
        sprite = fromTex;
        
*/

    }

    // Update is called once per frame
    void Update()
    {
        //creature.sprite = sprite;
        
    }

    void createFolder(){
        //Directory.CreateDirectory(Application.streamingAssetsPath + "/Test");
        /*
        if (!Directory.Exist(path)){
            Directory.CreateDirectory("player");
        }
        */
    }
}
