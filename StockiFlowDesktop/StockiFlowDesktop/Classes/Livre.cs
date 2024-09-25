using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace StockiFlowDesktop.Classes
{
    public class Livre
    {
        private string ISBN;
        private string titre;
        private int nombrePages;
        private float poids;
        private float prixInitial;
        private float hauteur;
        private float largeur;
        private string commentaire;
        private string synopsys;
        private DateTime DateSortie;
        private Etat etatLivre;
        private TypeLivre leType;
        private List<Auteur> lesAuteurs;
        private List<Genre> lesGenres;
        private List<Editeur> lesEditeurs;



        public Livre() { }

        public Livre(string _ISBN, string _titre, int _nombrePages, float _poids, float _prixInitial, float _hauteur, float _largeur, string _commentaire, string _synopsys, DateTime _dateSortie, Etat _etatLivre, TypeLivre _LeType, List<Auteur> _listeAuteur, List<Genre> _ListeGenre , List<Editeur> _listeEditeur)
        {
            this.ISBN = _ISBN;
            this.titre = _titre;
            this.nombrePages = _nombrePages;
            this.poids = _poids;
            this.prixInitial = _prixInitial;
            this.hauteur = _hauteur;
            this.largeur = _largeur;
            this.commentaire = _commentaire;
            this.synopsys = _synopsys;
            this.DateSortie = _dateSortie;
            this.etatLivre = _etatLivre;
            this.leType = _LeType;
            this.lesAuteurs = _listeAuteur;
            this.lesGenres = _ListeGenre;
            this.lesEditeurs = _listeEditeur;
        }


        //Getter 
        public string GetISBN() { return this.ISBN; }
        public string GetTitre() { return this.titre; }
        public int GetNombrePages() { return this.nombrePages; }
        public float GetPoids() { return this.poids; }
        public float GetPrixInitial() { return this.prixInitial; }
        public float GetHauteur() { return this.hauteur; }
        public float GetLargeur() { return this.largeur; }
        public string GetCommentaire() { return this.commentaire; }
        public string GetSynopsys() { return this.synopsys; }
        public DateTime GetDateSortie() { return this.DateSortie; }
        public Etat GetEtat() { return this.etatLivre; }
        public TypeLivre GetLeType() {return this.leType;}
        public List<Auteur> GetLesAuteurs() { return this.lesAuteurs; }
        public List<Genre> GetLesGenres() { return this.lesGenres; }
        public List<Editeur> GetLesEditeurs() { return this.lesEditeurs; }


        //Setter
        public void SetISBN(string _ISBN) { this.ISBN = _ISBN; }
        public void SetTitre(string _titre) { this.titre = _titre; }
        public void SetNombrePages(int _NombresPages) { this.nombrePages = _NombresPages; }
        public void SetPoids(float _poids) { this.poids = _poids; }
        public void SetPrixInitial(float _prix) { this.prixInitial = _prix; }
        public void SetHauteur(float _hauteur) { this.hauteur = _hauteur; }
        public void SetLargeur(float _largeur) { this.largeur = _largeur; }
        public void SetCommentaire(string _commentaire) { this.commentaire = _commentaire; }
        public void SetSynopsys(string _synopsys) { this.synopsys = _synopsys; }
        public void SetDateSortie(DateTime _datesortie) { this.DateSortie = _datesortie; }
        public void SetEtat(Etat _etatLivre) { this.etatLivre = _etatLivre; }
        public void SetLeType(TypeLivre _type) { this.leType = _type; }
        public void SetLesAuteurs(List<Auteur> _listeAuteurs) { this.lesAuteurs = _listeAuteurs; }
        public void SetLesGenres(List<Genre> _listeGenres) { this.lesGenres = _listeGenres; }
        public void SetLesEditeurs(List<Editeur> _listeEditeurs) { this.lesEditeurs = _listeEditeurs; }





        /*     CRUD     */
        public void CreateLivre()
        {

            string req_create = "insert into livre values('" + this.GetISBN() + "','" + this.GetTitre() + "','" + this.GetNombrePages() + "','" + this.GetPoids().ToString().Replace(',', '.') + "','" + this.GetPrixInitial().ToString().Replace(',', '.') + "','" + this.GetHauteur().ToString().Replace(',', '.') + "','" + this.GetLargeur().ToString().Replace(',', '.') + "','" + this.GetCommentaire() + "','" + this.GetSynopsys() + "','" + this.GetDateSortie().ToString() + "','" + this.GetEtat().GetIdEtat() + "','" + this.GetLeType().GetIdTypeLivre() + "')";
            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);
            Global.conn.Open();
            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
                
        }




        public void RetrieveLivre(string _ISBN)
        {
            string req_FindAll = "Select li.ISBN as ISBN , titre , nombrePages , poids , prixInitial , hauteur , largeur , commentaire , synopsys, DateSortie , idEtat, idTypeLivre, idAuteur, idGenre, idEditeur from livre li left join Definir de on de.ISBN = li.ISBN left join Editer ed on ed.ISBN = li.ISBN left join Ecrire ec on ec.ISBN = li.ISBN where li.ISBN = " + this.GetISBN();
            MySqlCommand stmt_FindAll = new MySqlCommand(req_FindAll, Global.conn);
            Global.conn.Open();
            using (MySqlDataReader reader = stmt_FindAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Init variable nécessaire poiur le constructeur (objet externe)
                    Livre livre_temp = new Livre();

                    Etat etat_temp = new Etat();
                    TypeLivre type_temp = new TypeLivre();
                    

                    Auteur auteur_temp = new Auteur();
                    Editeur editeur_temp = new Editeur();            
                    Genre genre_temp = new Genre();

                    List<Auteur> listeAuteur_temp = new List<Auteur>(); 
                    List<Editeur> listeEditeur_temp = new List<Editeur>();   
                    List<Genre> listeGenre_temp = new List<Genre>();

                    
                    // A chaque ligne on retrieve l'auteur l'editeur et le genre et on l'ajoute à la collections d'objets
                    auteur_temp.RetrieveAuteur(int.Parse(reader["idAuteur"].ToString()));
                    editeur_temp.RetrieveEditeur(int.Parse(reader["idEditeur"].ToString()));
                    genre_temp.RetrieveGenre(int.Parse(reader["idGenre"].ToString()));

                    // Ajout dans les collections d'objets des objets recuperer
                    listeAuteur_temp.Add(auteur_temp);
                    listeEditeur_temp.Add(editeur_temp);
                    listeGenre_temp.Add(genre_temp);



                    // Récupération des objets par le biais de la clé étrangère dans la table                
                    etat_temp.RetrieveEtat(int.Parse(reader["idEtat"].ToString()));
                    type_temp.RetrieveTypeLivre(int.Parse(reader["idTypeLivre"].ToString()));



                    livre_temp.SetISBN(reader["ISBN"].ToString());
                    livre_temp.SetTitre(reader["titre"].ToString());
                    livre_temp.SetNombrePages(int.Parse(reader["nombrePages"].ToString()));
                    livre_temp.SetPoids(float.Parse(reader["poids"].ToString()));
                    livre_temp.SetPrixInitial(float.Parse(reader["prixInitial"].ToString()));
                    livre_temp.SetHauteur(float.Parse(reader["hauteur"].ToString()));
                    livre_temp.SetLargeur(float.Parse(reader["largeur"].ToString()));
                    livre_temp.SetCommentaire(reader["commentaire"].ToString());
                    livre_temp.SetSynopsys(reader["synopsys"].ToString());
                    livre_temp.SetDateSortie(DateTime.Parse(reader["DateSortie"].ToString()));



                    livre_temp.SetEtat(etat_temp);
                    livre_temp.SetLeType(type_temp);

                    livre_temp.SetLesAuteurs(listeAuteur_temp);
                    livre_temp.SetLesEditeurs(listeEditeur_temp);
                    livre_temp.SetLesGenres(listeGenre_temp);
                }
            }
            Global.conn.Close();
        }







        public void UpdateLivre()
        {
            string req_update = "update Livre set titre = @titre, NombrePages = @nombrepages,poids = @poids, prixInitial = @prixInitial , hauteur = @hauteur , largeur = @largeur, commentaire = @commentaire , Synopsis = @synopsys idEtat = @idEtat where ISBN = @ISBN";
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);

            stmt_update.Parameters.AddWithValue("@titre", this.GetTitre());
            stmt_update.Parameters.AddWithValue("@poids", this.GetPoids());
            stmt_update.Parameters.AddWithValue("@prixInitial", this.GetPrixInitial());
            stmt_update.Parameters.AddWithValue("@hauteur", this.GetHauteur());
            stmt_update.Parameters.AddWithValue("@largeur", this.GetLargeur());
            stmt_update.Parameters.AddWithValue("@commentaire", this.GetCommentaire());
            stmt_update.Parameters.AddWithValue("@synopsys", this.GetSynopsys());
            stmt_update.Parameters.AddWithValue("@idEtat", this.GetEtat().GetIdEtat());
            stmt_update.Parameters.AddWithValue("@ISBN", this.GetISBN());

            Global.conn.Open();

            stmt_update.ExecuteNonQuery();
            Global.conn.Close();
        }





        public void DeleteLivre()
        {
            string req_delete = "delete from livre where ISBN = " + this.GetISBN();
            MySqlCommand stmt_delete = new MySqlCommand(req_delete, Global.conn);
            Global.conn.Open();

            stmt_delete.ExecuteNonQuery();
            Global.conn.Close();
            
        }




        // Méthode FindAllLivre qui prend en paramètre un booleen => si il est à true alors on rajoute un pattern à la requête SQL => Evite de faire une fonction dedier
        public List<Livre> FindAllLivre(bool isRecherche , string? pattern)
        {
            List<Livre> CollectionLivres = new List<Livre>();

            //Dictionnaire qui va enregister et vérifier si un livre à deja etait enregister => permet une meilleur organisation notamment à cause des collections d'objets
            Dictionary<string, Livre> livresMap = new Dictionary<string, Livre>(); 

            string req_FindAll = "Select li.ISBN as ISBN, titre, nombrePages, poids, prixInitial, hauteur, largeur, commentaire, synopsys, DateSortie, idEtat, idTypeLivre, ec.idAuteur, de.idGenre, ed.idEditeur from livre li left join Definir de on de.ISBN = li.ISBN left join Editer ed on ed.ISBN = li.ISBN left join Ecrire ec on ec.ISBN = li.ISBN";
            
            //Si isRecherche est sur true alors l'utilisateur recherche un livre en particulier par titre => on rajoute un pattern à la requête
            if (isRecherche)
            {
                req_FindAll += "  where titre like '%" + pattern + "%';";
            }
            
            MySqlCommand stmt_FindAll = new MySqlCommand(req_FindAll, Global.conn);
            Global.conn.Open();


            using (MySqlDataReader reader = stmt_FindAll.ExecuteReader())
            {
                while (reader.Read())
                {

                    string currentISBN = reader["ISBN"].ToString();
                    Livre livre_temp;

                    // Si le livre n'a pas encore été ajouté, on le crée
                    if (!livresMap.ContainsKey(currentISBN))
                    {
                        livre_temp = new Livre();

                        Etat etat_temp = new Etat();
                        TypeLivre type_temp = new TypeLivre();

                        livre_temp.SetISBN(currentISBN);
                        livre_temp.SetTitre(reader["titre"].ToString());
                        livre_temp.SetNombrePages(int.Parse(reader["nombrePages"].ToString()));
                        livre_temp.SetPoids(float.Parse(reader["poids"].ToString()));
                        livre_temp.SetPrixInitial(float.Parse(reader["prixInitial"].ToString()));
                        livre_temp.SetHauteur(float.Parse(reader["hauteur"].ToString()));
                        livre_temp.SetLargeur(float.Parse(reader["largeur"].ToString()));
                        livre_temp.SetCommentaire(reader["commentaire"].ToString());
                        livre_temp.SetSynopsys(reader["synopsys"].ToString());
                        livre_temp.SetDateSortie(DateTime.Parse(reader["DateSortie"].ToString()));

                        etat_temp.RetrieveEtat(int.Parse(reader["idEtat"].ToString()));
                        type_temp.RetrieveTypeLivre(int.Parse(reader["idTypeLivre"].ToString()));

                        livre_temp.SetEtat(etat_temp);
                        livre_temp.SetLeType(type_temp);

                        // Initialise les listes d'auteurs, éditeurs et genres
                        livre_temp.SetLesAuteurs(new List<Auteur>());
                        livre_temp.SetLesGenres(new List<Genre>());
                        livre_temp.SetLesEditeurs(new List<Editeur>());

                        // Ajoute le livre à la collection temporaire
                        livresMap.Add(currentISBN, livre_temp);
                    }

                    // Si le livre existe déjà, on le récupère
                    else
                    {
                        livre_temp = livresMap[currentISBN];
                    }


                    // Dans tout les cas, on ajoute les auteurs, éditeurs, genres s'ils ne sont pas déjà dans la liste
                    Auteur auteur_temp = new Auteur();
                    auteur_temp.RetrieveAuteur(int.Parse(reader["idAuteur"].ToString()));
                    livre_temp.GetLesAuteurs().Add(auteur_temp);
                    
                

                    Editeur editeur_temp = new Editeur();
                    editeur_temp.RetrieveEditeur(int.Parse(reader["idEditeur"].ToString()));
                    livre_temp.GetLesEditeurs().Add(editeur_temp);
                    
                
                
                    Genre genre_temp = new Genre();
                    genre_temp.RetrieveGenre(int.Parse(reader["idGenre"].ToString()));
                    livre_temp.GetLesGenres().Add(genre_temp);
                    
                
                }
            }
            Global.conn.Close();

            // Ajout des livres de la map à la collection finale
            CollectionLivres.AddRange(livresMap.Values);

            return CollectionLivres;
        }    
    }
}
