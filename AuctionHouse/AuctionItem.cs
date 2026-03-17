using System;
using System.Collections.Generic;
using System.Text;

class AuctionItem
{
    public string _Name { get; private set; }
    public int CurrentBit { get; private set; }
    public int BidCount { get; private set; }
    public string Category {  get; private set; }
    public AuctionItem(string name, int currentBit, int bidCount, string category)
    {
        _Name = name;
        CurrentBit = currentBit;
        BidCount = bidCount;
        Category = category;
    }
    public override string ToString()
    {
        return $"{_Name} [{Category}] - 입찰가: {CurrentBit}골드 (입찰 {BidCount}회)";
    }
}