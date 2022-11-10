using Microsoft.VisualBasic;

public class ProgrammaEventi
{
    //public string Titolo;
    private string _titolo;

    public List<Evento> eventi;

    public string Titolo
    {
        get
        {
            return _titolo;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Il nome non può essere vuoto");
            _titolo = value;
        }
    }
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        eventi = new List<Evento>();
    }
    public void AggiuntaEvento(Evento evento)
    {
        eventi.Add(evento);
    }
    public List<Evento> DataEventi(DateOnly data)
    {
        List<Evento> eventiData = new List<Evento>();
        foreach (Evento item in eventi)
        {
            if (item.Data == data)
            {
                eventiData.Add(item);
            }
        }
        return eventiData;
    }
    public static string StampaEventi(List<Evento> eventi)
    {
        string stringa = "";

        foreach (Evento item in eventi)
        {
            stringa += item + "\n";
        }
            return stringa;
    }

    public int NumeroEventi()
    {
        return eventi.Count;
    }

    public void SvuotaListaEventi()
    {
        eventi.Clear();
    }

    public override string ToString()
    {
        string stringa = Titolo + "\n";

        foreach (Evento evento in eventi)
        {
            stringa = stringa + "\t" + evento + "\n";
        }
        return stringa;
    }
}