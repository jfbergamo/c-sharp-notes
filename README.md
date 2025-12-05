# Esercizi di C#

## Validità ISBN `25-11-04/ISBN.cs`
> Dato una stringa, controlla se può essere un ISBN

**Come controllare la validità di un ISBN:**
* Deve essere composto da 13 numeri
* La somma di *tutti i numeri in posizione dispari* e di *tutti i numeri in posizione pari moltiplicati per 3* deve esere un *multiplo di 10*.

## Trova il 7 `25-11-11/TrovaSette.cs`
> Conta fino a 100 e stampa `BOOM` se il numero è multiplo di 7, `BAM` se contiene un 7 e `BEM` se è multiplo e contiene un 7.

Il metodo per trovare il 7 non prevede conversioni in stringhe. Vedi metodo `hasSeven()` per capire come.

## MCD `25-11-18/MCD.cs`
> Calcola l'MCD di due numeri e implementa degli Unit Test.

I test sono implementati con la classe `Test/UnitTest.cs`.

**L'algorimo per calcolare l'MCD è il seguente:**
```
MCD(a, b):
    a/b
    se resto 0 -> MCD
    sennò a = b e b = resto
    ripetere
```

## Validatore di Data `25-11-18/IsValidDate.cs`
> Implementa dei test per validare una data.

**Come riconoscere un anno bisestile:**
* lo è se è divisibile per 4
* ma non lo è se è divisibile per 100
* ma lo è se è divisibile per 400

## Triangoli `25-11-18/Triangoli.cs`
> Data una terna di numeri, calcolare se possono essere lati di un triangolo.

**Algoritmo utilizzato:**
```
p -> semiperimetro
p = (a+b+c)/2
A = sqrt(p*(p-a)*(p-b)*(p-c))
Se l'area è calcolabile il triangolo è valido
```

## Array `25-11-18/ArrayVari.cs`
> Alcuni esercizi con gli array, tra cui:
* Elenca quanti giorni hanno i mesi per X anni
* Merge sort tra due array ordinati
* Merge sort con un array di array ordinati
* Media tra valori di un array
* Dato un array di booleani che codificano un numero in binario, ottenre il suo binario
* Converte una stringa in un array dei suoi codici ASCII
* Controlla se una parola è in ordine alfabetico

## Base64 `25-11-21/Base64.cs`
> Implementa un encoder e decoder di Base64. **Esercizio di verifica.**
* Codifica un array di byte in una stringa in Base64
* Decodifica una stringa in Base64 in un array di byte

## ArrayOrdered `25-11-25/ArrayOrdered.cs`
> Controlla se un array è ordinato

## Fibonacci ` 25-11-25/Fibonacci.cs`
> Esercizi sulla sequenza di Fibonacci:
* Mostra i primi n numeri della sequenza
* Simula la sequenza con lettere vere
* **TODO** Esercizio con dragon.xml

## Null `25-12-02/Null.cs`
> Esercizio per testare le variabili nullable.

**Da rivedere**

## Carte `25-12-03/Carte.cs` (TODO)
> Esercizi sulle carte da Scala.
* Data una stringa, indicare se la carta è valida
* Data una carta, indicare la sua carta successiva, se non c'è null
* Mescola un mazzo di carte ([Algoritmo Fisher-Yates](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle))

## Mate
Alcune funzioni matematiche
**TBD**