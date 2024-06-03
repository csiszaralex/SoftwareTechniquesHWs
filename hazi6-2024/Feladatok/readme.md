# 1. Feladat kérdéseire válasz

A Strategy és a DI kombinációja a modularitást és a rugalmasságot növeli, mivel a különböző stratégiák könnyen cserélhetőek, és a DI segítségével a különböző stratégiák könnyen beinjektálhatóak.

Az, hogy a strategy minta megvalósítja az Open/Closed elvet, az azt jelenti, hogy a kód módosítása nélkül lehet új stratégiákat hozzáadni a programhoz. Az új stratégiák implementálásához csak egy új osztályt kell létrehozni, és implementálni a megfelelő interfészt.
