# Prova in c# di webjobs

## aggiungo i pacchetti se non presenti
```
dotnet add package Microsoft.Azure.WebJobs
dotnet add package Microsoft.Azure.WebJobs.Extensions
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Microsoft.Extensions.Logging.Console

dotnet build                                # per costruire il pacchetto
dotnet run      --                          # per lanciare in locale il webjob
dotnet package -C release -o publish        # per pubblicare all'interno della cartella publish
```

## ora costruiamo lo zip, mi raccomando va copiato run.cmd in publish
> Compress-Archive -Path publish\* -DestinationPath WebJobTimerPOC.zip


## Tipologie di trigger su webjobs
Tipologie di trigger disponibili nei WebJobs
1. Timer Trigger
Esegue il job a intervalli regolari (es. ogni 5 minuti, ogni giorno alle 8:00).
Usa una sintassi tipo cron ("0 */5 * * * *").
Ottimo per attività pianificate (pulizia, report, sincronizzazioni).
2. Queue Trigger
Attiva il job quando arriva un messaggio in una Azure Storage Queue.
Perfetto per elaborazioni asincrone (es. ordini, notifiche).
3. Blob Trigger
Attiva il job quando viene caricato o modificato un file in Azure Blob Storage.
Utile per elaborare file (es. immagini, CSV, log).
4. Service Bus Trigger
Attiva il job quando arriva un messaggio in una Azure Service Bus Queue o Topic.
Ideale per scenari enterprise con sistemi distribuiti.
5. Event Grid Trigger (solo con Azure Functions)
Attiva il job in risposta a eventi da Event Grid (es. nuovi file, modifiche, eventi personalizzati).
6. Manual Trigger
Puoi avviare il job manualmente (es. da codice, da portale, da API).

## Tipologie di app che puoi inserire dentro un app service
1. Web App: applicazioni web (ASP.NET, Node.js, PHP, Python, Java, ecc.)
2. API App: servizi RESTful
3. Mobile App: backend per app mobili
4. WebJobs: processi in background (come quello che stai vedendo: webjobs-wa)

## App Service vs App Service Plan

| Concetto         | Descrizione                                                                 |
|------------------|------------------------------------------------------------------------------|
| **App Service**  | È l'istanza dell'applicazione (Web App, WebJob, API, ecc.). Ogni App Service ospita una singola app. |
| **App Service Plan** | È il "contenitore di risorse" (CPU, RAM, spazio) che può essere condiviso da più App Services. Può essere considerato un hosting plan. Il prezzo viene determinato dal pricing tier|


## WebJobs vs Azure Functions

| Caratteristica       | WebJobs                                                  | Azure Functions                                                  |
|----------------------|-----------------------------------------------------------|------------------------------------------------------------------|
| **Tipo di servizio** | Estensione di una Web App (App Service)                  | Servizio serverless indipendente                                |
| **Trigger supportati** | Timer, Queue, Blob, Service Bus                          | Timer, Queue, Blob, HTTP, Event Grid, Cosmos DB, ecc.           |
| **Gestione risorse** | Usa App Service Plan (CPU/RAM fissi)                     | Usa Consumption Plan (scalabilità automatica)                   |
| **Costo**            | Fisso (in base al piano scelto)                          | Variabile (paghi solo per esecuzione)                           |
| **Scalabilità**      | Manuale o automatica (limitata al piano)                 | Automatica e granulare                                          |
| **Deployment**       | ZIP, FTP, Git, Visual Studio                             | ZIP, GitHub Actions, Azure CLI, VS Code                         |
| **Ambiente**         | Solo Windows (Linux non supportato)                      | Windows e Linux                                                 |
| **Durata esecuzione**| Continua o pianificata                                   | Limitata (timeout configurabile)                                |

## Quando usare WebJobs?
1. Hai già una Web App e vuoi aggiungere logica in background
2. Vuoi un ambiente più tradizionale e controllato
3. Hai bisogno di un job continuo che gira sempre
## Quando usare Azure Functions?
1. Vuoi scalabilità automatica e costi ridotti
2. Hai bisogno di molti tipi di trigger (HTTP, Event Grid, ecc.)
3. Vuoi un approccio moderno e serverless
## Conclusione
Azure Functions è spesso la scelta migliore per nuovi progetti, ma WebJobs rimane utile in scenari legacy o quando si lavora già con App Service.
