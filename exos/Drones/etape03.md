# Drones

## Etape 3 : Production

Dans cette étape, les usines (`Factory`) vont se mettre à produire des biens: des smarties.

Les usines produisent par cartons. Chaque carton est caractérisé par:
- Un numéro de carton unique
- Le nombre de kilos de smarties qu'il contient : entre 5 et 10 kilos
- La couleur des smarties (ils sont tous de la même couleur dans un carton): Rouge, Jaune, Bleu, Brun ou Orange

A chaque fois qu'une usine produit un carton, elle l'annonce à la centrale de distribution (`Dispatch`) pour que plus tard un drone puisse venir le prendre.  
La centrale est caratérisée par:
- La liste des cartons produits

### Marche à suivre

Faites un commit à chaque pas.

1. Créez une classe `Box` qui modélise le carton de smarties.
2. Ajoutez une propriété `Id` à votre `Factory`, cela permettra de l'identifier.
3. Ajoutez une méthode `Update` au modèle `Factory`, veillez à ce que le moteur l'appelle pour toutes les usines à chaque cycle (frame), parce que maintenant il va se passer des choses dans votre usine quand le temps passe:
   - Incrémentez un "compteur de frames"
   - Si ce compteur représente plus que 5 secondes
     - Fabriquez un carton de smarties
     - Annoncez-le à la centrale de distribution (`Dispatch`)
     - La centrale annonce la réception du carton par un message dans la console (`Console.WriteLine`)
4. Créez la classe `Dispatch` qui modélise la centrale de distribution, déclarez-la et instanciez-la en `static` dans la classe `Airspace`.
5. Créez l'interface `IDispatchable` (mettre le fichier dans `Model`). Cette interface doit permettre:
   - De passer un objet `Box` pour qu'il soit enregistré dans la liste
   - De retirer un objet `Box` de la liste  
  
   A vous de choisir les signatures de ces deux méthodes
6. Déclarez l'implémentation de l'interface `IDispatchable` par la classe `Dispatch`. Faites faire l'implémentation de base de l'interface à Visual Studio (Actions rapides...)
7. Implémentez réellement les méthodes. 
8. Modifiez votre factory pour qu'elle transmette les cartons produits à à la centrale.
9. La centrale affiche l'annonce d'un carton dans la console. A partir de là, chaque fois qu'un carton est produit, on a deux messages dans la console:
    - Message de fabrication (par la `Factory`)
    - Message de réception (par la centrale)
10. Ecrivez un test unitaire qui valide chacune des méthodes implémentée par `Dispatch`

N'hésitez pas à valider le contenu de vos commits avec votre prof ou un de ses assistants.