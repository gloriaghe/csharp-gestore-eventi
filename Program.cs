using System;

Console.WriteLine("Premi 1 se vuoi creare un programma Eventi ");
Console.WriteLine("Premi 2 se vuoi creare un Evento singolo");

int sceltaUserMenù = Convert.ToInt32(Console.ReadLine());

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
}
else if (sceltaUserMenù == 2)
{
    //Console.Write("Vuoi creare un nuovo Evento? Digita SI o NO: ");
    //string sceltaUser = Console.ReadLine();
    Evento evento = null;
    int postiPrenotati = 0;


    //if (sceltaUser == "SI")
    //{
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
            //while (!continua)
            //{
            //    try
            //    {
            Console.Write("Inserisci i posti totali dell'Evento: ");
            postiMassimi = Convert.ToInt32(Console.ReadLine());
            //continua = true;
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("error: devi inserire un numero");
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("Errore di inserimento");
            //    }
            //}
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
            if(evento.PostiPrenotati == 0)
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


    //}
    //else
    //{
    //    Console.WriteLine("A presto!");
    //}
}
