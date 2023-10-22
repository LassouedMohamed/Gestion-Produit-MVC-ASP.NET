namespace Gestion_Produit_MVC.Models.Repositories
{
    public class ProduitRepository : IRepository<Produit>
    {
        public IList<Produit> produits{ get; set; }
        public ProduitRepository()
        {
            produits = new List<Produit>()
            {
                new Produit()
                {
                    id = 1,
                    reference ="EL1110",
                    designation = "EPSON ECOTANK L1110",
                    description = "Imprimante Jet d'encre ...",
                    disponible = true,
                    famille = new Famille()
                    {
                        id=1,
                        nom = "Imprimante"
                    }
                },
                new Produit()
                {
                    id = 2,
                    reference ="EL3110",
                    designation = "EPSON ECOTANK L3110",
                    description = "Imprimante Jet d'encre avec Wifi ...",
                    disponible = true,
                    famille = new Famille()
                    {
                        id=1,
                        nom = "Imprimante"
                    }
                },
                new Produit()
                {
                    id = 3,
                    reference ="CANON250D",
                    designation = "CANON 250D",
                    description = "Caméra pour débutants...",
                    disponible = true,
                    famille = new Famille()
                    {
                        id=3,
                        nom = "Caméra"
                    }
                },
            };
        }
        public void Ajouter(Produit element)
        {
            element.id = produits.Max(i => i.id)+1;
            produits.Add(element);
        }

        public IList<Produit> Lister()
        {
            return produits;
        }

        public Produit ListerSelonId(int id)
        {
            return produits.Single(p => p.id == id);
        }

        public void Modifier(int id, Produit element)
        {
            var ancienProduit = ListerSelonId(id);
            ancienProduit.reference = element.reference;
            ancienProduit.designation = element.designation;
            ancienProduit.description = element.description;
            ancienProduit.disponible = element.disponible;
            ancienProduit.famille = element.famille;   
        }

        public void Supprimer(int id)
        {
            var produit = ListerSelonId(id);
            produits.Remove(produit);
        }
    }
}
