public class Evento
{
    private string _titolo;
    private DateOnly _data;
    private int _postiMassimiCapienza;
    private int _postiPrenotati;

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
            DateOnly oggi = DateOnly.FromDateTime(DateTime.Now);
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

}
