# Note sugli algoritmi

## Validità ISBN
* composto da 13 numeri
* sommare tutti i numeri in posizione dispari
* sommare tutti i numeri in posizione pari moltiplicati per 3
* se la somma delle due somme è un multiplo di 10 allora è valido

## Trova il 7
Come capire se un numero ha il 7 senza convertirlo in stringa:
```c-sharp
static bool hasSeven(int n)
{
    int x = n;
    int mod;
    while (x > 0)
    {
        mod = x % 10;
        if (mod == 7) return true;
        x /= 10;
    }
    return false;
}
```

## Formula MCD
```
MCD(a, b):
    a/b
    se resto 0 -> MCD
    sennò a = b e b = resto
    ripetere
```

## Anno bisestile:
* lo è se è divisibile per 4
* ma non lo è se è divisibile per 100
* ma lo è se è divisibile per 400

## Triangoli
Data una terna di numeri, calcolare se possono essere lati di un triangolo
```
p -> semiperimetro
p = (a+b+c)/2
A = sqrt(p*(p-a)*(p-b)*(p-c))
Se l'area è calcolabile il triangolo è valido
```

## Array
Alcuni esercizi con gli array, tra cui:
* Elenca quanti giorni hanno i mesi per X anni
* Merge sort tra due array ordinati
* Merge sort con un array di array ordinati
* Media tra valori di un array
* Dato un array di booleani che codificano un numero in binario, ottenre il suo binario
* Converte una stringa in un array dei suoi codici ASCII
* Controlla se una parola è in ordine alfabetico