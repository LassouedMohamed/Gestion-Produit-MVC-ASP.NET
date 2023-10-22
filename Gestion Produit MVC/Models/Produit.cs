namespace Gestion_Produit_MVC.Models
{
    public class Produit
    {
        public int id{ get; set; }
        public string reference{ get; set; }
        public string designation{ get; set; }
        public string description{ get; set; }
        public bool disponible{ get; set; }
        public Famille famille { get; set; }
    }
}
