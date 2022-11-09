using System;

Console.WriteLine("Vuoi creare un nuovo Evento? Digita SI o NO");
string sceltaUser = Console.ReadLine();
if (sceltaUser == "SI")
{
    Console.Write("Inserisci il titolo dell'Evento: ");
    string titolo = Console.ReadLine();
    bool continua = true;
    DateOnly dataonly = new DateOnly();
    int postiMassimi = 0;
    int postiPrenotati = 0;

    while (continua)
    {
        try
        {
            Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
            string data = Console.ReadLine();
            dataonly = DateOnly.Parse(data);
            continua = false;
        }
        catch (FormatException)
        {
            Console.WriteLine("error: devi inserire un valore adatto ad una data ");
        }
    }
    while (!continua)
    {
        try
        {
            Console.Write("Inserisci i posti totali dell'Evento: ");
            postiMassimi = Convert.ToInt32(Console.ReadLine());
            continua = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("error: devi inserire un numero");
        }
        catch (Exception)
        {
            Console.WriteLine("Errore di inserimento");
        }
    }
    Evento evento = new Evento(titolo, dataonly, postiMassimi);
    Console.Write("Evento creato. Vuoi prenotare dei posti? SI o NO");
    sceltaUser = Console.ReadLine();
    if (sceltaUser == "SI")
    {
        Console.Write("Quanti posti vuoi prenotare? ");
        while (continua)
        {
            try
            {
                postiPrenotati = Convert.ToInt32(Console.ReadLine());
                continua = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("error: devi inserire un numero");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore di inserimento");
            }
        }
                evento.PrenotaPosti(postiPrenotati);
    }
    else
    {
        Console.WriteLine("Ok. Nessun posto prenotato!");
    }
    Console.WriteLine("Numero di posti disponibili: " + (evento.PostiMassimiCapienza - evento.PostiPrenotati));
    Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
}
else
{
    Console.WriteLine("A presto!");
}
