using System;
using System.Collections.Generic;

Console.WriteLine("Premi 1 se vuoi creare un programma Eventi ");
Console.WriteLine("Premi 2 se vuoi creare un Evento singolo");

int sceltaUserMenù = Convert.ToInt32(Console.ReadLine());
List<Evento> programmi = new List<Evento>();

if (sceltaUserMenù == 1)
{
    Console.WriteLine();

    Console.Write("Inserisci il nome del programma Eventi: ");
    string nomeProgramma = Console.ReadLine();

    ProgrammaEventi programmaevento = new ProgrammaEventi(nomeProgramma);
    Console.Write("Quanti Eventi vuoi inserire? ");
    bool numeroeventiOK = true;
    int numeroEventi = 0;

    while (numeroeventiOK)
    {
        try
        {
            numeroEventi = Convert.ToInt32(Console.ReadLine());
            numeroeventiOK = false;
        }
        catch (FormatException)
        {
            Console.WriteLine("error: devi inserire un valore adatto ad una data ");
        }
        catch (Exception)
        {
            Console.WriteLine("Errore di inserimento");
        }
    }
    for (int i = 0; i < numeroEventi; i++)
    {
        bool generaEventoCorretto = true;

        while (generaEventoCorretto)
        {

            try
            {
                Console.WriteLine();
                bool continua = true;

                Console.Write("Inserisci il titolo del {0}° Evento: ", i + 1);
                string titolo = Console.ReadLine();

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


                Console.Write("Inserisci i posti totali dell'Evento: ");
                postiMassimi = Convert.ToInt32(Console.ReadLine());
                continua = true;

                Evento evento = null;


                evento = new Evento(titolo, dataonly, postiMassimi);
                programmaevento.AggiuntaEvento(evento);
                generaEventoCorretto = false;
                programmi.Add(evento);

            }
            catch (FormatException)
            {
                Console.WriteLine("error: devi inserire un numero");
            }
            catch (GestoreEventiException)
            {
                Console.WriteLine("Le informazioni inserite non sono corrette ricrea l'evento");
            }
            catch (Exception)
            {
                Console.WriteLine("C'è stao un'errore... ricreo l'evento");

            }
        }
    }
    Console.WriteLine();
    Console.WriteLine("Il numero di eventi nel programma è: " + numeroEventi);
    Console.WriteLine("Ecco il programma completo: ");
    Console.WriteLine(programmaevento.ToString());

    Console.WriteLine();
    Console.Write("Inserisci una data per sapere che eventi ci saranno: ");
    string data1 = Console.ReadLine();
    DateOnly datascelta = DateOnly.Parse(data1);
    List<Evento> programmiDataSpecifica = programmaevento.DataEventi(datascelta);

    Console.WriteLine(ProgrammaEventi.StampaEventi(programmiDataSpecifica));

    //conferenza
    Console.Write("Ora aggiungi una conferenza:");
    Console.WriteLine();

    bool generaConferenza = true;

    while (generaConferenza)
    {

        try
        {
            Console.WriteLine();
            bool continua = true;

            Console.Write("Inserisci il titolo della conferenza: ");
            string titolo = Console.ReadLine();

            DateOnly dataonly = new DateOnly();
            int postiMassimi = 0;
            int postiPrenotati = 0;

            while (continua)
            {
                try
                {
                    Console.Write("Inserisci la data (gg/mm/yyyy): ");
                    string data = Console.ReadLine();
                    dataonly = DateOnly.Parse(data);
                    continua = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("error: devi inserire un valore adatto ad una data ");
                }
            }


            Console.Write("Inserisci i posti totali: ");
            postiMassimi = Convert.ToInt32(Console.ReadLine());
            continua = true;
            Console.Write("Inserisci il relatore: ");
            string relatore = (Console.ReadLine());
            Console.Write("Inserisci il prezzo del biglietto: ");
            double prezzo = Convert.ToInt32(Console.ReadLine());
            Conferenza conferenza = null;


            conferenza = new Conferenza(titolo, dataonly, postiMassimi, relatore, prezzo);
            programmaevento.AggiuntaEvento(conferenza);
            generaConferenza = false;
            programmi.Add(conferenza);

        }
        catch (FormatException)
        {
            Console.WriteLine("error: devi inserire un numero");
        }
        catch (GestoreEventiException)
        {
            Console.WriteLine("Le informazioni inserite non sono corrette ricrea l'evento");
        }
        catch (Exception)
        {
            Console.WriteLine("C'è stao un'errore... ricreo l'evento");

        }
    }
    Console.WriteLine();
    Console.WriteLine(programmaevento);

    //EXPORT CSV
    Console.WriteLine("Vuoi generare l'export del programma eventi in formato csv? SI/NO ");
    string userCsv = Console.ReadLine();
    if (userCsv == "SI")
    {
        StreamWriter fileDaScrivere = File.CreateText("C:\\Users\\glogh\\source\\repos\\corsoCSharp\\csharp-gestore-eventi\\eventi-formattati.txt");

        fileDaScrivere.WriteLine("titolo,data,capienza massima,posti prenotati");

        foreach (Evento evento in programmi)
        {

            fileDaScrivere.WriteLine(evento.StampCSV());

        }
        fileDaScrivere.Close();

    }
    else
    {
        Console.WriteLine("Ok, ciao!");
    }

    Console.WriteLine("Vuoi generare l'import del programma eventi in formato csv? SI/NO ");
    string userImportCsv = Console.ReadLine();
    if (userImportCsv == "SI")
    {

    }
    else
    {
        Console.WriteLine("Ok, ciao!");
    }
}



else if (sceltaUserMenù == 2)
{
    Evento evento = null;
    int postiPrenotati = 0;

    bool eventoOK = true;
    while (eventoOK)
    {
        bool continua = false;
        try
        {
            Console.WriteLine();
            Console.Write("Inserisci il titolo dell'Evento: ");
            string titolo = Console.ReadLine();

            DateOnly dataonly = new DateOnly();
            int postiMassimi = 0;


            while (!continua)
            {
                try
                {
                    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
                    string data = Console.ReadLine();
                    dataonly = DateOnly.Parse(data);
                    continua = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("error: devi inserire un valore adatto ad una data ");
                }
            }

            Console.Write("Inserisci i posti totali dell'Evento: ");
            postiMassimi = Convert.ToInt32(Console.ReadLine());

            evento = new Evento(titolo, dataonly, postiMassimi);
            eventoOK = false;

        }
        catch (FormatException)
        {
            Console.WriteLine("error: devi inserire un numero");
        }
        catch (GestoreEventiException)
        {
            Console.WriteLine("Le informazioni inserite non sono corrette ricrea l'evento");
        }
        catch (Exception)
        {
            Console.WriteLine("C'è stao un'errore... ricrea l'evento");

        }
    }
    Console.Write("Evento creato. Vuoi prenotare dei posti? (SI o NO) ");
    string sceltaUser = Console.ReadLine();


    if (sceltaUser == "SI")
    {
        bool disdiciOK = false;
        while (!disdiciOK)
        {
            Console.Write("Quanti posti vuoi prenotare? ");
            bool PrenotazioneOK = false;
            while (!PrenotazioneOK)
            {
                try
                {
                    postiPrenotati = Convert.ToInt32(Console.ReadLine());

                    PrenotazioneOK = true;
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

            try
            {
                evento.PrenotaPosti(postiPrenotati);
                disdiciOK = true;

            }
            catch (GestoreEventiException)
            {
                Console.WriteLine("Errore! I posti prenotati sono maggiori dei posti disponibili");
            }

        }
        Console.WriteLine("Numero di posti disponibili: " + (evento.PostiMassimiCapienza - evento.PostiPrenotati));
        Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);

    }
    else
    {
        Console.WriteLine("Ok. Nessun posto prenotato!");

    }
    bool postiDisdetti = true;
    while (postiDisdetti)
    {
        Console.Write("Vuoi disdire dei posti? SI/NO ");
        sceltaUser = Console.ReadLine();
        if (sceltaUser == "SI")
        {
            bool disdiciOK = false;
            while (!disdiciOK)
            {
                Console.Write("Quanti posti vuoi disdire? ");
                int numDisdetti = Convert.ToInt32(Console.ReadLine());

                try
                {
                    evento.DisdiciPosti(numDisdetti);
                    disdiciOK = true;

                }
                catch (GestoreEventiException)
                {
                    Console.WriteLine("Non ci sono posti da disdire a sufficenza. I posti prenotati rimasti sono: " + evento.PostiPrenotati);
                }

            }
            Console.WriteLine("Numero di posti disponibili: " + (evento.PostiMassimiCapienza - evento.PostiPrenotati));
            Console.WriteLine("Numero di posti prenotati: " + evento.PostiPrenotati);
            if (evento.PostiPrenotati == 0)
            {
                Console.WriteLine("Hai disdetto tutti i posti!");
                postiDisdetti = false;

            }
        }
        else
        {
            postiDisdetti = false;

            Console.Write("Nessun posto disdetto!");

        }
    }

}
