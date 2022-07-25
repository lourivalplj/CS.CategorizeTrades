namespace CS.CategorizeTrades.Interfaces
{
    interface ITrade
    {
        double Value { get; set; }
        string ClientSector { get; set; }
    }
}
