using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NHBReader stream;
        Debug.Log("Start reading level file!");
	    try
        {
            stream = new NHBReader("Assets\\levels\\level1.txt");
        }
        catch (Exception)
        {
            Debug.LogError("IOErr: can't open file!");
            return;
        }
        int field_w = stream.getNextUInt(), field_h = stream.getNextUInt(), field_maxpl = stream.getNextUInt();
        Debug.Log("field_w: " + field_w.ToString());
        Debug.Log("field_h: " + field_h.ToString());
        Debug.Log("field_maxpl: " + field_maxpl.ToString());
        float wall_sz = GameObject.Find("simplewall").GetComponent<SpriteRenderer>().bounds.size.x;
        for (int i = 0; i < field_h; i++)
            for (int j = 0; j < field_w; j++)
            {
                int ch = stream.getNextChar();
                if (ch == '*')
                {
                    GameObject new_wall = Instantiate(GameObject.Find("simplewall"));
                    new_wall.transform.position = new Vector3(wall_sz * j, wall_sz * i, -2);
                }
            }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class NHBReader : StreamReader
{

    public NHBReader(string path) : base(path)
    {
        //Need this empty constructor!!!
    }

    private bool isSpaceNext()
    {
        return Peek() == 32 || Peek() == 13 || Peek() == 10 || Peek() == 9;
    }

    private void skipSpaces()
    {
        while (!EndOfStream && isSpaceNext())
            Read();
    }

    public int getNextUInt()
    {
        skipSpaces();
        int res = 0;
        while (Peek() >= '0' && Peek() <= '9')
            res = res * 10 + Read() - '0';
        if (!EndOfStream && !isSpaceNext())
            throw new IOException("Incorrect input format!");
        return res;
    }
    public int getNextChar()
    {
        skipSpaces();
        if (EndOfStream)
            throw new IOException("Unexpected end of file!");
        return Read();
    }
}
