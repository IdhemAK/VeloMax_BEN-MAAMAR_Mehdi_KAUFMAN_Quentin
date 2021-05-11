#rapport stock piece
select numero_piece_catalogue, stock_piece from piece group by numero_piece;
select numero_piece, sum(stock_piece) from piece group by numero_piece;



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

-- Nouveaux Utilisateurs 
create user 'bozo'@'localhost' identified by 'bozo';
grant show view on *.* to 'bozo'@'localhost';
#show grants for 'bozo'@'localhost' ;










-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Gestion 
-- ////////////////////////////////////////////////////////////////////////////////////////////////

/*
vérification des stocks
sélectionner le vélo à commander sur la datgrid 
mettre le stock à jour en temps réel
remplacer par stock_piece, piece et numero_piece_catalogue
*/
select stock_velo from velo where numero_velo=1;

#si stock insuffisant prendre liste_assemblage et vérifier
select numero_velo_assemblage, numero_piece_catalogue_assemblage,
quantite_piece_assemblage from liste_assemblage l
join velo v on v.numero_velo=l.numero_velo_assemblage
where v.numero_velo=1;

-- commande vélo : 2 requêtes
#recherche stock
select stock_velo from velo where numero_velo=1;
#si stock vide : construire vélo
select numero_velo_assemblage, numero_piece_catalogue_assemblage,
quantite_piece_assemblage, stock_piece from liste_assemblage l
join velo v on v.numero_velo=l.numero_velo_assemblage
join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_assemblage
where v.numero_velo=1;

-- commande pièce unique pour vérifier le stock
select numero_piece_catalogue, stock_piece 
from piece
where numero_piece_catalogue = "Farnell_P1";

/*
insérer des tuples dans commande, 
dans liste_piece_commande et/ou
liste_velo_commande
*/



INSERT INTO piece VALUES ('Farnell_P20','P20','panier','2010-01-01','2014-12-02',14,2,70);
INSERT INTO catalogue VALUES ('Farnell_P20','46513890001294',5000);
INSERT INTO liste_piece_commande VALUES ('Farnell_P20',78,7);


-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Module Statistique
-- ////////////////////////////////////////////////////////////////////////////////////////////////


-- 1a
#rapport statistique piece
#piece de chaque catalogue
select numero_piece_catalogue_commande, sum(quantite_piece_commande) 
from liste_piece_commande 
group by numero_piece_catalogue_commande;

-- on prend ça
#chaque piece 
select SUBSTRING_INDEX(numero_piece_catalogue_commande,'_',-1) as s, sum(quantite_piece_commande) 
from liste_piece_commande 
group by s;


-- 1b
#rapport statistique velo
#par nom de velo
select v.nom_velo, sum(l.quantite_velo_commande)
from liste_velo_commande l
join velo v on v.numero_velo=l.numero_velo
group by v.nom_velo;

#par grandeur
select v.grandeur_velo, sum(l.quantite_velo_commande)
from liste_velo_commande l
join velo v on v.numero_velo=l.numero_velo
group by v.grandeur_velo;

-- on prend ça
#par nom et par grandeur
select v.grandeur_velo as Grandeur, v.nom_velo as Velo
, sum(l.quantite_velo_commande) as Vendus
from liste_velo_commande l
join velo v on v.numero_velo=l.numero_velo
group by grandeur_velo, nom_velo;


-- 2
#rapport liste membre pour chaque programme d'adhesion
#membre + programme
select nom_programme, ID_client_particulier, nom_client_particulier, 
	prenom_client_particulier 
from client_particulier c
join programme p on p.numero_programme=c.numero_programme;

#programme + nombre de client
select nom_programme, count(c.numero_programme)
from client_particulier c
join programme p on p.numero_programme=c.numero_programme
group by nom_programme;


-- 3
#programme + 
select nom_programme, ID_client_particulier, date_adhesion_programme,
	DATE_ADD(date_adhesion_programme, INTERVAL duree_programme YEAR)
from client_particulier c
join programme p on p.numero_programme=c.numero_programme;
#sommer datetime et timespan dans c sharp


# combinaison 2  et 3
select nom_programme as Programme, ID_client_particulier as "ID client", 
nom_client_particulier as Nom, prenom_client_particulier as Prenom, 
date_adhesion_programme as "Date d'adhésion",
DATE_ADD(date_adhesion_programme, INTERVAL duree_programme YEAR) as "Date d'expiration"
from client_particulier c
join programme p on p.numero_programme=c.numero_programme;

#DATE_FORMAT(date_adhesion_programme, "%Y-%m-%d"),



-- 4
#quantite nombre piece vendues clients
select cp.ID_client_particulier, sum(l.quantite_piece_commande) 
from liste_piece_commande l
join commande c on c.numero_commande=l.numero_commande_piece
join client_particulier cp on cp.ID_client_particulier=c.ID_client_particulier
group by cp.ID_client_particulier;

#quantité cumulé sur les piece des 
#clients particuliers
select cp.ID_client_particulier, 
	sum(l.quantite_piece_commande*p.prix_piece) as s 
from liste_piece_commande l
join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande
join commande c on c.numero_commande=l.numero_commande_piece
join client_particulier cp on cp.ID_client_particulier=c.ID_client_particulier
group by cp.ID_client_particulier
order by s DESC;

#verification quantité cumulée
select l.numero_piece_catalogue_commande, l.quantite_piece_commande,
	p.prix_piece, cp.ID_client_particulier
from liste_piece_commande l
join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande
join commande c on c.numero_commande=l.numero_commande_piece
join client_particulier cp on cp.ID_client_particulier=c.ID_client_particulier;

#montant cumulé piece
#client_entreprise
select ce.ID_client_entreprise, 
	sum(l.quantite_piece_commande*p.prix_piece) as s 
from liste_piece_commande l
join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande
join commande c on c.numero_commande=l.numero_commande_piece
join client_entreprise ce on ce.ID_client_entreprise=c.ID_client_entreprise
group by ce.ID_client_entreprise
order by s DESC;


-- 5a 

#moyenne montant commande
/* essai non abouti
select numero_commande, quantite_piece_commande, prix_piece+quantite_velo_commande*prix_velo
from commande c
join liste_piece_commande lp on lp.numero_commande_piece=c.numero_commande
join piece p on p.numero_piece_catalogue=lp.numero_piece_catalogue_commande
join liste_velo_commande lv on lv.numero_commande_velo=c.numero_commande
join velo v on v.numero_velo=lv.numero_velo
group by numero_commande
order by numero_commande;
*/

#on sélectionne le prix total des pièces par commande
select numero_commande, sum(prix_velo*quantite_velo_commande)
from commande c
join liste_velo_commande lv on lv.numero_commande_velo=c.numero_commande
join velo v on v.numero_velo=lv.numero_velo
group by numero_commande
order by numero_commande;

#on sélectionne le prix total des vélos par commande
select numero_commande, sum(prix_piece*quantite_piece_commande)
from commande c
join liste_piece_commande lp on lp.numero_commande_piece=c.numero_commande
join piece p on p.numero_piece_catalogue=lp.numero_piece_catalogue_commande
group by numero_commande
order by numero_commande;

#on compte le nombre total de commande
select count(numero_commande) from commande;

#on utilise les 3 requêtes pour calculer la 
#moyenne des montants des commandes sur c sharp


-- 5b
select numero_commande, numero_velo, sum(quantite_velo_commande) as qvc
from commande c
join liste_velo_commande lv on lv.numero_commande_velo=c.numero_commande
group by numero_commande
order by numero_commande;

select numero_commande, numero_piece_catalogue_commande, sum(quantite_piece_commande)
from commande c
join liste_piece_commande lp on lp.numero_commande_piece=c.numero_commande
group by numero_commande
order by numero_commande;

select count(numero_commande) from commande;
