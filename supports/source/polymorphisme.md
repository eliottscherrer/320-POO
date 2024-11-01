# Polymorphisme

## Qu’est-ce que le polymorphisme ?
Le polymorphisme est un concept de programmation axée objet qui permet de traiter des objets de différents types comme des objets d’une superclasse commune. Elle permet la réutilisation et la flexibilité du code, en permettant à plusieurs classes d’implémenter la même méthode de différentes manières. Ce concept est essentiel pour réaliser l’abstraction et l’encapsulation dans les langages de programmation.

## Comment fonctionne le polymorphisme ?
Le polymorphisme fonctionne en créant une relation entre les classes en utilisant l’héritage. Lorsqu’une superclasse définit une méthode, ses sous-classes peuvent ignorer cette méthode afin de fournir leur propre implémentation. Au moment de l’exécution, la méthode appropriée est appelée en fonction du type réel de l’objet. Cette liaison dynamique permet d’obtenir un code plus flexible et extensible.

## Qu’est-ce qu’un exemple de polymorphisme ?
Bien sûr, disons que nous avons une superclasse appelée Animal avec une méthode makeSound(). Nous pouvons avoir des sous-classes comme Dog, Chat, et Bird qui héritent d’Animal et ignorer la méthode makeSound() avec leur propre implémentation unique. Lorsque vous appelez la méthode makeSound() sur un objet de type Animal, cela appelle l’implémentation spécifique en fonction du type réel de l’objet.

## Quels sont les avantages d’utiliser le polymorphisme ?
L’utilisation du polymorphisme dans la programmation apporte plusieurs avantages. Il favorise la réutilisation du code et la modularité, car les classes peuvent partager des comportements communs à travers l’héritage. Il améliore la flexibilité, permettant d’ajouter de nouvelles sous-classes sans modifier le code existant. Le polymorphisme permet également la création d’algorithmes génériques qui peuvent fonctionner sur des objets de types différents.

## En quoi le polymorphisme est-il différent de l’héritage ?
L’héritage est un mécanisme dans lequel une classe hérite des propriétés et des méthodes d’une autre classe. Elle établit une relation « is-a » entre les classes. D’autre part, le polymorphisme est un concept qui permet de traiter des objets de différentes classes comme des objets d’une superclasse commune. Le polymorphisme établit une relation « as-a », permettant aux objets d’afficher des comportements différents tout en partageant une interface commune.

## Comment le polymorphisme contribue-t-il à la maintenance des codes ?
Le polymorphisme favorise la maintenance du code en réduisant la duplication de code. Avec le polymorphisme, vous pouvez définir une méthode une fois dans une superclasse et toutes ses sous-classes héritent et la remplacent au besoin. Cela élimine le besoin de dupliquer du code sur plusieurs classes, ce qui rend la base de code plus facile à maintenir. De plus, lorsque de nouvelles sous-classes sont ajoutées, le code existant ne nécessitera aucune modification, ce qui garantit la rétrocompatibilité.

## Est-ce que le polymorphisme peut être atteint dans des langages de programmation autres que Java ?
Oui, le polymorphisme n’est pas exclusif à Java. De nombreux langages de programmation orientés objet, tels que C++, Python et C#, supportent le polymorphisme. Bien que la syntaxique et les détails de mise en uvre puissent différer, le concept sous-jacent reste le même. Le polymorphisme est un aspect fondamental de la programmation axée objet et peut être utilisé dans divers langages de programmation.

## Le polymorphisme s’applique-t-il uniquement à la programmation axée objet (OUO) ?
Le polymorphisme est principalement associé aux paradigmes OOP, mais le concept peut également être appliqué à d’autres paradigmes de programmation. En programmation fonctionnelle, par exemple, le polymorphisme peut être atteint par des fonctions d’ordre supérieur ou le polymorphisme paramétrique. Bien que la mise en uvre puisse varier, l’idée centrale de permettre un traitement uniforme d’objets de types différents peut tout de même être réalisée.

## Quel est le lien entre le polymorphisme et l’empêchement des méthodes ?
Le polymorphisme et la primauté des méthodes vont de pair. L’élimination de méthode est le processus consistant à fournir une implémentation différente d’une méthode dans une sous-classe qui est déjà définie dans sa superclasse. Pour ce faire, il est possible d’utiliser la même signature de méthode dans la sous-classe que celle de la superclasse. Le polymorphisme nous permet d’invoquer la méthode prépondérante en fonction du type réel de l’objet, pour s’assurer que la bonne mise en uvre est exécutée.

## Le polymorphisme peut-il se produire avec des méthodes statiques ?
Non, le polymorphisme ne s’applique pas aux méthodes statiques. Les méthodes statiques appartiennent à la classe elle-même et non à des objets individuels. Ils sont résolus en fonction du type de classe et non en fonction du type d’objet au moment de l’exécution. Par conséquent, les méthodes statiques ne peuvent pas être remplacées ou présenter un comportement polymorphique. Lorsque vous appelez une méthode statique, c’est toujours la version définie dans la classe dans laquelle elle est déclarée qui est exécutée.

## Qu’est-ce que le polymorphisme de compilation ?
Le polymorphisme de compilation (aussi connu sous le nom de surcharge de méthode) est une forme de polymorphisme dans laquelle plusieurs méthodes du même nom, mais des paramètres différents sont définis au sein d’une classe. La méthode appropriée à invoquer est déterminée par le compilateur en fonction du nombre, des types et de l’ordre des arguments transmis lors de l’invocation de méthode. Cela permet différents comportements en fonction de l’entrée fournie, ce qui permet une flexibilité et une lisibilité du code.

## Comment le polymorphisme est-il utile dans le développement de logiciels ?
Le polymorphisme joue un rôle crucial dans le développement de logiciels en favorisant la réusabilité, la modularité et l’extensibilité du code. Elle permet aux développeurs d’écrire un code générique pouvant fonctionner sur divers types d’objets, réduisant ainsi la redondance et améliorant l’efficacité. Le polymorphisme permet la création de systèmes flexibles et adaptables, ce qui facilite la maintenance et l’amélioration des logiciels au fil du temps.

## Le polymorphisme a-t-il un impact sur la performance ?
Le polymorphisme peut avoir un léger impact sur la performance par rapport aux appels de méthode directs. Cela s’explique par le fait que les invocations par méthode polymorphique impliquent un niveau supplémentaire d’indirection et de liaison dynamique, ce qui peut introduire une certaine surcharge. Cependant, les compilateurs modernes et les systèmes d’exécution ont des optimisations en place pour minimiser cet impact, le rendant négligeable dans la plupart des cas. Les avantages de la flexibilité du code et de la facilité de maintenance l’emportent souvent sur tous les problèmes mineurs de performance.

## Quel est le rapport entre le polymorphisme et l’abstraction ?
Le polymorphisme et l’abstraction sont des concepts étroitement liés dans la programmation orientée-objet. L’abstraction se réfère au processus de représenter des entités complexes du monde réel comme des modèles simplifiés dans le code. Le polymorphisme permet de traiter les objets à un niveau plus élevé d’abstraction, où ils sont considérés comme des instances d’une superclasse ou interface commune. Cette séparation entre l’implémentation spécifique et le comportement général permet d’écrire le code d’une manière plus modulaire et flexible.

## Le polymorphisme peut-il être atteint sans héritage ?
Bien que le polymorphisme soit communément associé à l’héritage, il n’est pas uniquement dépendant de lui. Le polymorphisme peut également être obtenu par le biais d’interfaces ou de classes abstraites, où plusieurs classes non apparentées implémentent une interface commune ou étendent la même classe abstraite. Cela permet de traiter uniformément des objets de types différents, offrant les avantages du polymorphisme sans dépendre de la hiérarchie des classes.

## Comment le polymorphisme contribue-t-il à la lisibilité du code ?
Le polymorphisme améliore la lecture du code en favorisant la réutilisation du code et en éliminant les redondances. Avec le polymorphisme, vous pouvez écrire du code générique qui fonctionne sur des objets de différents types sans avoir besoin de connaître leurs implémentations spécifiques. Ceci permet d’obtenir un code plus court et plus concis qui est plus facile à comprendre et à entretenir. Le polymorphisme améliore également la lisibilité du code en permettant une meilleure organisation et une meilleure encapsulation des comportements connexes.


_<small>source: [site Lenovo](https://canada.lenovo.com/fr/ca/en/glossary/polymorphism/?orgRef=https%253A%252F%252Fwww.google.com%252F)</small>_