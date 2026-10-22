using EromuApp;
using System.Linq.Expressions;

List<Eromu> lista = new List<Eromu>();

int hibasSorokSzama = 0;

var beolvas = File.ReadAllLines("eromuvek.txt").Skip(1);

foreach (var sor in beolvas)
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }

    string[] splitelve = sor.Split('|');

    if (splitelve.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }

    if (splitelve[0] != "S" && splitelve[0] != "Z" || splitelve[1] == "")
    {
        hibasSorokSzama++;
        continue;
    }

    if (!int.TryParse(splitelve[2], out int kapacitas) || !int.TryParse(splitelve[3], out int toronymagassag))
    {
        hibasSorokSzama++;
        continue;
    }

    if (splitelve[0] == "S")
    {
        Eromu eromu = new Eromu(splitelve[1], kapacitas);
        lista.Add(eromu);
    }

    if (splitelve[0] == "Z")
    {
        Szelgenerator generator = new Szelgenerator(splitelve[1], kapacitas, toronymagassag);
        lista.Add(generator);
    }
}

Console.WriteLine("Sikeresen beolvasott erőművek: " + lista.Count() + " db");
Console.WriteLine("Kiszűrt hibás sorok száma: " +  hibasSorokSzama + " db");

Console.WriteLine("\nBeolvasott erőművek listája");

foreach (var sor in lista)
{
    Console.WriteLine(sor);
}

Console.WriteLine("\nSzélgenerátorok külön elemzése: ");
foreach (var elem in lista)
{
    if (elem is Szelgenerator sz)
    {
        Console.WriteLine(sz.Azonosito + " szélgenerátor toronymagassága \t" + sz.Toronymagassag + " m");
    }
}


var osszes = lista.Sum(e => e.NapiTermeles(12));

Console.WriteLine("\nÖsszesített energiatermelés 12 óra alatt: " +  osszes + " kWh");
Console.WriteLine("Erőmű példányok száma (static):"+  Eromu.OsszesEromuSzama + " db");




