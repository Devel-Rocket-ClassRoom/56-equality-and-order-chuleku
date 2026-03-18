using System;
using System.Collections.Generic;
using System.Text;

class ItemTypeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item type1,Item type2)
    {
        if(type1 == null && type2 == null)
        {
            return true;
        }
        if(type1 == null || type2 == null)
        {
            return false; 
        }
        return type1.Type == type2.Type;
    }
    public override int GetHashCode(Item obj)
    {
        return obj.Type.GetHashCode(); 
    }
   
}