# ASP.Net MVC - Exercice 02
Réaliser une site de gestion d'apprenants

## Contraintes
- Partir d'une nouvelle solution.
- Utilisation de services pour les données
  - Des interfaces sont fournis :smile:
  - Il n'y a pas d'acces à une base de donnée (Liste statique).
- Les pages doivent être créer en utilisant le scalfolding (et customisé)
- L'utilisation de git est obligatoire
- Les fichiers static (image, css, etc...) doivent être placer dans « wwwroot »

## Fontionnalitées
- Accueil
- Apprenants
  - Consulter la liste
  - Ajouter ou supprimer un apprenant
  - Voir le detail d'un apprenant
- Salle _(BONUS)_
  - Visualiser les appreants placé
  - Affecter un apprenant à une place
    
## Information technique
### Interface du service
```cs
public interface IStudentService {
  public IEnumerable<Student> GetAll();
  public Student? GetById(int id);
  public int Add(Student data);
  public void Delete(int id); // StudentFailDeletedException
}

public interface IClassroomService {
  public Classroom Get();
  public void Affect(Student student, int place);
  public void Eject(int place);
}
```

### Modele de donnée
La page détail d'un apprenant doit afficher comme donnée :
- Leur prénom et nom.
- Date de naissance.
- Leur age.
- Information complémentaire, si présent.
- S'il a recu un blame.
## Information complémentaire
La demande du client peut évoluer à tout moment.
