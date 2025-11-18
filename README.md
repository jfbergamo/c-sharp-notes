# Note sugli algoritmi

## Validità ISBN
* composto da 13 numeri
* sommare tutti i numeri in posizione dispari
* sommare tutti i numeri in posizione pari moltiplicati per 3
* se la somma delle due somme è un multiplo di 10 allora è valido


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

## Triangoli (TODO)
Data una terna di numeri, calcolare se possono essere lati di un triangolo
```
p -> semiperimetro
p = (a+b+c)/2
A = sqrt(p*(p-a)*(p-b)*(p-c))
Se l'area è calcolabile il triangolo è valido
```