# 2. Feladat megoldásának bemutatása

- Mivel a `TextArea`-nak már van egy ősosztálya, így egy Interface-t vettem fel, ezzel biztosítva, hogy a szükséges lekérdezések mindenhol meg legyenek valósítva.
- Mivel a `Square` és a `Circle` osztálynak is ugyan úgy kellett lekérdezni az X és Y koordinátáit, így a bővíthetőségre felkészülve létrehoztam egy `ShapeBase` osztályt és itt használtam az `IShape` interface-t.
- Mivel az alakzatok menedzselésére dedikált osztály kellett, így létrehoztam a `ShapeInventory` osztályt, mely nem a List osztályból származik, csak implementálja azt a `List<IShape>` típusú változójában.
  - Ebben az osztályban valósítottam meg a kiírást is, mely egyszrű volt, hiszen az `IShape` interface elvárta, hogy minden szükségs metódus implementálva legyen minden osztályban.
- Az osztálydiagrammot `ClassDiagram1.cd` néven hoztam létre és az tartalmazza az összes általam létrehozott osztályt és azok kapcsolatait.
