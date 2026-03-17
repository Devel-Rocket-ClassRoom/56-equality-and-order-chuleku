using System;
using System.Collections.Generic;
using System.Text;

class BidComparer : Comparer<AuctionItem>
{
    public override int Compare(AuctionItem x, AuctionItem y)
    {
        if(x ==null && y ==null) return 0;
        if(x == null) return -1;
        if(y == null) return 1;

        return y.CurrentBit.CompareTo(x.CurrentBit);
    }
}
