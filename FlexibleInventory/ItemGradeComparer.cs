using System;
using System.Collections.Generic;
using System.Text;


class ItemGradeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }
        return x.Grade == y.Grade;
    }
    public override int GetHashCode(Item obj)
    {
        return obj.Grade.GetHashCode();
    }
}