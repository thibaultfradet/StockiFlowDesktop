using System.ComponentModel;
using System.Runtime.CompilerServices;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;

namespace StockiFlowDesktop.Classes
{
    public class Livre
    {
        private string ISBN;
        private string titre;
        private int nombrePages;
        private float poids;        // en kg
        private float prixInitial;  // en euro €
        private float hauteur;      // en cm
        private float largeur;      // en cm
        private string commentaire;
        private string synopsys;
        private DateTime DateSortie;
        private TypeLivre leType;
        private List<Auteur> lesAuteurs;
        private List<Genre> lesGenres;
        private List<Editeur> lesEditeurs;
        private int stock;



        public Livre() { }

        public Livre(string _ISBN, string _titre, int _nombrePages, float _poids, float _prixInitial, float _hauteur, float _largeur, string _commentaire, string _synopsys, DateTime _dateSortie, TypeLivre _LeType, List<Auteur> _listeAuteur, List<Genre> _ListeGenre , List<Editeur> _listeEditeur, int _stock)
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
            this.leType = _LeType;
            this.lesAuteurs = _listeAuteur;
            this.lesGenres = _ListeGenre;
            this.lesEditeurs = _listeEditeur;
            this.stock = _stock;
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
        public TypeLivre GetLeType() {return this.leType;}
        public List<Auteur> GetLesAuteurs() { return this.lesAuteurs; }
        public List<Genre> GetLesGenres() { return this.lesGenres; }
        public List<Editeur> GetLesEditeurs() { return this.lesEditeurs; }
        public int GetStock() { return this.stock; }


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
        public void SetLeType(TypeLivre _type) { this.leType = _type; }
        public void SetLesAuteurs(List<Auteur> _listeAuteurs) { this.lesAuteurs = _listeAuteurs; }
        public void SetLesGenres(List<Genre> _listeGenres) { this.lesGenres = _listeGenres; }
        public void SetLesEditeurs(List<Editeur> _listeEditeurs) { this.lesEditeurs = _listeEditeurs; }
        public void setStock(int _stock) { this.stock = _stock; }





        /*     CRUD     */
        public void CreateLivre()
        {

            List<Auteur> lesAuteurs = this.GetLesAuteurs();
            List<Genre> lesGenres = this.GetLesGenres();
            List<Editeur> lesEditeurs = this.GetLesEditeurs();

            // par défaut on met le stock à 0
            string req_create = "insert into livre values('" + this.GetISBN() + "','" + this.GetTitre() + "','" + this.GetNombrePages() + "','" + this.GetPoids().ToString().Replace(',', '.') + "','" + this.GetPrixInitial().ToString().Replace(',', '.') + "','" + this.GetHauteur().ToString().Replace(',', '.') + "','" + this.GetLargeur().ToString().Replace(',', '.') + "','" + this.GetCommentaire() + "','" + this.GetSynopsys() + "','" + this.GetDateSortie().ToString("yyyy-MM-dd") + "','" + this.GetLeType().GetIdTypeLivre() + "',0);";
            // On ajoute dans la requete d'autres requete pour ajouter aux tables intermediaire les valeurs pour lier => listes
            foreach (Auteur a in lesAuteurs)
            {
                req_create += "insert into Ecrire values('" + this.GetISBN() + "','" + a.GetIdAuteur() + "');";
            }
            foreach (Genre g in lesGenres)
            {
                req_create += "insert into Definir values('" + this.GetISBN() + "','" + g.GetIdGenre() + "');";
            }
            foreach (Editeur e in lesEditeurs)
            {
                req_create += "insert into editer values('" + this.GetISBN() + "','" + e.GetIdEditeur() + "');";
            }



            MySqlCommand stmt_create = new MySqlCommand(req_create, Global.conn);
            Global.conn.Open();
            stmt_create.ExecuteNonQuery();
            Global.conn.Close();
                
        }




        public void RetrieveLivre(string _ISBN)
        {

            // variable pour recuperer des objets externe apres la requete principale
            List<int> liste_IDauteurs = new List<int>();
            List<int> liste_IDediteurs = new List<int>();
            List<int> liste_IDgenres = new List<int>();

            int idType = -1;


            string req_Retrieve = "Select li.ISBN as ISBN , titre , nombrePages , poids , prixInitial , hauteur , largeur , commentaire , synopsys, DateSortie,stock , idTypeLivre, idAuteur, idGenre, idEditeur from livre li left join Definir de on de.ISBN = li.ISBN left join Editer ed on ed.ISBN = li.ISBN left join Ecrire ec on ec.ISBN = li.ISBN where li.ISBN = '" + _ISBN + "'";
            MySqlCommand stmt_Retrieve = new MySqlCommand(req_Retrieve, Global.conn);


            Global.conn.Open();


            using (MySqlDataReader reader = stmt_Retrieve.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<Auteur> liste_auteurs_temp = new List<Auteur>();
                    List<Editeur> liste_editeurs_temp = new List<Editeur>();
                    List<Genre> liste_genres_temp = new List<Genre>();
                    
                    
                    //Récupérations des id d'auteur/editeur et genre si elles ne sont pas deja dans la liste
                    if (liste_IDauteurs.Contains(int.Parse(reader["idAuteur"].ToString())) == false)
                    {
                        liste_IDauteurs.Add(int.Parse(reader["idAuteur"].ToString()));
                    }
                    if (liste_IDediteurs.Contains(int.Parse(reader["idEditeur"].ToString())) == false)
                    {
                        liste_IDediteurs.Add(int.Parse(reader["idEditeur"].ToString()));
                    }
                    if (liste_IDgenres.Contains(int.Parse(reader["idGenre"].ToString())) == false)
                    {
                        liste_IDgenres.Add(int.Parse(reader["idGenre"].ToString()));
                    }




                    // Récupération des objets par le biais de la clé étrangère dans la table                
              
                    idType = int.Parse(reader["idTypeLivre"].ToString());



                    this.SetISBN(reader["ISBN"].ToString());
                    this.SetTitre(reader["titre"].ToString());
                    this.SetNombrePages(int.Parse(reader["nombrePages"].ToString()));
                    this.SetPoids(float.Parse(reader["poids"].ToString()));
                    this.SetPrixInitial(float.Parse(reader["prixInitial"].ToString()));
                    this.SetHauteur(float.Parse(reader["hauteur"].ToString()));
                    this.SetLargeur(float.Parse(reader["largeur"].ToString()));
                    this.SetCommentaire(reader["commentaire"].ToString());
                    this.SetSynopsys(reader["synopsys"].ToString());
                    this.SetDateSortie(DateTime.Parse(reader["DateSortie"].ToString()));
                    this.setStock(int.Parse(reader["stock"].ToString()));

                    this.SetLesAuteurs(liste_auteurs_temp);
                    this.SetLesEditeurs(liste_editeurs_temp);
                    this.SetLesGenres(liste_genres_temp);


                }
                Global.conn.Close();
            }

            // on recupère les objets externe
            foreach (int idA in liste_IDauteurs)
            {
                Auteur auteur_temp = new Auteur();
                auteur_temp.RetrieveAuteur(idA);
                List<Auteur> listeAuteur_temp = this.GetLesAuteurs();
                listeAuteur_temp.Add(auteur_temp);
                this.SetLesAuteurs(listeAuteur_temp);                
            }
            foreach (int idE in liste_IDediteurs)
            {
                Editeur editeur_temp = new Editeur();
                editeur_temp.RetrieveEditeur(idE);
                List<Editeur> listeEditeur_temp = this.GetLesEditeurs();
                listeEditeur_temp.Add(editeur_temp);
                this.SetLesEditeurs(listeEditeur_temp);
            }
            foreach (int idG in liste_IDgenres)
            {
                Genre genre_temp = new Genre();
                genre_temp.RetrieveGenre(idG);
                List<Genre> listeGenre_temp = this.GetLesGenres();
                listeGenre_temp.Add(genre_temp);
                this.SetLesGenres(listeGenre_temp);
            }


            TypeLivre typeLivre_temp = new TypeLivre();
            typeLivre_temp.RetrieveTypeLivre(idType);
            this.SetLeType(typeLivre_temp);
        }







        public void UpdateLivre()
        {
            string req_update = "update Livre set titre = @titre, NombrePages = @nombrepages,poids = @poids, prixInitial = @prixInitial , hauteur = @hauteur , largeur = @largeur, commentaire = @commentaire , Synopsis = @synopsys, stock = @stock  where ISBN = @ISBN";
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);

            stmt_update.Parameters.AddWithValue("@titre", this.GetTitre());
            stmt_update.Parameters.AddWithValue("@poids", this.GetPoids());
            stmt_update.Parameters.AddWithValue("@prixInitial", this.GetPrixInitial());
            stmt_update.Parameters.AddWithValue("@hauteur", this.GetHauteur());
            stmt_update.Parameters.AddWithValue("@largeur", this.GetLargeur());
            stmt_update.Parameters.AddWithValue("@commentaire", this.GetCommentaire());
            stmt_update.Parameters.AddWithValue("@synopsys", this.GetSynopsys());
            stmt_update.Parameters.AddWithValue("@ISBN", this.GetISBN());
            stmt_update.Parameters.AddWithValue("@stock", this.GetStock());

            Global.conn.Open();

            stmt_update.ExecuteNonQuery();
            Global.conn.Close();
        }



        /* UpdateStockLivre qui ne modifie que le stock du livre pour éviter de ralentir le programme => beaucoup de paramètres */
        public void UpdateStockLivre()
        {
            string req_update = "update Livre set  stock = @stock where ISBN = @ISBN";
            MySqlCommand stmt_update = new MySqlCommand(req_update, Global.conn);

            stmt_update.Parameters.AddWithValue("@ISBN", this.GetISBN());
            stmt_update.Parameters.AddWithValue("@stock", this.GetStock());

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
        public List<Livre> FindAllLivre(bool isRecherche, string? pattern)
        {

            List<Livre> CollectionLivres = new List<Livre>();

            // Dictionnaire pour stocker les livres et leurs associations
            Dictionary<string, Livre> livresMap = new Dictionary<string, Livre>();

            // Dictionnaires pour stocker les IDs d'auteurs, éditeurs, genres
            Dictionary<string, List<int>> DicoIdAuteur = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> DicoIdEditeur = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> DicoIdGenre = new Dictionary<string, List<int>>();

            Dictionary<string, int> DicoIdType = new Dictionary<string, int>();

            string req_FindAll = @"
                SELECT 
                    li.ISBN AS ISBN, 
                    titre, 
                    nombrePages, 
                    poids, 
                    prixInitial, 
                    hauteur, 
                    largeur, 
                    commentaire, 
                    synopsys, 
                    DateSortie, 
                    idTypeLivre,
                    stock, 
                    ec.idAuteur AS idAuteur, 
                    de.idGenre AS idGenre, 
                    ed.idEditeur AS idEditeur
                FROM livre li
                LEFT JOIN Definir de ON de.ISBN = li.ISBN
                LEFT JOIN Editer ed ON ed.ISBN = li.ISBN
                LEFT JOIN Ecrire ec ON ec.ISBN = li.ISBN
            ";


            // Ajoute une condition de recherche si nécessaire
            if (isRecherche)
            {
                req_FindAll += " where titre like '%" + pattern + "%';";
            }

            MySqlCommand stmt_FindAll = new MySqlCommand(req_FindAll, Global.conn);
            Global.conn.Open();

            using (MySqlDataReader reader = stmt_FindAll.ExecuteReader())
            {
                while (reader.Read())
                {
                    string currentISBN = reader["ISBN"].ToString();
                    Livre livre_temp;


                    // Si le livre est deja present dans le dictionnaire
                    if (livresMap.ContainsKey(currentISBN) == false)
                    {
                        //Liste vide pour les auteurs, editeurs, genres
                        List<Auteur> lesAuteurs = new List<Auteur>();
                        List<Editeur> lesEditeurs = new List<Editeur>();
                        List<Genre> lesGenres = new List<Genre>();


                        livre_temp = new Livre();
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
                        livre_temp.setStock(int.Parse(reader["stock"].ToString()));

                        livre_temp.SetLesAuteurs(lesAuteurs);
                        livre_temp.SetLesEditeurs(lesEditeurs);
                        livre_temp.SetLesGenres(lesGenres);


                        livresMap.Add(currentISBN, livre_temp);
                    }





                    // PARTIE ID AUTEUR EDITEUR ET GENRE

                    // Si aucun auteur/editeur/genre n'a jamais ete mis pour l'isbn actuel alors on créer une liste qui va ajouter avoir les id sinon elle existe deja donc on rajoute les id de la boucle
                    if (DicoIdAuteur.ContainsKey(currentISBN) == false)
                    {
                        DicoIdAuteur[currentISBN] = new List<int>();
                    }
                    //Dans touts les cas on ajoute a la liste
                    DicoIdAuteur[currentISBN].Add(int.Parse(reader["idAuteur"].ToString()));
                    

                    if (DicoIdEditeur.ContainsKey(currentISBN) == false)
                    {
                        DicoIdEditeur[currentISBN] = new List<int>();
                    }
                    //Dans touts les cas on ajoute a la liste
                    DicoIdEditeur[currentISBN].Add(int.Parse(reader["idEditeur"].ToString()));
                    

                    if (DicoIdGenre.ContainsKey(currentISBN) == false)
                    {
                        DicoIdGenre[currentISBN] = new List<int>();
                    }
                    //Dans touts les cas on ajoute a la liste
                    DicoIdGenre[currentISBN].Add(int.Parse(reader["idGenre"].ToString()));




                    //On fais la même chose pour le type du livre
                    
                    if (DicoIdType.ContainsKey(currentISBN) == false)
                    {
                        DicoIdType[currentISBN] = int.Parse(reader["idTypeLivre"].ToString());
                    }

                }
            }

            Global.conn.Close();


            // Maintenant que nous avons collecté tous les IDs, récupérons les objets associés
            foreach (string isbn in livresMap.Keys)
            {
                Livre livre = livresMap[isbn];

                // Récupère les auteurs
                foreach (int auteurId in DicoIdAuteur[isbn])
                {
                    Auteur auteur_temp = new Auteur();
                    auteur_temp.RetrieveAuteur(auteurId);
                    List<Auteur> listeAuteur_temp = livre.GetLesAuteurs();
                    listeAuteur_temp.Add(auteur_temp);
                    livre.SetLesAuteurs(listeAuteur_temp);
                }

                // Récupère les éditeurs
                foreach (var editeurId in DicoIdEditeur[isbn])
                {
                    Editeur editeur_temp = new Editeur();
                    editeur_temp.RetrieveEditeur(editeurId);
                    List<Editeur> listeEditeur_temp = livre.GetLesEditeurs();
                    listeEditeur_temp.Add(editeur_temp);
                    livre.SetLesEditeurs(listeEditeur_temp);
                }

                // Récupère les genres
                foreach (var genreId in DicoIdGenre[isbn])
                {
                    Genre genre_temp = new Genre();
                    genre_temp.RetrieveGenre(genreId);
                    List<Genre> listeGenre_temp = livre.GetLesGenres();
                    listeGenre_temp.Add(genre_temp);
                    livre.SetLesGenres(listeGenre_temp);
                }

                // En se basant sur l'id sauvegarder dans l'objet livre on retrieve l'objet typeLivre

                TypeLivre type_temp = new TypeLivre();


                type_temp.RetrieveTypeLivre(DicoIdType[isbn]);
                livre.SetLeType(type_temp);
            }

            // Ajoute les livres de la map à la collection finale
            CollectionLivres.AddRange(livresMap.Values);

            return CollectionLivres;
        }

    }
}
