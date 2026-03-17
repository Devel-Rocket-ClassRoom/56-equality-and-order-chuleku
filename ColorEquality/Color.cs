using System;
using System.Collections.Generic;
using System.Text;

class Color : IEquatable<Color>
{
    public int R
    {
        get { return R; }
        set
        {
            if (value < 0)
            {
                R = value;
            }
            else if (value > 255)
            {
                R = 255;
            }
            else
            {
                R = value;
            }
        }
    }
    public int G
    {
        get { return G; }
        set
        {
            if (value < 0)
            {
                G = value;
            }
            else if (value > 255)
            {
                G = 255;
            }
            else
            {
                G = value;
            }
        }
    }
    public int B
    {
        get { return B; }
        set
        {
            if (value < 0)
            {
                B = value;
            }
            else if (value > 255)
            {
                B = 255;
            }
            else
            {
                B = value;
            }
        }
    }
    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }
    public bool Equals(Color other)
    {
        Color obj = (other as Color);
        if(obj == null)
        {
            return false;
        }
        return Equals(obj);
    }
    public bool IsSimilar(Color other,int threshold)
    {
        Color obj = (other as Color);
    }
    public override string ToString()
    {
        return $"RGB({R}, {G}, {B})";
    }
}
