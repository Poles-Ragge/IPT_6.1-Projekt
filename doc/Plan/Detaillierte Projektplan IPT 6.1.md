**Detaillierter Plan IPT 6.1**

**PROJEKT: "BlockKilL"**

**MITGLIEDER: Luka Vucer \& Khalil Hamahmi**

**KLASSE: BMSD24a**

**LEHRPERSON: Manuel Kaspar**



**BESCHREIBUNG:**



Weil das Projekt beides sowohl C# als auch SQL beinhalten soll, haben wir uns entschieden ein Videospiel zu erschaffen das mithilfe von einer SQLight Datenbank Daten persistent speichert. Wir wissen das dies ineffizienter ist ein z.b eine JSON Speicherung, jedoch wird dies ein Proof-of-Concept sein, damit wir sehen wollen wie das funktionieren könnte. Wir haben uns für ein Spiel entschieden weil wir schon Erfahrung damit gemacht haben in einem früheren IPT Modul. Wir benutzen dabei UNITY, was ein Teammitglied (LV) den anderen (KH) beibringen will.



Genaueres Design über das Game und all den Levels werden später noch kommen. Es wird ein Jump'n'Run ähnliches Spiel sein, wo man gegen Gegner kämpfen soll. Dabei hat man ein Inventar, Erfahrungspunkte und In-Game-Währung die alle per eine SQLight Databank gespeichert werden. Einige Daten wie Gesundheit der verschiedenen Charaktere werden nicht mithilfe der SQLight Datenbank persistent gespeichert, sondern sind nur im jeweiligen Level des Spieles (werden beim Neustart/Tod wieder erneuert).



**AUFGABEN DER DB:**

* **Speicherung des Spielstandes (via Level)**

**>>> Das nächste Level wird erst freigeschaltet, wenn man das vorherige überlebt**

* **In-game Variabel Speicherung (Münzen, Highscore, XP, Gegenstände, etc.)**

**>>> Münzen bekommt man nach dem abschliessen eines Spieles und dann kann man Gegenstände damit kaufen.**



**GITHUB BEMERKUNG:**



Das Projekt befindet sich auf das Github von Luka Vucer, wo beide Teammitglieder unabhängig voneinander reincommiten werden. Sollte dies sich im Verlauf des Projektes ändern wird immer dies auch in der Beschreibung des jeweiligen Commits explizit Erklärt und Unterschieden wer was beim Commit erbracht hat.



**ERM:**



!\[Alt text]("C:\\Users\\poles\\Downloads\\Er-Diagramm IPT 6.1.drawio.png")



***Bemerkung: Wenn die obere Grafik nicht angezeigt wird dann finden Sie die Grafik auch in der Abgabe.***



**ERD:**



!\[Alt text]("C:\\Users\\poles\\Downloads\\ERM-IPT.6.1.drawio.png")



***Bemerkung: Wenn die obere Grafik nicht angezeigt wird dann finden Sie die Grafik auch in der Abgabe.***



**DETAILLIERTER ZEITPLAN:**





| Datum         | Auftrag                                   | Auftragnehmer | Notiz                |

|---------------|-------------------------------------------|---------------|----------------------|

| 05.02.2026    | Planung                                   | L.V \& K.H     | Planugnslektion      |

| bis 22.2.2026 | ERM + ERD + Prog-Ablaufplan + UML-Klass.D | L.V           | ü. Ferien            |

| bis 22.2.2026 | Unity aufsetzen/kennenlernen + SQLite     | K.H           | ü. Ferien            |

| 26.02.2026    | Design abmachen + Crashcours geben        | L.V           |                      |

| 26.02.2026    | Crashcours Unity                          | K.H           | von LV               |

| 05.03.2026    | Design                                    | L.V           | Besprechung richtung |

| 05.03.2026    | SQLite mit Unity verbinden                | K.H           |                      |

| 12.03.2026    | Design                                    | L.V           |                      |

| 12.03.2026    | Datenbank                                 | K.H           |                      |

| 19.03.2026    | Design                                    | L.V           |                      |

| 19.03.2026    | Datenbank                                 | K.H           |                      |

| 26.03.2026    | Game - Level                              | L.V           |                      |

| 26.03.2026    | Game - Level                              | K.H           |                      |

| 02.04.2026    | Game - Level                              | L.V           |                      |

| 02.04.2026    | Game - Charaktere                         | K.H           |                      |

| 09.04.2026    | Game - Charaktere                         | L.V           | Mechaniken           |

| 09.04.2026    | Game - Charaktere                         | K.H           | Mechaniken           |

| 16.04.2026    | Game - Charaktere                         | L.V           |                      |

| 16.04.2026    | Game - Mechanics                          | K.H           | von Leveln           |

| 23.04.2026    | Game - Mechanics                          | L.V           | Phisik, etc.         |

| 23.04.2026    | Game - Mechanics                          | K.H           |                      |

| 30.04.2026    | Game - Testing                            | L.V           |                      |

| 30.04.2026    | Game - Testing                            | K.H           |                      |

| 07.05.2026    | Game - Level                              | L.V           |                      |

| 07.05.2026    | Game - Level                              | K.H           |                      |

| 14.05.2026    | Game - Level                              | L.V           |                      |

| 14.05.2026    | Game - Level                              | K.H           |                      |

| 21.05.2026    | Game - Polishing                          | L.V           |                      |

| 21.05.2026    | Game - Testing                            | K.H           | Fehler finden        |

| 28.05.2026    | Datenbank verknüpfen                      | L.V           |                      |

| 28.05.2026    | Game - Polishing                          | K.H           |                      |

| 04.06.2026    | Game - Testing                            | L.V           | Fehler finden        |

| 04.06.2026    | Game - Testing                            | K.H           | Fehler finden        |

| 11.06.2026    | Polishing                                 | L.V           |                      |

| 11.06.2026    | Polishing                                 | K.H           |                      |

| 12.06.2026    | Letzte Überprüfungen \& abgabe             | L.V           | Abgabe LV Github     |

| 12.06.2026    | Letzte Überprüfungen \& abgabe             | K.H           | Abgabe LV Github     |



***Geplantes Zeitaufwand: 15 Doppellektionen (17 mit der 5.2.26 Planungslektion \& vorherige Lektion) + Heimarbeit von 10 Lektionen***

