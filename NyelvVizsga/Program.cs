namespace NyelvVizsga;

internal class Program
{
    static void Main(string[] args)
    {
        List<Nyelv> sikeres = File.ReadAllLines(@"../../../sikeres.csv").Skip(1).Select(x => new Nyelv(x.Split(';'))).ToList();
        List<Nyelv> sikertelen = File.ReadAllLines(@"../../../sikertelen.csv").Skip(1).Select(x => new Nyelv(x.Split(';'))).ToList();

        Console.WriteLine("2. feladat: A legnépszerűbb nyelvek:");

        Dictionary<string, int> topLista = new();
        for (int i = 0; i < sikeres.Count; i++)
            topLista.Add(sikeres[i].Nev, sikeres[i].SzamAdatok.Sum() + sikertelen[i].SzamAdatok.Sum());

        int temp = 3;
        foreach (var adat in topLista.OrderByDescending(x => x.Value))
        {
            if (temp-- == 0) break;
            Console.WriteLine("\t" + adat.Key);
        }

        Console.WriteLine("3. feladat:\n\tVizsgálandó év: ");
        int ev = Convert.ToInt32(Console.ReadLine());
        if (ev < 2009 || 2017 < ev) return;

        Dictionary<string, double> aranyok = new();
        for (int i = 0; i < sikertelen.Count; i++)
            aranyok.Add(sikertelen[i].Nev, sikertelen[i].SzamAdatok[ev - 2009] * 1.0 / (sikeres[i].SzamAdatok[ev - 2009] + sikertelen[i].SzamAdatok[ev - 2009]) * 100);


        foreach (var adat in aranyok.Where(x => x.Value == aranyok.Max(x => x.Value)).ToDictionary(x => x.Key, y => y.Value))
            Console.WriteLine($"4. feladat:\n\t{ev}-ben a {adat.Key} nyelvből a sikertelen vizsgák aránya {Math.Round(adat.Value)}");
    }
}