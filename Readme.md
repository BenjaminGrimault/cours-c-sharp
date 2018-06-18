# Cours C#

Petite application permettant de parser des commandes de programmation logique.

Example :
```
Fait : parent(Name1, Name2); // Name1 est parent de Name2

Règle : parent(B, A) & parent(C, B) => ancetre(C, A)

Question:
    parent(Name1, X) : List<String>

```