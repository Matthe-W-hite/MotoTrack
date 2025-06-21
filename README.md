# 🚗 MotoTrack

**MotoTrack** to wieloplatformowa aplikacja do zarządzania historią serwisową pojazdów. Umożliwia dodawanie wpisów serwisowych, dołączanie zdjęć (np. faktur) oraz przeglądanie i edytowanie historii napraw.

## 🧱 Architektura

- **Frontend**: React Native + Expo Router (działa na Android, iOS, Web)
- **Backend**: ASP.NET Core Web API (z bazą danych MS SQL)
- **Przechowywanie dokumentów**: system plików (`wwwroot/uploads`)
- **Styl architektury**: aplikacja rozproszona klient–serwer (REST API)

## 📦 Funkcje

### 🖥️ Backend (.NET API)
- [x] CRUD dla encji `ServiceHistory`
- [x] Obsługa plików (`POST /documents`, `GET /documents`)
- [x] Walidacja danych po stronie serwera (`ModelState`)
- [x] Obsługa błędów (`BadRequest`, `NotFound`, `Created` itd.)
- [x] Gotowość do wdrożenia na Dockerze (opcjonalnie)

### 📱 Frontend (React Native + Expo)
- [x] Przegląd szczegółów pojazdu
- [x] Dodawanie i edycja wpisu serwisowego
- [x] Walidacja danych po stronie klienta
- [x] Przesyłanie zdjęć z urządzenia lub przeglądarki
- [x] Wyświetlanie zdjęć przypiętych do wpisu

## ⚙️ Wymagania

### Backend
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/)
- [SQL Server Express / LocalDB](https://learn.microsoft.com/en-us/sql/database-engine)
- Visual Studio lub VS Code

### Frontend
- [Node.js](https://nodejs.org/)
- [Expo CLI](https://docs.expo.dev/get-started/installation/)
- Emulator Android/iOS lub przeglądarka

## 🚀 Uruchomienie projektu

### Backend

```bash
cd MotoTrack.API
dotnet restore
dotnet ef database update
dotnet run
