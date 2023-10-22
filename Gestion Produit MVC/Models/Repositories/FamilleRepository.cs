namespace Gestion_Produit_MVC.Models.Repositories
{
    public class FamilleRepository : IRepository<Famille>
    {
        public IList<Famille> familles { get; set; }
        public FamilleRepository()
        {
            familles = new List<Famille>()
            {
                new Famille()
                {
                    id = 1,
                    nom="Imprimantes"
                },
                new Famille()
                {
                    id = 2,
                    nom="PC"
                },
                new Famille()
                {
                    id = 3,
                    nom="Caméra"
                },
            };
        }
        public void Ajouter(Famille element)
        {
            element.id = familles.Max(i => i.id) + 1;
            familles.Add(element);
        }

        public IList<Famille> Lister()
        {
            return familles;
        }

        public Famille ListerSelonId(int id)
        {
            return familles.Single(x => x.id == id);    
        }

        public void Modifier(int id, Famille element)
        {
            var ancienneFamille = ListerSelonId(id);
            ancienneFamille.nom = element.nom;

        }

        public void Supprimer(int id)
        {
            var famille = ListerSelonId(id);
            familles.Remove(famille);
        }
    }
}
