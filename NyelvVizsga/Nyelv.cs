namespace NyelvVizsga;

internal class Nyelv
{
    public string Nev { get; private set; }
    public int[] SzamAdatok { get; private set; }

    public Nyelv(string[] adatok)
    {
        Nev = adatok[0];
        SzamAdatok = adatok[1..].Select(x => Convert.ToInt32(x)).ToArray();
    }
}