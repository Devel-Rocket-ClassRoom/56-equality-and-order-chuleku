using System;
using System.Collections.Generic;
using System.Text;

class Color : IEquatable<Color>
{
    public int R
    {
        get => R;
        set
        {
            if (value <= 0)
            {
                R = 0;
            }
            else if (value >= 255)
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
        get => G;
        set
        {
            if (value <= 0)
            {
                G = 0;
            }
            else if (value >= 255)
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
        get => B;
        set
        {
            if (value < 0)
            {
                B = 0;
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
        int diffR = Math.Abs(R - other.R);
        int diffG = Math.Abs(G - other.G);
        int diffB = Math.Abs(B - other.B);

        return diffR<=threshold&&diffG<=threshold&&diffB<=threshold;
    }
    public override string ToString()
    {
        return $"RGB({R}, {G}, {B})";
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }
}
