﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Sprite;
using UnityEngine.UI;
public class Mountain : MonoBehaviour
{
    public int id = 0;
    public Vector3 startPosition;
    /* Range Properties */
    public static int[] heightRange = new int[2] { 5, 8 };
    public static int[] widthRange = new int[2] { 6, 10 };
    public static int[] proximityRange = new int[2] { 0, 5 };

    /* Mountain Properties */
    public int actualHeight;
    public int actualWidth;
    public int actualProximity;

    public int topWidth;
    public int entryWidth;
    public int exitWidth;

    public bool topIsValley;

    public GameObject Entry;
    public GameObject Top;
    public GameObject Exit;

    public GameObject _Valley;

    /* Properties Setup */
    public Mountain()
    {
        actualHeight = IntUtil.Random(heightRange[0], heightRange[1]);
        actualWidth = IntUtil.Random(widthRange[0], widthRange[1]);
        actualProximity = IntUtil.Random(proximityRange[0], proximityRange[1]);


        topWidth = IntUtil.Random(1, actualWidth - 1);
        entryWidth = IntUtil.Random(1, actualWidth - topWidth);
        exitWidth = actualWidth - topWidth - entryWidth;

        Debug.Log("actualWidth: " + actualWidth);
        Debug.Log("topWidth: " + topWidth);
        Debug.Log("entryWidth: " + entryWidth);
        Debug.Log("exitWidth: " + exitWidth + "\n");

        if (topWidth > Valley.width[0])
        {
            topIsValley = true;
        }
        else
        {
            topIsValley = false;
        }
    }

    void Start()
    {
        AppController test = GameObject.FindGameObjectWithTag("Controller").GetComponent<AppController>();
        transform.position = startPosition;
        if (topIsValley)
        {
            if (this.Top != null)
            {
                // _Valley = ObjectGenerator.GenerateValley(this.Top, id, 0, Top.transform.position, topWidth);
                _Valley = ObjectGenerator.GenerateValley(this.Top, id, 0, Top.transform.position, topWidth, test.ValleyPrefab);
            }
        }

        // Debug.Log("actualWidth: " + actualWidth);
        // this.transform.position += new Vector3(0, 1, 0);
        this.transform.localScale = new Vector3(this.transform.localScale.x * actualWidth, this.transform.localScale.y, this.transform.localScale.z);


        // Debug.Log("entryWidth: " + entryWidth);
        // this.Entry.transform.position += new Vector3(0, 1.5f, 0);
        this.Entry.transform.localScale = new Vector3(this.Entry.transform.localScale.x * entryWidth, this.Entry.transform.localScale.y, this.Entry.transform.localScale.z);

        // Debug.Log("topWidth: " + topWidth);
        // this.Top.transform.position += new Vector3(0, 1.6f, 0);
        this.Top.transform.localScale = new Vector3(this.Top.transform.localScale.x * topWidth, this.Top.transform.localScale.y, this.Top.transform.localScale.z);
        if (Exit != null)
        {
            // Debug.Log("exitWidth: " + exitWidth);
            // this.Exit.transform.position += new Vector3(0, 1.5f, 0);
            this.Exit.transform.localScale = new Vector3(this.Exit.transform.localScale.x * exitWidth, this.Exit.transform.localScale.y, this.Exit.transform.localScale.z);
        }

    }

    private void OnDestroy()
    {
        if (Entry != null)
            Destroy(Entry);
        if (Top != null)
            Destroy(Top);
        if (Exit != null)
            Destroy(Exit);
    }


    public void Draw(){
        float end = (float)AppController.LastEnd;
        GameObject entryInst = Instantiate(AppController.EntryPrefab, new Vector3(end+(float)(entryWidth)/2.0f,0,0), Quaternion.Euler(0,0,0));
        entryInst.transform.localScale = new Vector3((float)entryWidth/AppController.spriteScale,1/AppController.spriteScale,1/AppController.spriteScale);
        end += this.entryWidth;
        GameObject topInst = Instantiate(AppController.TopPrefab, new Vector3(end+(float)(topWidth)/2.0f,0,0), Quaternion.Euler(0,0,0));
        topInst.transform.localScale = new Vector3((float)topWidth/AppController.spriteScale,1/AppController.spriteScale,1/AppController.spriteScale);
        end += this.topWidth;
        GameObject exitInst = Instantiate(AppController.ExitPrefab, new Vector3(end+(float)(exitWidth)/2.0f,0,0), Quaternion.Euler(0,0,0));
        exitInst.transform.localScale = new Vector3((float)exitWidth/AppController.spriteScale,1/AppController.spriteScale,1/AppController.spriteScale);
        end += this.exitWidth;

        AppController.LastEnd = (int)(end);
    }
}