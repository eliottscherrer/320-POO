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
3. Ajoutez une méthode `Update` au modèle `Factory`, parce que maintenant il va se passer des choses dans votre usine quand le temps passe.  
Veillez à ce que le moteur appelle bien la méthode de toutes les usines à chaque cycle (frame).  
Dans cette méthode, écrivez le code qui décide si un carton a été produit ou pas, sachant qu'une usine ne peut pas produire plus que un carton toutes les 5 secondes et qu'un peu de hasard intervient généralement dans un processus de fabrication.  
Un message annonçant la production d'un carton est affiché dans la console (`Console.WriteLine`)
1. Créez la classe `Dispatch` qui modélise la centrale de distribution, instanciez-là dans la classe `Airspace`.
2. Créez l'interface `IDispatchable` (mettre le fichier dans `Model`). Cette interface doit permettre:
   - De passer un objet `Box` pour qu'il soit enregistré dans la liste
   - De retirer un objet `Box` de la liste  
  
   A vous de choisir les signatures de ces deux méthodes
3. Déclarez l'implémentation de l'interface `IDispatchable` par la classe `Dispatch`. Faites faire l'implémentation de base de l'interface à Visual Studio (Actions rapides...)
4. Implémentez réellement les méthodes. 
5. La centrale affiche l'annonce d'un carton dans la console
6. Ecrivez un test unitaire qui valide chacune des méthodes implémentée par `Dispatch`

N'hésitez pas à valider le contenu de vos commits avec votre prof ou un de ses assistants.