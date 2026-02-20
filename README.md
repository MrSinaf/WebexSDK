<div align=center>

# ⚠️ SDK non-officiel pour Webex en C# ⚠️

</div>

Une petite librairie non-officiel, pour effectuer efficacement quelques requêtes en C#.\
Écris sous `netstandard 2.0` pour un maximum de compatibilité! (*￣3￣)╭

> [!CAUTION]
> (╬▔皿▔)╯Cette librairie est incomplète!\
> Elle n'est que pour le moment une simple manière de communiquer avec Webex pour des
> fonctionnalités ciblées.

## Websocket : Server <-> Client

Cette bibliothèque permet de configurer un WebSocket côté serveur et client!\
Le client s'attend à récupérer un `WebhookResponse` en format JSON. Le filtre et la gestion des 
clients doit se faire sur le serveur.

> [!WARNING]
> Ce Websocket intégré ne prend qu'en charge pour le moment uniquement la resource `TelephonyCalls`!

### Client

La configuration du client est simple:
```cs
webexClient.clientSocket.Connect(
	new Uri($"ws://<LIEN VERS MON SERVEUR WEBSOCKET>")
);
```
Et voilà (‾◡◝)!

Les événements peuvent être écoutés via une class static par resource, par exemple pour la 
resource `TelephonyCalls`, vous pouvez utiliser `TelephonyCallService`, exemple:
```cs
TelephonyCallService.onCallUserOriginated += ... // Quand un appel est envoyé.
TelephonyCallService.onCallUserReceived += ...   // Quand un appel est reçu.
```
La bibliothèque se chargera de filtrer et d'appeler les événements correspondants.

---
Besoins d'informations (。_。)? Vous pouvez me contacter par mail: mickael@sinaf.me