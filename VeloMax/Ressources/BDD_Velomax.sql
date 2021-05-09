DROP database if exists VeloMax;
CREATE database if not exists VeloMax;

use VeloMax;
set sql_safe_updates=0;

drop table if exists velo;
drop table if exists fournisseur;
drop table if exists piece;
drop table if exists commande;
drop table if exists client_entreprise;
drop table if exists client_particulier;
drop table if exists adresse;
drop table if exists programme;
drop table if exists catalogue;
drop table if exists liste_velo_commande;
drop table if exists liste_assemblage;
drop table if exists liste_piece_commande;


CREATE TABLE if not exists velo 
(numero_velo int NOT NULL, 
nom_velo varchar(40), 
grandeur_velo varchar(40), 
prix_velo float, 
ligne_produit_velo varchar(40), 
date_introduction_velo datetime, 
date_discontinuation_velo datetime, 
stock_velo int,
PRIMARY KEY(numero_velo));  


CREATE TABLE adresse 
(ID_adresse int, 
rue_adresse varchar(40), 
ville_adresse varchar(40), 
code_postal_adresse varchar(8), 
province_adresse varchar(40), 
PRIMARY KEY(ID_adresse));  


CREATE TABLE programme
(numero_programme int NOT NULL, 
nom_programme varchar(40), 
prix_programme float, 
duree_programme int, 
rabais_programme float,
PRIMARY KEY (numero_programme));  


CREATE TABLE piece
(numero_piece_catalogue varchar(40) NOT NULL, 
numero_piece varchar(40), 
description_piece varchar(255), 
date_introduction_piece datetime, 
date_discontinuation_piece datetime, 
prix_piece float, 
delai_approvisionnement_piece int, 
stock_piece int,
PRIMARY KEY(numero_piece_catalogue));  


CREATE TABLE fournisseur
(siret_fournisseur varchar(40) NOT NULL, 
nom_fournisseur varchar(40),
qualite_fournisseur varchar(20), 
nom_contact_fournisseur varchar(40), 
ID_adresse_fournisseur int,
PRIMARY KEY(siret_fournisseur),

INDEX F_fournisseur1_idx (ID_adresse_fournisseur ASC),
	CONSTRAINT ID_adresse_fournisseur FOREIGN KEY (ID_adresse_fournisseur)
		REFERENCES adresse (ID_adresse)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE client_entreprise
(ID_client_entreprise varchar(40) NOT NULL, 
nom_client_entreprise varchar(40),
remise_client_entreprise float, 
courriel_entreprise varchar(40), 
telephone_entreprise varchar(40), 
nom_contact_entreprise varchar(40), 
ID_adresse_client_entreprise int,
PRIMARY KEY(ID_client_entreprise),

INDEX F_client_entreprise1_idx (ID_adresse_client_entreprise ASC),
   CONSTRAINT ID_adresse_client_entreprise FOREIGN KEY (ID_adresse_client_entreprise)
		REFERENCES adresse (ID_adresse)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE client_particulier 
(ID_client_particulier varchar(40) NOT NULL, 
nom_client_particulier varchar(40), 
prenom_client_particulier varchar(40), 
date_adhesion_programme datetime, 
courriel_particulier varchar(40), 
telephone_particulier varchar(40), 
numero_programme int, 
ID_adresse_client_particulier int,
PRIMARY KEY(ID_client_particulier),

INDEX F_client_particulier1_idx (ID_adresse_client_particulier ASC),
   CONSTRAINT ID_adresse_client_particulier FOREIGN KEY (ID_adresse_client_particulier)
		REFERENCES adresse (ID_adresse)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX F_client_particulier2_idx (numero_programme ASC),
   CONSTRAINT numero_programme FOREIGN KEY (numero_programme)
		REFERENCES programme (numero_programme)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);   



CREATE TABLE commande
(numero_commande int NOT NULL, 
date_commande datetime, 
date_livraison_commande datetime,
ID_adresse_commande int,  
ID_client_entreprise varchar(40), 
ID_client_particulier varchar(40),
PRIMARY KEY(numero_commande),

INDEX F_commande1_idx (ID_adresse_commande ASC),
   CONSTRAINT ID_adresse_commande FOREIGN KEY (ID_adresse_commande)
		REFERENCES adresse (ID_adresse)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX F_commande2_idx (ID_client_entreprise ASC),
   CONSTRAINT ID_client_entreprise FOREIGN KEY (ID_client_entreprise)
		REFERENCES client_entreprise (ID_client_entreprise)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX F_commande3_idx (ID_client_particulier ASC),
   CONSTRAINT ID_client_particulier FOREIGN KEY (ID_client_particulier)
		REFERENCES client_particulier (ID_client_particulier)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE catalogue
(numero_piece_catalogue varchar(40) NOT NULL, 
siret_fournisseur varchar(40) NOT NULL, 
quantite_piece_catalogue int,

PRIMARY KEY (numero_piece_catalogue, siret_fournisseur),
   INDEX F_catalogue1_idx (numero_piece_catalogue ASC),
   INDEX F_catalogue2_idx (siret_fournisseur ASC),
   CONSTRAINT numero_piece_catalogue FOREIGN KEY (numero_piece_catalogue)
		REFERENCES piece  (numero_piece_catalogue)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT siret_fournisseur FOREIGN KEY (siret_fournisseur)
		REFERENCES fournisseur (siret_fournisseur)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  
        

CREATE TABLE liste_velo_commande
(numero_commande_velo int NOT NULL, 
numero_velo int, 
quantite_velo_commande int,

PRIMARY KEY (numero_commande_velo, numero_velo),
   INDEX F_liste_velo_commande1_idx (numero_commande_velo ASC),
   INDEX F_liste_velo_commande2_idx (numero_velo ASC),
   CONSTRAINT numero_commande_velo FOREIGN KEY (numero_commande_velo)
		REFERENCES commande  (numero_commande)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT numero_velo FOREIGN KEY (numero_velo)
		REFERENCES velo (numero_velo)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);


CREATE TABLE liste_assemblage 
(numero_velo_assemblage int NOT NULL, 
numero_piece_catalogue_assemblage varchar(255) NOT NULL, 
quantite_piece_assemblage int,

PRIMARY KEY (numero_velo_assemblage, numero_piece_catalogue_assemblage),
   INDEX F_liste_assemblage1_idx (numero_velo_assemblage ASC),
   INDEX F_liste_assemblage2_idx (numero_piece_catalogue_assemblage ASC),
   CONSTRAINT numero_velo_assemblage FOREIGN KEY (numero_velo_assemblage)
		REFERENCES velo  (numero_velo)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT numero_piece_catalogue_assemblage FOREIGN KEY (numero_piece_catalogue_assemblage)
		REFERENCES catalogue (numero_piece_catalogue)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE liste_piece_commande 
(numero_piece_catalogue_commande varchar(255) NOT NULL, 
numero_commande_piece int NOT NULL, 
quantite_piece_commande int,

PRIMARY KEY (numero_piece_catalogue_commande, numero_commande_piece),
   INDEX F_liste_piece_commande1_idx (numero_piece_catalogue_commande ASC),
   INDEX F_liste_piece_commande2_idx (numero_commande_piece ASC),
   CONSTRAINT numero_piece_catalogue_commande FOREIGN KEY (numero_piece_catalogue_commande)
		REFERENCES catalogue (numero_piece_catalogue)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT numero_commande_piece FOREIGN KEY (numero_commande_piece)
		REFERENCES commande (numero_commande)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);

 
/*
INSERT INTO velo VALUES (1,'BTwin','Adulte',100,'VTT','2020-01-01','2020-01-01',24);

INSERT INTO adresse VALUES (1,'1 avenue du général De Gaulle','Meudon',92360,'Île-de-France');
INSERT INTO adresse VALUES (2,'4 Route de Saessolsheim','Landersheim',67700,'Grand Est');

INSERT INTO programme VALUES (1,'Fidélio',15,1,5);

INSERT INTO piece VALUES ('RS-C32','C32','Cadre','2010-01-01','2010-01-01',20,10,1000);

INSERT INTO fournisseur VALUES ('306 138 900 01294','Décathlon','Bien','Michel Random',1);

INSERT INTO client_entreprise VALUES (1,'Adidas',5,'adidas@random.fr','8888888888','Jean Auhasard',2);

INSERT INTO client_particulier VALUES (1,'Kaufman','Quentin','2020-12-30','quentin.kaufman@edu.devinci.fr','0000000000',1,2);

INSERT INTO commande VALUES (1,'2020-12-30','2021-01-13',1,1,null);

INSERT INTO catalogue VALUES ('RS-C32','306 138 900 01294',8000);

INSERT INTO liste_velo_commande VALUES (1,1,5000);

INSERT INTO liste_assemblage VALUES (1,'RS-C32',500);

INSERT INTO liste_piece_commande VALUES ('RS-C32',1,2);
*/



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Module Stock
-- ////////////////////////////////////////////////////////////////////////////////////////////////


-- Stock piece ----------------------------------------------------------------

-- Stock piece -> Stock d'une piece peu importe son fournisseur
select p.numero_piece,sum(p.stock_piece)
from piece p
group by p.numero_piece
order by sum(p.stock_piece);

-- Stock piece type -> regroupé par type de piece
select p.description_piece,sum(p.stock_piece)
from piece p
group by p.description_piece
order by sum(p.stock_piece);

-- Stock piece fournisseur -> Stock d'une piece en fonction de quel fournisseur
select numero_piece_catalogue, p.stock_piece, p.date_discontinuation_piece
from piece p
order by p.stock_piece;

-- Stock des fournisseurs -> combien de piece de chaque fournisseur on a (pour voir chez qui on commande le plus)
select f.nom_fournisseur , sum(p.stock_piece)
from catalogue c, piece p, fournisseur f
where p.numero_piece_catalogue = c.numero_piece_catalogue and c.siret_fournisseur = f.siret_fournisseur
group by f.nom_fournisseur
order by sum(p.stock_piece);

-- Stock vélo ----------------------------------------------------------------

-- Stock vélo -> Stock des différents vélos (par numéros)
select v.numero_velo,v.stock_velo,v.date_discontinuation_velo
from velo v
order by v.stock_velo;

-- Stock vélo par taille du vélo (enfant, ado, adulte)
select v.grandeur_velo, sum(v.stock_velo)
from velo v
group by v.grandeur_velo
order by sum(v.stock_velo);

-- Stock par modele de vélo (Kilimandjaro etc...) 
select v.nom_velo,sum(v.stock_velo)
from velo v
group by v.nom_velo
order by sum(v.stock_velo);

-- Stock par ligne produit (BMX etc...)
select v.ligne_produit_velo,sum(v.stock_velo)
from velo v
group by v.ligne_produit_velo
order by sum(v.stock_velo);



























