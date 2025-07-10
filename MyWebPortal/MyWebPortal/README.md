# Mon Portail Web Multifonctionnel

Ce projet est une application web développée avec ASP.NET Core MVC dans le cadre d'un projet universitaire. L'application sert de portail centralisé qui intègre plusieurs API externes pour fournir divers services en ligne.

## Fonctionnalités

Le portail inclut les modules suivants :

*   **Estimation d'âge :** Utilise l'API **Agify.io** pour estimer l'âge moyen associé à un prénom.
*   **Informations IP :** Utilise l'API **IPinfo.io** pour fournir des données de géolocalisation pour une adresse IP donnée.
*   **Cours des Crypto-monnaies :** Utilise l'API **CoinGecko** pour afficher le prix actuel des principales crypto-monnaies.

## Technologies Utilisées

*   **Backend :** C# / ASP.NET Core MVC (.NET 8)
*   **Frontend :** HTML, CSS, JavaScript, Bootstrap
*   **Architecture :** MVC (Modèle-Vue-Contrôleur) avec une architecture de services pour la logique métier.
*   **Communication API :** `HttpClient`
*   **Contrôle de Version :** Git & GitHub

## Comment Lancer le Projet

1.  **Cloner le dépôt :**
    ```bash
    git clone https://github.com/dpaulidor/MyWebPortal.git
    ```
2.  **Ouvrir la solution :**
    Ouvrez le fichier `MyWebPortal.sln` avec Visual Studio 2022 ou une version plus récente.
3.  **Restaurer les dépendances :**
    Visual Studio devrait restaurer les paquets NuGet automatiquement. Sinon, faites un clic droit sur la solution et choisissez "Restore NuGet Packages".
4.  **Lancer l'application :**
    Appuyez sur le bouton "Play" (Démarrer le débogage ) ou sur F5.

## Auteur

*   **[Danika Paulidor]**
