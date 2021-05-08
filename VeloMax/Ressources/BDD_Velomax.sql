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

#
CREATE TABLE `VeloMax`.`velo` 
(`numero_velo` int NOT NULL, 
`nom_velo` varchar(40), 
`grandeur_velo` varchar(40), 
`prix_velo` float, 
`ligne_produit_velo` varchar(40), 
`date_introduction_velo` datetime, 
`date_discontinuation_velo` datetime, 
`stock_velo` int,
PRIMARY KEY(`numero_velo`) );  


CREATE TABLE `VeloMax`.`fournisseur`
(`siret_fournisseur` varchar(40) NOT NULL, 
`nom_fournisseur` varchar(40),
`qualite_fournisseur` varchar(20), 
`nom_contact_fournisseur` varchar(40), 
`ID_adresse` int,
PRIMARY KEY(`siret_fournisseur`),

INDEX `F_fournisseur1_idx` (`id_adresse` ASC),
   CONSTRAINT `ID_adresse` FOREIGN KEY (`ID_adresse`)
		REFERENCES `VeloMax`.`adresse` (`ID_adresse`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  
        

CREATE TABLE `VeloMax`.`piece` 
(`numero_piece_catalogue` varchar(40) NOT NULL, 
`numero_piece` varchar(40), 
`description_piece` varchar(255), 
`date_introduction_piece` datetime, 
`date_discontinuation_piece` datetime, 
`prix_piece` float, 
`delai_approvisionnement_piece` datetime, 
`stock_piece` int,
PRIMARY KEY(`numero_piece_catalogue`));  


CREATE TABLE `VeloMax`.`commande` 
(`numero_commande` int NOT NULL, 
`date_commande` datetime, 
`date_livraison_commande` datetime,
`ID_adresse` int,  
`ID_client_entreprise` varchar(40), 
`ID_client_particulier` varchar(40),
PRIMARY KEY(`numero_commande`),

INDEX `F_commande1_idx` (`ID_adresse` ASC),
   CONSTRAINT `ID_adresse` FOREIGN KEY (`ID_adresse`)
		REFERENCES `VeloMax`.`adresse` (`ID_adresse`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX `F_commande2_idx` (`ID_client_entreprise` ASC),
   CONSTRAINT `ID_client_entreprise` FOREIGN KEY (`ID_client_entreprise`)
		REFERENCES `VeloMax`.`client_entreprise` (`ID_client_entreprise`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX `F_commande3_idx` (`ID_client_particulier` ASC),
   CONSTRAINT `ID_client_particulier` FOREIGN KEY (`ID_client_particulier`)
		REFERENCES `VeloMax`.`client_particulier` (`ID_client_particulier`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE `VeloMax`.`client_entreprise` 
(`ID_client_entreprise` varchar(40) NOT NULL, 
`nom_client_entreprise` varchar(40),
`remise_client_entreprise` float, 
`courriel_entreprise` varchar(40), 
`telephone_entreprise` varchar(40), 
`nom_contact_entreprise` varchar(40), 
`ID_adresse` int,
PRIMARY KEY(`ID_client_entreprise`),

INDEX `F_client_entreprise1_idx` (`id_adresse` ASC),
   CONSTRAINT `id_adresse` FOREIGN KEY (`id_adresse`)
		REFERENCES `VeloMax`.`adresse` (`id_adresse`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE `VeloMax`.`client_particulier` 
(`ID_client_particulier` varchar(40) NOT NULL, 
`nom_client_particulier` varchar(40), 
`prenom_client_particulier` varchar(40), 
`date_adhesion_programme` datetime, 
`courriel_particulier` varchar(40), 
`telephone_particulier` varchar(40), 
`numero_programme` int, 
`ID_adresse` int,
PRIMARY KEY(`ID_client_particulier`),

INDEX `F_client_particulier1_idx` (`ID_adresse` ASC),
   CONSTRAINT `ID_adresse` FOREIGN KEY (`ID_adresse`)
		REFERENCES `VeloMax`.`adresse` (`ID_adresse`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
        
INDEX `F_client_particulier2_idx` (`numero_programme` ASC),
   CONSTRAINT `numero_programme` FOREIGN KEY (`numero_programme`)
		REFERENCES `VeloMax`.`programme` (`numero_programme`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);   


CREATE TABLE `VeloMax`.`adresse` 
(`ID_adresse` int, 
`rue_adresse` varchar(40), 
`ville_adresse` varchar(40), 
`code_postal_adresse` int, 
`province_adresse` varchar(40), 
PRIMARY KEY(`ID_adresse`));  


CREATE TABLE `VeloMax`.`programme` 
(`numero_programme` int NOT NULL, 
`nom_programme` varchar(40), 
`prix_programme` float, 
`duree_programme` int, 
`rabais_programme` float,
PRIMARY KEY (`numero_programme`));  


CREATE TABLE `VeloMax`.`catalogue` 
(`numero_piece_catalogue` varchar(40) NOT NULL, 
`siret_fournisseur` varchar(40) NOT NULL, 
`quantite_piece_catalogue` int,

PRIMARY KEY (`numero_piece_catalogue`, `siret_fournisseur`),
   INDEX `F_catalogue1_idx` (`numero_piece_catalogue` ASC),
   INDEX `F_catalogue2_idx` (`siret_fournisseur` ASC),
   CONSTRAINT `numero_piece_catalogue` FOREIGN KEY (`numero_piece_catalogue`)
		REFERENCES `VeloMax`.`piece`  (`numero_piece_catalogue`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT `siret_fournisseur` FOREIGN KEY (`siret_fournisseur`)
		REFERENCES `VeloMax`.`fournisseur` (`siret_fournisseur`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  
        

CREATE TABLE `VeloMax`.`liste_velo_commande` 
(`numero_commande` int NOT NULL, 
`numero_velo` int, 
`quantite_velo_commande` int,

PRIMARY KEY (`numero_commande`, `numero_velo`),
   INDEX `F_liste_velo_commande1_idx` (`numero_commande` ASC),
   INDEX `F_liste_velo_commande2_idx` (`numero_velo` ASC),
   CONSTRAINT `numero_commande` FOREIGN KEY (`numero_commande`)
		REFERENCES `VeloMax`.`commande`  (`numero_commande`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT `numero_velo` FOREIGN KEY (`numero_velo`)
		REFERENCES `VeloMax`.`velo` (`numero_velo`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);


CREATE TABLE `VeloMax`.`liste_assemblage` 
(`numero_velo` int NOT NULL, 
`numero_piece_catalogue` varchar(255) NOT NULL, 
`quantite_piece_assemblage` int,

PRIMARY KEY (`numero_velo`, `numero_piece_catalogue`),
   INDEX `F_liste_assemblage1_idx` (`numero_velo` ASC),
   INDEX `F_liste_assemblage2_idx` (`numero_piece_catalogue` ASC),
   CONSTRAINT `numero_velo` FOREIGN KEY (`numero_velo`)
		REFERENCES `VeloMax`.`velo`  (`numero_velo`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT `numero_piece_catalogue` FOREIGN KEY (`numero_piece_catalogue`)
		REFERENCES `VeloMax`.`catalogue` (`numero_piece_catalogue`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);  


CREATE TABLE `VeloMax`.`liste_piece_commande` 
(`numero_piece_catalogue` varchar(255) NOT NULL, 
`numero_commande` int NOT NULL, 
`quantite_piece_commande` int,

PRIMARY KEY (`numero_piece_catalogue`, `numero_commande`),
   INDEX `F_liste_piece_commande1_idx` (`numero_piece_catalogue` ASC),
   INDEX `F_liste_piece_commande2_idx` (`numero_commande` ASC),
   CONSTRAINT `numero_piece_catalogue` FOREIGN KEY (`numero_piece_catalogue`)
		REFERENCES `VeloMax`.`catalogue`  (`numero_piece_catalogue`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
   CONSTRAINT `numero_commande` FOREIGN KEY (`numero_commande`)
		REFERENCES `VeloMax`.`commande` (`numero_commande`)
		ON DELETE CASCADE
		ON UPDATE NO ACTION);





#ALTER TABLE fournisseur ADD CONSTRAINT FK_fournisseur_id_adresse FOREIGN KEY (id_adresse) REFERENCES adresse (id_adresse);  



/*
ALTER TABLE commande ADD CONSTRAINT FK_commande_id_client_entreprise FOREIGN KEY (id_client_entreprise) 
REFERENCES client_entreprise (id_client_entreprise);  

ALTER TABLE commande ADD CONSTRAINT FK_commande_id_adresse FOREIGN KEY (id_adresse) 
REFERENCES adresse (id_adresse);  

ALTER TABLE commande ADD CONSTRAINT FK_commande_id_client_particulier FOREIGN KEY (id_client_particulier) 
REFERENCES client_particulier (id_client_particulier);  
*/

  

#ALTER TABLE client_entreprise ADD CONSTRAINT FK_client_entreprise_id_adresse FOREIGN KEY (id_adresse) REFERENCES adresse (id_adresse);  



/*
ALTER TABLE client_particulier ADD CONSTRAINT FK_client_particulier_numero_programme FOREIGN KEY (numero_programme) 
REFERENCES programme (numero_programme);  

ALTER TABLE client_particulier ADD CONSTRAINT FK_client_particulier_id_adresse FOREIGN KEY (id_adresse) 
REFERENCES adresse (id_adresse);  
*/


/*
ALTER TABLE catalogue ADD CONSTRAINT PK_catalogue PRIMARY KEY (numero_piece_catalogue, siret_fournisseur);  

ALTER TABLE catalogue ADD CONSTRAINT FK_catalogue_numero_piece_catalogue FOREIGN KEY (numero_piece_catalogue) 
REFERENCES piece (numero_piece_catalogue);  

ALTER TABLE catalogue ADD CONSTRAINT FK_catalogue_siret_fournisseur FOREIGN KEY (siret_fournisseur) 
REFERENCES fournisseur (siret_fournisseur);  
*/


/*
ALTER TABLE liste_velo_commande ADD CONSTRAINT PK_liste_velo_commande PRIMARY KEY (numero_commande, numero_velo);  

ALTER TABLE liste_velo_commande ADD CONSTRAINT FK_liste_velo_commande_numero_commande FOREIGN KEY (numero_commande) 
REFERENCES commande (numero_commande);  

ALTER TABLE liste_velo_commande ADD CONSTRAINT FK_liste_velo_commande_numero_velo FOREIGN KEY (numero_velo) 
REFERENCES velo (numero_velo);  
*/


/*
ALTER TABLE liste_assemblage ADD CONSTRAINT PK_liste_assemblage PRIMARY KEY (numero_velo, numero_piece_catalogue);  

ALTER TABLE liste_assemblage ADD CONSTRAINT FK_liste_assemblage_numero_velo FOREIGN KEY (numero_velo) 
REFERENCES velo (numero_velo); 

ALTER TABLE liste_assemblage ADD CONSTRAINT FK_liste_assemblage_numero_piece_catalogue FOREIGN KEY (numero_piece_catalogue) 
REFERENCES piece (numero_piece_catalogue);  
*/


/*
ALTER TABLE liste_piece_commande ADD CONSTRAINT PK_liste_piece_commande PRIMARY KEY (numero_piece_catalogue, numero_commande);  

ALTER TABLE liste_piece_commande ADD CONSTRAINT FK_liste_piece_commande_numero_piece_catalogue FOREIGN KEY (numero_piece_catalogue) 
REFERENCES piece (numero_piece_catalogue);  

ALTER TABLE liste_piece_commande ADD CONSTRAINT FK_liste_piece_commande_numero_commande FOREIGN KEY (numero_commande) 
REFERENCES commande (numero_commande);
*/









