using System;
using System.Collections.Generic;
using System.Text;

class Color : IEquatable<Color>
{
    private int _R;
    private int _G;
    private int _B;
    public int R
    {
        get => _R;
        set
        {
            if (value <= 0)
            {
                _R = 0;
            }
            else if (value >= 255)
            {
                _R = 255;
            }
            else
            {
                _R = value;
            }
        }
    }
    public int G
    {
        get => _G;
        set
        {
            if (value <= 0)
            {
                _G = 0;
            }
            else if (value >= 255)
            {
                _G = 255;
            }
            else
            {
                _G = value;
            }
        }
    }
    public int B
    {
        get => _B;
        set
        {
            if (value < 0)
            {
                _B = 0;
            }
            else if (value > 255)
            {
                _B = 255;
            }
            else
            {
                _B = value;
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
        if(other is null)
        {
            return false; 
        }
        if(ReferenceEquals(this, other))
        {
            return true; 
        }
        return R == other.R && G == other.G &&B == other.B;
    }
    public override bool Equals(object obj) => Equals(obj as Color);
    public bool IsSimilar(Color other,int threshold)
    {
        if (other == null) return false;
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
