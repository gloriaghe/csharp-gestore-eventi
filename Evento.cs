using Microsoft.VisualBasic;

public class Evento
{
    private string _titolo;
    private DateOnly _data;
    private int _postiMassimiCapienza;
    private int _postiPrenotati;
    public DateOnly oggi = DateOnly.FromDateTime(DateTime.Now);

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
    public DateOnly Data
    {
        get
        {
            return _data;
        }
        set
        {
            if (value == null || value < oggi)
                throw new GestoreEventiException("La data non può essere precendete ad oggi");
            _data = value;
        }
    }
    public int PostiMassimiCapienza
    {
        get
        {
            return _postiMassimiCapienza;
        }
        private set
        {
            if (value == null || value <= 0)
                throw new GestoreEventiException("La capienza deve essere maggiore di 0");
            _postiMassimiCapienza = value;
        }
        
    }
    public int PostiPrenotati
    {
        get
        {
            return _postiPrenotati;
        }
        private set
        {
            _postiPrenotati = value;

        }
    }

    public Evento(string titolo, DateOnly data, int postiMassimiCapienza)
    {
        Titolo = titolo;
        Data = data;
        PostiMassimiCapienza = postiMassimiCapienza;
        PostiPrenotati = 0;
    }

    public void PrenotaPosti(int postiAggiunti)
    {
        if (Data < oggi || PostiPrenotati == PostiMassimiCapienza  ||PostiMassimiCapienza < (PostiPrenotati + postiAggiunti))
            throw new GestoreEventiException("L'evento è già passato o non ci sono posti a sufficenza");
        _postiPrenotati += postiAggiunti;
        
    }
    public void DisdiciPosti(int postiDisdetti)
    {
        if (Data < oggi || PostiPrenotati < postiDisdetti)
            throw new GestoreEventiException("L'evento è già passato o non ci sono posti da disdire a sufficenza");
        _postiPrenotati = _postiPrenotati - postiDisdetti;
    }

    public override string ToString()
    {
        return Titolo+ ","+ _data.ToString("dd/MM/yyyy") + "," + PostiMassimiCapienza+ ","+ PostiPrenotati;
        //string stringa = "------ Evento ------\n";
        //stringa += "Titolo:\t" + this.Titolo + "\n";
        //stringa += "Autore:\t" + this._data.ToString("dd/MM/yyyy") + "\n";
        //stringa += "Posti Massimi Capienza:\t" + this.PostiMassimiCapienza + "\n";
        //stringa += "Posti Prenotati:\t" + this.PostiPrenotati + "\n";
        //stringa += "-------------------";
        //return stringa;
    }
   public string StampCSV()
    {
        return Titolo + "," + _data.ToString("dd/MM/yyyy") + "," + PostiMassimiCapienza + "," + PostiPrenotati;

    }
}
