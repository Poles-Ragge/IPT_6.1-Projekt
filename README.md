# IPT_6.1-Projekt

Projektname: BlockKill!

Mitglieder: <br>
Luka Vucer <br>
Khalil Hamahmi <br>

BlockKill! ist ein, für das IPT-6.1-Modul entwickelte, kleines Spiel. <br>
Mann kämpft sich durch verschiedene Levels mit unterschiedlichen Gegnern. <br>
Man sammelt Münzen, die man im jeweiligen Shop am Ende des Levels benutzen kann um bessere Items zu kaufen, die das vorankommen im nächsten Level vereinfachen. <br>

Technische Details: <br>

Das Spiel beeinhaltet eine Datenbank, die jeweilige Informationen und den Spielstand speichert. <br>
Der Artstyle ist relativ simple gehalten. <br>
Das Spiel wurde mithilfe von Unity entwickelt. Jeder Art von Code wurde selbst erschaffen. <br>
Die jeweiligen Grafiken wurden alle selbst erschaffen <br>

Weil das Projekt beides sowohl C# als auch SQL beinhalten soll, haben wir uns entschieden ein Videospiel zu erschaffen das mithilfe von einer SQLight Datenbank Daten persistent speichert. Wir wissen das dies ineffizienter ist ein z.b eine JSON Speicherung, jedoch wird dies ein Proof-of-Concept sein, damit wir sehen wollen wie das funktionieren könnte. Wir haben uns für ein Spiel entschieden weil wir schon Erfahrung damit gemacht haben in einem früheren IPT Modul. Wir benutzen dabei UNITY, was ein Teammitglied (LV) den anderen (KH) beibringen will.

***TODO***

<h3>*ORIENTIERUNGSHILFE*</h3>

- src
=> Ordner:  Bullets = Skripts für Bullets
=> Ordner:  Sqlite = Datenbank Skripte
=> Ordner:  Waffen-Logik = Skripte der einzelnen Waffen

=> File:    coin.cs = skript für Münzen
=> File:    Enemy2.cs = skript für Gegner
=> File:    EnemyLogic.cs = skript für Gegner
=> File:    GoToMap.cs = skript für Teleportation
=> File:    medikit.cs = skript für Leben regenerieren
=> File:    Player.cs = skript für Spieler
=> File:    RaycastVisualizer.cs = skript für Gegnersicht/Spieler sichtbarkeit
=> File:    Win.cs = skript für Siegbedingungen
<br>
- doc
=> Ordner:  Doku Bilder = Ordner mit Bilder zur Dokumentation
==> Ordner: Animationen = Ordner mit Animationsordnern
==> Ordner: Characters = Ordner mit Charaktergrafiken
==> Ordner: Guns = Waffengrafiken & Bulletgrafik
==> Ordner: misc. = Allerlei Grafiken (misc.)
==> Ordner: Raster = Alle Grafikraster
==> Ordner: Tilemaps = Alle Tiles, Tilemaps, .Json dateien, etc. 

=> Ordner:  ER Diagramme = Ordner mit allen ER Diagrammen
=> Ordner:  Grafiken = Ordner mit allen Grafiken/Bilder/Tilemaps/etc.
=> Ordner:  Konzepte = Planungsordner mit Konzeptbildern
=> Ordner:  Plan = Planungsordner mit allen Plänen, Notizen, etc.
<br>

- Screenshots von dev

- Planung

- Orientierung