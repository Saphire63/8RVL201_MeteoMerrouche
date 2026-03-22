# 8RVL201_MeteoMerrouche
MERT21030600
Projet fil rouge S4 Canada
## Environnement développement
Unity

## Description du projet
Le but de ce projet est de faire une application en VR ou réalité augmentée afin de consulter la météo 
### Idée personnelle:
J'ai décidé de représenté cette application par un environnement en VR immersif en fonction de la température actuelle.
L'idée est de faire plusieurs scènes par exemple une scène été(plage) et une scène hiver(neige) et en fonction de la température exterieur, ici j'ai fait en sorte que si il fait plus de 10 degrés alors la scène été est activée sinon c'est la scène hiver qui est active.

## Fonctionnalitées
Afficher la température sur un panneau apparaîssant si on clique sur l'artefact.
Charger le bon environnement en fonction de la température récoltée dans l'api.
Pouvoir changer de scène en cliquant sur un bouton.
Pouvoir ce déplacer en ce téléportant/en continue et pouvoir bouger la tête soit par snap turn soit par déplacement avec le casque.

## Réalisation
Création d'une scène partagé appelée CoreScene pour avoir la même caméra, controllers, etc -> non duplication d'éléments ou de code.
Création des controllers avec XR Interaction toolkit permettant d'avoir des mannettes préfaite.
Ajout des movement dans l'objet Locomotion avec XR Interaction toolkit permettant d'inclure des mouvement asser facilement.
Ajout des interactions avec les objets j'ai choisis de ne pas pouvoir grab mais seulement cliquer sur l'artefact ce qui affiche le canvas et active le ray interactor pour pouvoir agir avec le canvas.
Création d'un script pour récupérer l'api de la météo et ajouter une variable temp(température) pour avoir un affichage de la température dans le canvas.
Ce script sert aussi pour changer la scène au chargement de l'appli.
Ajout d'effets notemment de la neige crée à partir d'un png et à partir de particules.
Création d'un script gérant la lumière en fonction de la scène pour rendre plus immersif.

