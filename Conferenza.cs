using System.Xml.Linq;

public class Conferenza : Evento
{

    private string _relatore;
    private double _prezzo;

    private string Relatore

    {
        get
        {
            return _relatore;
        }
        set
        {
            if (value == null || value == "")
                throw new GestoreEventiException("Il nome del relatore non può essere vuoto");
            _relatore = value;
        }
    }
    private double Prezzo

    {
        get
        {
            return _prezzo;
        }
        set
        {
            if (value < 0)
                throw new GestoreEventiException("Il prezzo è errato");
            _prezzo = value;
        }
    }




    public Conferenza(string titolo, DateOnly data, int postiMassimiCapienza, string relatore, double prezzo) : base(titolo, data, postiMassimiCapienza)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }

    public string PrezzoFormattato()
    {
        string prezzoFormattato = _prezzo.ToString("0.00");

        return prezzoFormattato;
    }
    public override string ToString()
    {
        return Data.ToString("dd/MM/yyyy") + " - " + Titolo + " - " + _relatore + " - " + PrezzoFormattato();
    }
}