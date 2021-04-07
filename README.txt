# Hu_Biblio
1) composizione dell'interfaccia: 2 button Bibliotecario e utente;
2) Disponibilità di un libro gestita dal numero di copie (se maggiore di 0 allora disponibile, sennò non disponibile... false, quindi in modo automatico);
3) Bibliotecario: possibilità di aggiungere copie di uno stesso libro, modificarne il prezzo oppure anche elliminarlo... Aggiungere nuovi libri;
4) Utente: possibilità di vedere le proprie informazioni (date in precedenza durante la registrazione), Prenotare un libro (si vedrà true o false in base al numero di copie presenti del libro, decrementando alla prenotazione) oppure anche rinnovarlo;
5) Utente: alla registrazione assegna un id in modo automatico (all'interno della classe utente, funzione generatoreID ) e universale;
6) Tutto è salvato all'interno di vari file di tipo json, serializzando e deserializzando in base alle necessità e con utilizzo della libreria Newtonsoft.Json;

Problemi riscontrati:
Blocco sblocco di un determinato utente in base ai suoi ritardi (quindi non implementato)
Potrebbe dare un problema nei "panel a scorrimento", facilmente risovibile con un doppio click del mouse...