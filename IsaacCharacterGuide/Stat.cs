internal class Stat
{
    public Stat(string data)
    {
        var v = data.Split(';');
        Characters = v[0];
        CoinAmount = int.Parse(v[1]);
        BombAmount = int.Parse(v[2]);
        KeyAmount = int.Parse(v[3]);
        Heart = double.Parse(v[4]);
        Damage = double.Parse(v[5]);
        Speed = double.Parse(v[6]);
        TearsRate = double.Parse(v[7]);
    }

    public string Characters { get; set; }
    public int CoinAmount { get; set; }
    public int BombAmount { get; set; }
    public int KeyAmount { get; set; }
    public double Heart { get; set; }
    public double Damage { get; set; }
    public double Speed { get; set; }
    public double TearsRate { get; set; }
}
