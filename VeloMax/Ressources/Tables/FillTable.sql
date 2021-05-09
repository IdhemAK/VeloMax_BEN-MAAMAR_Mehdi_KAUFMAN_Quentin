

-- Script de remplissage des tables SQL

-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Velos (20 Tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
/*
# Old insert with 8888-08-08 instead of null
INSERT INTO velo VALUES (1,'Kilimandjaro','Adulte',410,'Vélo_de_course','2012-01-01','2016-12-01',30);
INSERT INTO velo VALUES (2,'Kilimandjaro','Adolescent',278,'Vélo_de_course','2012-01-01','2016-12-01',103);
INSERT INTO velo VALUES (3,'Kilimandjaro','Adolescent',71,'BMX','2012-01-01','2016-12-01',64);
INSERT INTO velo VALUES (4,'NorthPole','Adolescent',268,'BMX','2013-01-01','2017-12-02',251);
INSERT INTO velo VALUES (5,'MontBlanc','Adolescent',328,'Vélo_de_course','2014-01-01','2018-12-02',295);
INSERT INTO velo VALUES (6,'Hooligan','Enfant',312,'Vélo_de_course','2014-01-01','2018-12-02',255);
INSERT INTO velo VALUES (7,'Orléans','Adulte',324,'Vélo_de_course','2015-01-01','2019-12-02',212);
INSERT INTO velo VALUES (8,'BlueJay','Enfant',124,'Vélo_de_course','2015-01-01','2019-12-02',232);
INSERT INTO velo VALUES (9,'Trail_Explorer','Enfant',175,'Classique','2015-01-01','2019-12-02',178);
INSERT INTO velo VALUES (10,'Night_Hawk','Adolescent',184,'Vélo_de_course','2015-01-01','2019-12-02',245);
INSERT INTO velo VALUES (11,'Tierra_Verde','Adolescent',367,'Vélo_de_course','2016-01-01','8888-08-08',279);
INSERT INTO velo VALUES (12,'Mud_Zinger_I','Adulte',97,'Vélo_de_course','2017-01-01','8888-08-08',15);
INSERT INTO velo VALUES (13,'Mud_Zinger_II','Enfant',487,'VTT','2018-01-01','8888-08-08',256);
INSERT INTO velo VALUES (14,'NorthPole','Adolescent',432,'VTT','2018-01-01','8888-08-08',195);
INSERT INTO velo VALUES (15,'MontBlanc','Adolescent',89,'Vélo_de_course','2018-01-01','8888-08-08',237);
INSERT INTO velo VALUES (16,'Hooligan','Adolescent',330,'Classique','2019-01-01','8888-08-08',171);
INSERT INTO velo VALUES (17,'Orléans','Enfant',318,'BMX','2019-01-01','8888-08-08',81);
INSERT INTO velo VALUES (18,'BlueJay','Enfant',234,'Vélo_de_course','2020-01-01','8888-08-08',21);
INSERT INTO velo VALUES (19,'Trail_Explorer','Enfant',73,'Classique','2020-01-01','8888-08-08',65);
INSERT INTO velo VALUES (20,'Trail_Explorer','Adolescent',167,'BMX','2020-01-01','8888-08-08',129);
#select * from velo;
*/
INSERT INTO velo VALUES (1,'Kilimandjaro','Adulte',419,'Classique','2012-01-01','2016-12-01',164);
INSERT INTO velo VALUES (2,'Kilimandjaro','Adolescent',252,'BMX','2012-01-01','2016-12-01',249);
INSERT INTO velo VALUES (3,'Kilimandjaro','Adolescent',61,'Vélo_de_course','2012-01-01','2016-12-01',197);
INSERT INTO velo VALUES (4,'NorthPole','Adolescent',350,'BMX','2013-01-01','2017-12-02',118);
INSERT INTO velo VALUES (5,'MontBlanc','Adolescent',414,'Vélo_de_course','2014-01-01','2018-12-02',202);
INSERT INTO velo VALUES (6,'Hooligan','Enfant',144,'Classique','2014-01-01','2018-12-02',108);
INSERT INTO velo VALUES (7,'Orléans','Adulte',100,'VTT','2015-01-01','2019-12-02',173);
INSERT INTO velo VALUES (8,'BlueJay','Enfant',125,'Classique','2015-01-01','2019-12-02',214);
INSERT INTO velo VALUES (9,'Trail_Explorer','Enfant',147,'BMX','2015-01-01','2019-12-02',84);
INSERT INTO velo VALUES (10,'Night_Hawk','Adolescent',243,'BMX','2015-01-01','2019-12-02',157);
INSERT INTO velo VALUES (11,'Tierra_Verde','Adolescent',287,'Classique','2016-01-01',null,233);
INSERT INTO velo VALUES (12,'Mud_Zinger_I','Adulte',154,'BMX','2017-01-01',null,292);
INSERT INTO velo VALUES (13,'Mud_Zinger_II','Enfant',478,'Classique','2018-01-01',null,157);
INSERT INTO velo VALUES (14,'NorthPole','Adolescent',74,'Vélo_de_course','2018-01-01',null,220);
INSERT INTO velo VALUES (15,'MontBlanc','Adolescent',262,'Classique','2018-01-01',null,221);
INSERT INTO velo VALUES (16,'Hooligan','Adolescent',198,'Classique','2019-01-01',null,101);
INSERT INTO velo VALUES (17,'Orléans','Enfant',218,'BMX','2019-01-01',null,225);
INSERT INTO velo VALUES (18,'BlueJay','Enfant',402,'Vélo_de_course','2020-01-01',null,76);
INSERT INTO velo VALUES (19,'Trail_Explorer','Enfant',269,'Classique','2020-01-01',null,215);
INSERT INTO velo VALUES (20,'Trail_Explorer','Adolescent',197,'VTT','2020-01-01',null,33);
#select * from velo;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Pieces (20 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
/*
# Old insert with 8888-08-08 instead of null
INSERT INTO piece VALUES ('RS_P1','P1','cadre','2010-01-01','2014-12-02',79,7,50);
INSERT INTO piece VALUES ('Farnell_P2','P2','cadre','2012-01-01','2016-12-01',48,25,120);
INSERT INTO piece VALUES ('Digikey_P3','P3','cadre','2017-01-01','8888-08-08',126,25,30);
INSERT INTO piece VALUES ('Mouser_P4','P4','cadre','2020-01-01','8888-08-08',29,25,20);
INSERT INTO piece VALUES ('RS_P5','P5','guidon','2010-01-01','2014-12-02',30,90,40);
INSERT INTO piece VALUES ('Farnell_P6','P6','guidon','2012-01-01','2016-12-01',56,1,40);
INSERT INTO piece VALUES ('Digikey_P7','P7','guidon','2017-01-01','8888-08-08',40,3,40);
INSERT INTO piece VALUES ('Mouser_P8','P8','freins','2010-01-01','2014-12-02',119,5,20);
INSERT INTO piece VALUES ('RS_P9','P9','freins','2012-01-01','2016-12-01',48,1,35);
INSERT INTO piece VALUES ('Farnell_P10','P10','freins','2017-01-01','8888-08-08',18,3,50);
INSERT INTO piece VALUES ('Digikey_P11','P11','selle','2010-01-01','2014-12-02',32,7,200);
INSERT INTO piece VALUES ('Mouser_P12','P12','derailleur avant','2010-01-01','2014-12-02',25,15,180);
INSERT INTO piece VALUES ('RS_P13','P13','derailleur arriere','2010-01-01','2014-12-02',20,90,180);
INSERT INTO piece VALUES ('Farnell_P14','P14','roue avant','2010-01-01','2014-12-02',55,5,220);
INSERT INTO piece VALUES ('Digikey_P15','P15','roue avant','2012-01-01','2016-12-01',32,1,200);
INSERT INTO piece VALUES ('Mouser_P16','P16','roue arriere','2010-01-01','2014-12-02',63,15,400);
INSERT INTO piece VALUES ('RS_P17','P17','reflecteurs','2010-01-01','2014-12-02',9,3,1000);
INSERT INTO piece VALUES ('Farnell_P18','P18','pedalier','2010-01-01','2014-12-02',38,2,120);
INSERT INTO piece VALUES ('Digikey_P19','P19','ordinateur','2010-01-01','2014-12-02',179,90,50);
INSERT INTO piece VALUES ('Mouser_P20','P20','panier','2010-01-01','2014-12-02',14,2,70);
#select * from piece;
*/
INSERT INTO piece VALUES ('RS_P1','P1','cadre','2010-01-01','2014-12-02',79,7,50);
INSERT INTO piece VALUES ('Farnell_P1','P1','cadre','2010-01-01','2014-12-02',89,5,50);
INSERT INTO piece VALUES ('Digikey_P1','P1','cadre','2010-01-01','2014-12-02',65,20,50);
INSERT INTO piece VALUES ('Farnell_P2','P2','cadre','2012-01-01','2016-12-01',48,25,120);
INSERT INTO piece VALUES ('Digikey_P3','P3','cadre','2017-01-01',null,126,25,30);
INSERT INTO piece VALUES ('Mouser_P4','P4','cadre','2020-01-01',null,29,25,20);
INSERT INTO piece VALUES ('RS_P5','P5','guidon','2010-01-01','2014-12-02',30,90,40);
INSERT INTO piece VALUES ('Farnell_P6','P6','guidon','2012-01-01','2016-12-01',56,1,40);
INSERT INTO piece VALUES ('Digikey_P7','P7','guidon','2017-01-01',null,40,3,40);
INSERT INTO piece VALUES ('Mouser_P8','P8','freins','2010-01-01','2014-12-02',119,5,20);
INSERT INTO piece VALUES ('RS_P9','P9','freins','2012-01-01','2016-12-01',48,1,35);
INSERT INTO piece VALUES ('Farnell_P10','P10','freins','2017-01-01',null,18,3,50);
INSERT INTO piece VALUES ('Digikey_P11','P11','selle','2010-01-01','2014-12-02',32,7,200);
INSERT INTO piece VALUES ('Mouser_P12','P12','derailleur avant','2010-01-01','2014-12-02',25,15,180);
INSERT INTO piece VALUES ('RS_P13','P13','derailleur arriere','2010-01-01','2014-12-02',20,90,180);
INSERT INTO piece VALUES ('Farnell_P14','P14','roue avant','2010-01-01','2014-12-02',55,5,220);
INSERT INTO piece VALUES ('Digikey_P15','P15','roue avant','2012-01-01','2016-12-01',32,1,200);
INSERT INTO piece VALUES ('Mouser_P16','P16','roue arriere','2010-01-01','2014-12-02',63,15,400);
INSERT INTO piece VALUES ('RS_P17','P17','reflecteurs','2010-01-01','2014-12-02',9,3,1000);
INSERT INTO piece VALUES ('Farnell_P18','P18','pedalier','2010-01-01','2014-12-02',38,2,120);
INSERT INTO piece VALUES ('Digikey_P19','P19','ordinateur','2010-01-01','2014-12-02',179,90,50);
INSERT INTO piece VALUES ('Mouser_P20','P20','panier','2010-01-01','2014-12-02',14,2,70);
#select * from piece;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Adresses (20 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO adresse VALUES (1,'5 rue des pages','Andert-et-Condon','97093','Ain');
INSERT INTO adresse VALUES (2,'41 impasse de la carotte','Curepipe','23233','Rivière Noire ');
INSERT INTO adresse VALUES (3,'95 rue du dragon','Flic-en-Flac','78452','Flacq');
INSERT INTO adresse VALUES (4,'41 boulevard saint michel','Boston','06239','Oregon');
INSERT INTO adresse VALUES (5,'64 allée du sentier','Oulan-Bator','39509','Carnagouz');
INSERT INTO adresse VALUES (6,'81 route du dr jekyll','Shenzhen','00150','Guangdong');
INSERT INTO adresse VALUES (7,'84 chemin des terres battues','Quigdao','29353','Guangdong');
INSERT INTO adresse VALUES (8,'89 sentier de la hyde','Taipei','05910','Taïwan');
INSERT INTO adresse VALUES (9,'91 allée dorémi','Strasbourg','47146','Alsace');
INSERT INTO adresse VALUES (10,'18 avenue leonard devinci','Bremen','75384','Basse-Saxe');
INSERT INTO adresse VALUES (11,'29 carrefour des 5 armées','Bristol','45119','Gloucester');
INSERT INTO adresse VALUES (12,'72 impasse du peloton','Liverpool','12916','Merseyside');
INSERT INTO adresse VALUES (13,'76 rue mulberry','Antony','41491','Greef');
INSERT INTO adresse VALUES (14,'58 boulevard anthony','Paris','08942','Ile-de-France');
INSERT INTO adresse VALUES (15,'67 chemin du croisement','Turin','36172','Piémont');
INSERT INTO adresse VALUES (16,'78 sentier de lorange','Stuttgart','89898','Bade-Wurtemberg');
INSERT INTO adresse VALUES (17,'11 boulevard de la petite eau','Madrid','51614','Madrid');
INSERT INTO adresse VALUES (18,'30 avenue des champs elysées','Nairobie','51628','Nairobie');
INSERT INTO adresse VALUES (19,'92 rue grafton','Tokyo','13853','Kanto');
INSERT INTO adresse VALUES (20,'17 carrefour de la feuille','Genève','89910','Genève');
#select * from adresse;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Fournisseurs (4 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO fournisseur VALUES ('30613890001294','RS','très_bon','Archibalde_Foussier',11);
INSERT INTO fournisseur VALUES ('46513890001294','Farnell','bon','Anatole_Maire',16);
INSERT INTO fournisseur VALUES ('78313890001294','Digikey','moyen','Auguste_Kartofen',4);
INSERT INTO fournisseur VALUES ('10213890001294','Mouser','bon','Antoine_Poll',6);
#select * from fournisseur;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Catalogues (4 je crois)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO catalogue VALUES ('RS_P1','30613890001294',259);
INSERT INTO catalogue VALUES ('Farnell_P1','46513890001294',100);
INSERT INTO catalogue VALUES ('Digikey_P1','78313890001294',2500);
INSERT INTO catalogue VALUES ('Farnell_P2','46513890001294',3022);
INSERT INTO catalogue VALUES ('Digikey_P3','78313890001294',42);
INSERT INTO catalogue VALUES ('Mouser_P4','10213890001294',969);
INSERT INTO catalogue VALUES ('RS_P5','30613890001294',4133);
INSERT INTO catalogue VALUES ('Farnell_P6','46513890001294',6841);
INSERT INTO catalogue VALUES ('Digikey_P7','78313890001294',1860);
INSERT INTO catalogue VALUES ('Mouser_P8','10213890001294',4988);
INSERT INTO catalogue VALUES ('RS_P9','30613890001294',473);
INSERT INTO catalogue VALUES ('Farnell_P10','46513890001294',7257);
INSERT INTO catalogue VALUES ('Digikey_P11','78313890001294',1427);
INSERT INTO catalogue VALUES ('Mouser_P12','10213890001294',8079);
INSERT INTO catalogue VALUES ('RS_P13','30613890001294',4077);
INSERT INTO catalogue VALUES ('Farnell_P14','46513890001294',1305);
INSERT INTO catalogue VALUES ('Digikey_P15','78313890001294',6369);
INSERT INTO catalogue VALUES ('Mouser_P16','10213890001294',5923);
INSERT INTO catalogue VALUES ('RS_P17','30613890001294',691);
INSERT INTO catalogue VALUES ('Farnell_P18','46513890001294',4521);
INSERT INTO catalogue VALUES ('Digikey_P19','78313890001294',11);
INSERT INTO catalogue VALUES ('Mouser_P20','10213890001294',9621);
#select * from catalogue;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Programmes (4 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO programme VALUES (1,'Fidélio',15,1,0.05);
INSERT INTO programme VALUES (2,'Fidélio Or',25,2,0.08);
INSERT INTO programme VALUES (3,'Fidélio Platine',60,2,0.10);
INSERT INTO programme VALUES (4,'Fidélio Max',100,3,0.12);
#select * from programme;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- ClientsParticuliers (10 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO client_particulier VALUES ('cliP_1','Delacroix','Michel','2018-03-25','MichelDelacroix@gmail.com','0691754615',1,1);
INSERT INTO client_particulier VALUES ('cliP_2','Random','Jean','2012-05-21','JeanRandom@gmail.com','0607385804',1,2);
INSERT INTO client_particulier VALUES ('cliP_3','Auhasard','Camille','2012-10-05','CamilleAuhasard@gmail.com','0691301662',2,3);
INSERT INTO client_particulier VALUES ('cliP_4','Decastel','Quentin','2020-12-06','QuentinDecastel@gmail.com','0630235253',4,13);
INSERT INTO client_particulier VALUES ('cliP_5','Roulleaux','Clément','2010-05-26','ClémentRoulleaux@gmail.com','0664912967',3,5);
INSERT INTO client_particulier VALUES ('cliP_6','Artichaud','Clémence','2011-11-23','ClémenceArtichaud@gmail.com','0685104115',4,12);
INSERT INTO client_particulier VALUES ('cliP_7','Dubois','Stanislas','2015-02-19','StanislasDubois@gmail.com','0624340925',4,7);
INSERT INTO client_particulier VALUES ('cliP_8','Legrand','Thomas','2019-02-18','ThomasLegrand@gmail.com','0619637880',3,8);
INSERT INTO client_particulier VALUES ('cliP_9','Finot','Théo','2011-12-09','ThéoFinot@gmail.com','0649082877',2,9);
INSERT INTO client_particulier VALUES ('cliP_10','Viande','Yoan','2019-08-24','YoanViande@gmail.com','0666510043',1,10);
#select * from client_particulier;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- ListesAssemblages (200 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO liste_assemblage VALUES (1,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (1,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (1,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (1,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (1,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (1,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (1,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (1,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (1,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (1,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (2,'RS_P1',1);
INSERT INTO liste_assemblage VALUES (2,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (2,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (2,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (2,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (2,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (2,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (2,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (2,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (2,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (3,'RS_P1',1);
INSERT INTO liste_assemblage VALUES (3,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (3,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (3,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (3,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (3,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (3,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (3,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (3,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (3,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (4,'Mouser_P4',1);
INSERT INTO liste_assemblage VALUES (4,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (4,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (4,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (4,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (4,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (4,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (4,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (4,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (4,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (5,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (5,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (5,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (5,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (5,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (5,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (5,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (5,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (5,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (5,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (6,'RS_P1',1);
INSERT INTO liste_assemblage VALUES (6,'RS_P5',1);
INSERT INTO liste_assemblage VALUES (6,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (6,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (6,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (6,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (6,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (6,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (6,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (6,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (7,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (7,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (7,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (7,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (7,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (7,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (7,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (7,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (7,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (7,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (8,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (8,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (8,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (8,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (8,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (8,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (8,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (8,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (8,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (8,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (9,'Mouser_P4',1);
INSERT INTO liste_assemblage VALUES (9,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (9,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (9,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (9,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (9,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (9,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (9,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (9,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (9,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (10,'Farnell_P2',1);
INSERT INTO liste_assemblage VALUES (10,'RS_P5',1);
INSERT INTO liste_assemblage VALUES (10,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (10,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (10,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (10,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (10,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (10,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (10,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (10,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (11,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (11,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (11,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (11,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (11,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (11,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (11,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (11,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (11,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (11,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (12,'Farnell_P2',1);
INSERT INTO liste_assemblage VALUES (12,'RS_P5',1);
INSERT INTO liste_assemblage VALUES (12,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (12,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (12,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (12,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (12,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (12,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (12,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (12,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (13,'Farnell_P2',1);
INSERT INTO liste_assemblage VALUES (13,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (13,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (13,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (13,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (13,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (13,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (13,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (13,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (13,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (14,'Mouser_P4',1);
INSERT INTO liste_assemblage VALUES (14,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (14,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (14,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (14,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (14,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (14,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (14,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (14,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (14,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (15,'Mouser_P4',1);
INSERT INTO liste_assemblage VALUES (15,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (15,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (15,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (15,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (15,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (15,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (15,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (15,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (15,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (16,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (16,'RS_P5',1);
INSERT INTO liste_assemblage VALUES (16,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (16,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (16,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (16,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (16,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (16,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (16,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (16,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (17,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (17,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (17,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (17,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (17,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (17,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (17,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (17,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (17,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (17,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (18,'Mouser_P4',1);
INSERT INTO liste_assemblage VALUES (18,'Farnell_P6',1);
INSERT INTO liste_assemblage VALUES (18,'Mouser_P8',1);
INSERT INTO liste_assemblage VALUES (18,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (18,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (18,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (18,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (18,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (18,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (18,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (19,'Digikey_P3',1);
INSERT INTO liste_assemblage VALUES (19,'RS_P5',1);
INSERT INTO liste_assemblage VALUES (19,'Farnell_P10',1);
INSERT INTO liste_assemblage VALUES (19,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (19,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (19,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (19,'Farnell_P14',1);
INSERT INTO liste_assemblage VALUES (19,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (19,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (19,'Farnell_P18',1);
INSERT INTO liste_assemblage VALUES (20,'RS_P1',1);
INSERT INTO liste_assemblage VALUES (20,'Digikey_P7',1);
INSERT INTO liste_assemblage VALUES (20,'RS_P9',1);
INSERT INTO liste_assemblage VALUES (20,'Digikey_P11',1);
INSERT INTO liste_assemblage VALUES (20,'Mouser_P12',1);
INSERT INTO liste_assemblage VALUES (20,'RS_P13',1);
INSERT INTO liste_assemblage VALUES (20,'Digikey_P15',1);
INSERT INTO liste_assemblage VALUES (20,'Mouser_P16',1);
INSERT INTO liste_assemblage VALUES (20,'RS_P17',1);
INSERT INTO liste_assemblage VALUES (20,'Farnell_P18',1);
#select * from liste_assemblage;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- ClientsEntreprise (6 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO client_entreprise VALUES ('cliE_1','Decathlon',0.08,'Decathlon@gmail.com','0625698641','Charles_Levrier',14);
INSERT INTO client_entreprise VALUES ('cliE_2','GoSport',0.04,'GoSport@gmail.com','0684612457','Henri_Course',15);
INSERT INTO client_entreprise VALUES ('cliE_3','InterSport',0.04,'InterSport@gmail.com','0662404458','Quentin_Wolff',17);
INSERT INTO client_entreprise VALUES ('cliE_4','Les_pros_du_vélo',0.05,'Les_pros_du_vélo@gmail.com','0600792418','Lance_Armstrong',18);
INSERT INTO client_entreprise VALUES ('cliE_5','Google',0.06,'Google@gmail.com','0677690487','Forest_Gump',19);
INSERT INTO client_entreprise VALUES ('cliE_6','Le_tour_de_France',0.06,'Le_tour_de_France@gmail.com','0643475269','Buzz_Aldrin',20);
#select * from client_entreprise;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- Commandes (80 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO commande VALUES (1,'2017-06-12','2017-07-01',14,'cliE_1',null);
INSERT INTO commande VALUES (2,'2011-07-03','2011-07-31',1,null,'cliP_1');
INSERT INTO commande VALUES (3,'2010-06-07','2010-06-14',20,'cliE_6',null);
INSERT INTO commande VALUES (4,'2015-08-04','2015-08-09',12,null,'cliP_6');
INSERT INTO commande VALUES (5,'2010-04-02','2010-04-25',8,null,'cliP_8');
INSERT INTO commande VALUES (6,'2016-07-27','2016-08-09',3,null,'cliP_3');
INSERT INTO commande VALUES (7,'2011-06-03','2011-06-25',2,null,'cliP_2');
INSERT INTO commande VALUES (8,'2020-09-19','2020-10-04',8,null,'cliP_8');
INSERT INTO commande VALUES (9,'2017-11-18','2017-12-05',13,null,'cliP_4');
INSERT INTO commande VALUES (10,'2013-04-21','2013-05-14',20,'cliE_6',null);
INSERT INTO commande VALUES (11,'2013-09-12','2013-10-05',8,null,'cliP_8');
INSERT INTO commande VALUES (12,'2012-07-28','2012-08-08',15,'cliE_2',null);
INSERT INTO commande VALUES (13,'2017-08-04','2017-08-28',1,null,'cliP_1');
INSERT INTO commande VALUES (14,'2015-09-26','2015-09-28',18,'cliE_4',null);
INSERT INTO commande VALUES (15,'2012-04-27','2012-05-02',17,'cliE_3',null);
INSERT INTO commande VALUES (16,'2014-06-15','2014-06-24',7,null,'cliP_7');
INSERT INTO commande VALUES (17,'2017-02-11','2017-03-09',8,null,'cliP_8');
INSERT INTO commande VALUES (18,'2015-01-27','2015-02-13',7,null,'cliP_7');
INSERT INTO commande VALUES (19,'2016-09-20','2016-10-15',12,null,'cliP_6');
INSERT INTO commande VALUES (20,'2020-06-14','2020-06-23',14,'cliE_1',null);
INSERT INTO commande VALUES (21,'2017-08-12','2017-08-23',3,null,'cliP_3');
INSERT INTO commande VALUES (22,'2014-08-16','2014-09-06',7,null,'cliP_7');
INSERT INTO commande VALUES (23,'2013-06-19','2013-07-03',5,null,'cliP_5');
INSERT INTO commande VALUES (24,'2017-09-24','2017-10-15',15,'cliE_2',null);
INSERT INTO commande VALUES (25,'2019-12-22','2020-01-03',13,null,'cliP_4');
INSERT INTO commande VALUES (26,'2017-07-21','2017-08-15',3,null,'cliP_3');
INSERT INTO commande VALUES (27,'2018-01-16','2018-02-13',9,null,'cliP_9');
INSERT INTO commande VALUES (28,'2015-07-24','2015-08-09',1,null,'cliP_1');
INSERT INTO commande VALUES (29,'2017-11-03','2017-11-18',14,'cliE_1',null);
INSERT INTO commande VALUES (30,'2013-05-07','2013-05-18',8,null,'cliP_8');
INSERT INTO commande VALUES (31,'2019-12-25','2020-01-18',1,null,'cliP_1');
INSERT INTO commande VALUES (32,'2017-02-14','2017-03-09',7,null,'cliP_7');
INSERT INTO commande VALUES (33,'2010-01-26','2010-02-21',10,null,'cliP_10');
INSERT INTO commande VALUES (34,'2018-03-14','2018-03-24',13,null,'cliP_4');
INSERT INTO commande VALUES (35,'2019-11-20','2019-12-09',10,null,'cliP_10');
INSERT INTO commande VALUES (36,'2017-09-05','2017-09-27',15,'cliE_2',null);
INSERT INTO commande VALUES (37,'2010-08-11','2010-08-22',15,'cliE_2',null);
INSERT INTO commande VALUES (38,'2016-04-15','2016-05-06',9,null,'cliP_9');
INSERT INTO commande VALUES (39,'2017-07-03','2017-07-04',5,null,'cliP_5');
INSERT INTO commande VALUES (40,'2019-08-27','2019-09-21',1,null,'cliP_1');
INSERT INTO commande VALUES (41,'2010-06-27','2010-06-29',17,'cliE_3',null);
INSERT INTO commande VALUES (42,'2016-05-15','2016-05-28',7,null,'cliP_7');
INSERT INTO commande VALUES (43,'2014-04-21','2014-04-25',20,'cliE_6',null);
INSERT INTO commande VALUES (44,'2019-02-19','2019-02-22',7,null,'cliP_7');
INSERT INTO commande VALUES (45,'2015-10-20','2015-10-22',9,null,'cliP_9');
INSERT INTO commande VALUES (46,'2012-12-12','2012-12-26',3,null,'cliP_3');
INSERT INTO commande VALUES (47,'2011-04-01','2011-04-17',15,'cliE_2',null);
INSERT INTO commande VALUES (48,'2015-08-05','2015-08-14',20,'cliE_6',null);
INSERT INTO commande VALUES (49,'2013-08-12','2013-08-21',3,null,'cliP_3');
INSERT INTO commande VALUES (50,'2019-05-04','2019-05-18',1,null,'cliP_1');
INSERT INTO commande VALUES (51,'2018-01-12','2018-02-08',15,'cliE_2',null);
INSERT INTO commande VALUES (52,'2018-03-23','2018-04-13',8,null,'cliP_8');
INSERT INTO commande VALUES (53,'2012-05-18','2012-06-07',17,'cliE_3',null);
INSERT INTO commande VALUES (54,'2015-05-07','2015-06-04',14,'cliE_1',null);
INSERT INTO commande VALUES (55,'2010-06-05','2010-06-27',17,'cliE_3',null);
INSERT INTO commande VALUES (56,'2011-09-27','2011-10-21',5,null,'cliP_5');
INSERT INTO commande VALUES (57,'2012-09-02','2012-09-13',7,null,'cliP_7');
INSERT INTO commande VALUES (58,'2015-12-27','2016-01-05',20,'cliE_6',null);
INSERT INTO commande VALUES (59,'2015-03-09','2015-03-25',5,null,'cliP_5');
INSERT INTO commande VALUES (60,'2016-10-10','2016-10-24',7,null,'cliP_7');
INSERT INTO commande VALUES (61,'2011-11-15','2011-11-20',5,null,'cliP_5');
INSERT INTO commande VALUES (62,'2014-12-08','2014-12-16',8,null,'cliP_8');
INSERT INTO commande VALUES (63,'2013-08-09','2013-09-02',19,'cliE_5',null);
INSERT INTO commande VALUES (64,'2019-08-28','2019-08-31',20,'cliE_6',null);
INSERT INTO commande VALUES (65,'2014-12-19','2015-01-13',3,null,'cliP_3');
INSERT INTO commande VALUES (66,'2018-10-25','2018-10-31',5,null,'cliP_5');
INSERT INTO commande VALUES (67,'2014-01-06','2014-01-28',17,'cliE_3',null);
INSERT INTO commande VALUES (68,'2014-11-03','2014-11-22',19,'cliE_5',null);
INSERT INTO commande VALUES (69,'2013-11-20','2013-11-30',12,null,'cliP_6');
INSERT INTO commande VALUES (70,'2010-02-21','2010-03-06',7,null,'cliP_7');
INSERT INTO commande VALUES (71,'2011-10-08','2011-11-02',8,null,'cliP_8');
INSERT INTO commande VALUES (72,'2011-10-07','2011-10-17',17,'cliE_3',null);
INSERT INTO commande VALUES (73,'2017-09-01','2017-09-12',12,null,'cliP_6');
INSERT INTO commande VALUES (74,'2020-07-08','2020-07-25',12,null,'cliP_6');
INSERT INTO commande VALUES (75,'2018-05-13','2018-05-27',20,'cliE_6',null);
INSERT INTO commande VALUES (76,'2011-02-03','2011-02-13',2,null,'cliP_2');
INSERT INTO commande VALUES (77,'2014-03-11','2014-04-07',14,'cliE_1',null);
INSERT INTO commande VALUES (78,'2015-09-19','2015-10-01',2,null,'cliP_2');
INSERT INTO commande VALUES (79,'2019-11-14','2019-11-16',1,null,'cliP_1');
INSERT INTO commande VALUES (80,'2020-03-26','2020-04-11',14,'cliE_1',null);
#select * from commande;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- ListesPiecesCommandes (96 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',9,3);
INSERT INTO liste_piece_commande VALUES ('RS_P5',73,8);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',38,1);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',69,8);
INSERT INTO liste_piece_commande VALUES ('Digikey_P15',56,8);
INSERT INTO liste_piece_commande VALUES ('Farnell_P6',67,8);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',18,9);
INSERT INTO liste_piece_commande VALUES ('Mouser_P12',57,5);
INSERT INTO liste_piece_commande VALUES ('RS_P9',2,4);
INSERT INTO liste_piece_commande VALUES ('Digikey_P19',53,3);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',1,5);
INSERT INTO liste_piece_commande VALUES ('Farnell_P2',77,2);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',3,2);
INSERT INTO liste_piece_commande VALUES ('RS_P1',49,10);
INSERT INTO liste_piece_commande VALUES ('RS_P9',33,1);
INSERT INTO liste_piece_commande VALUES ('Digikey_P3',73,7);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',6,7);
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',77,3);
INSERT INTO liste_piece_commande VALUES ('RS_P9',55,3);
INSERT INTO liste_piece_commande VALUES ('Mouser_P20',28,8);
INSERT INTO liste_piece_commande VALUES ('RS_P5',34,3);
INSERT INTO liste_piece_commande VALUES ('Farnell_P14',77,1);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',2,4);
INSERT INTO liste_piece_commande VALUES ('Farnell_P14',15,7);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',70,8);
INSERT INTO liste_piece_commande VALUES ('RS_P1',44,8);
INSERT INTO liste_piece_commande VALUES ('Mouser_P20',22,7);
INSERT INTO liste_piece_commande VALUES ('Farnell_P2',11,4);
INSERT INTO liste_piece_commande VALUES ('Digikey_P15',26,6);
INSERT INTO liste_piece_commande VALUES ('Mouser_P12',44,6);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',79,2);
INSERT INTO liste_piece_commande VALUES ('RS_P9',39,4);
INSERT INTO liste_piece_commande VALUES ('RS_P17',56,1);
INSERT INTO liste_piece_commande VALUES ('Farnell_P18',40,8);
INSERT INTO liste_piece_commande VALUES ('RS_P9',50,8);
INSERT INTO liste_piece_commande VALUES ('RS_P17',59,7);
INSERT INTO liste_piece_commande VALUES ('RS_P13',42,1);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',5,2);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',3,8);
INSERT INTO liste_piece_commande VALUES ('Farnell_P6',21,10);
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',74,10);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',36,7);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',58,5);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',2,1);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',62,7);
INSERT INTO liste_piece_commande VALUES ('Mouser_P20',71,3);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',46,8);
INSERT INTO liste_piece_commande VALUES ('RS_P1',27,3);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',28,7);
INSERT INTO liste_piece_commande VALUES ('RS_P13',30,10);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',70,3);
INSERT INTO liste_piece_commande VALUES ('Digikey_P15',50,8);
INSERT INTO liste_piece_commande VALUES ('RS_P1',59,9);
INSERT INTO liste_piece_commande VALUES ('RS_P9',25,4);
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',63,10);
INSERT INTO liste_piece_commande VALUES ('RS_P13',58,4);
INSERT INTO liste_piece_commande VALUES ('Mouser_P20',73,10);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',68,7);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',47,6);
INSERT INTO liste_piece_commande VALUES ('Farnell_P2',69,8);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',60,2);
INSERT INTO liste_piece_commande VALUES ('Mouser_P12',79,10);
INSERT INTO liste_piece_commande VALUES ('RS_P17',38,8);
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',24,6);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',39,3);
INSERT INTO liste_piece_commande VALUES ('Farnell_P6',24,1);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',21,9);
INSERT INTO liste_piece_commande VALUES ('Mouser_P4',35,6);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',32,10);
INSERT INTO liste_piece_commande VALUES ('Farnell_P10',48,1);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',4,4);
INSERT INTO liste_piece_commande VALUES ('Digikey_P19',70,6);
INSERT INTO liste_piece_commande VALUES ('Farnell_P18',70,3);
INSERT INTO liste_piece_commande VALUES ('Mouser_P12',37,9);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',56,8);
INSERT INTO liste_piece_commande VALUES ('Farnell_P14',69,10);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',5,4);
INSERT INTO liste_piece_commande VALUES ('Mouser_P16',29,3);
INSERT INTO liste_piece_commande VALUES ('Digikey_P15',77,4);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',10,9);
INSERT INTO liste_piece_commande VALUES ('Digikey_P3',25,1);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',43,3);
INSERT INTO liste_piece_commande VALUES ('Farnell_P18',27,9);
INSERT INTO liste_piece_commande VALUES ('Farnell_P2',17,6);
INSERT INTO liste_piece_commande VALUES ('Farnell_P18',9,8);
INSERT INTO liste_piece_commande VALUES ('RS_P1',5,7);
INSERT INTO liste_piece_commande VALUES ('Farnell_P18',7,9);
INSERT INTO liste_piece_commande VALUES ('RS_P13',25,6);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',21,4);
INSERT INTO liste_piece_commande VALUES ('RS_P17',8,7);
INSERT INTO liste_piece_commande VALUES ('Digikey_P11',60,3);
INSERT INTO liste_piece_commande VALUES ('Mouser_P8',43,8);
INSERT INTO liste_piece_commande VALUES ('RS_P13',15,7);
INSERT INTO liste_piece_commande VALUES ('RS_P17',11,5);
INSERT INTO liste_piece_commande VALUES ('Digikey_P7',34,5);
INSERT INTO liste_piece_commande VALUES ('RS_P13',78,1);
#select * from liste_piece_commande;



-- ////////////////////////////////////////////////////////////////////////////////////////////////
-- ListesVélosCommandes (99 tuples)
-- ////////////////////////////////////////////////////////////////////////////////////////////////
INSERT INTO liste_velo_commande VALUES (25,9,3);
INSERT INTO liste_velo_commande VALUES (55,18,2);
INSERT INTO liste_velo_commande VALUES (24,14,6);
INSERT INTO liste_velo_commande VALUES (54,4,5);
INSERT INTO liste_velo_commande VALUES (60,13,6);
INSERT INTO liste_velo_commande VALUES (28,7,1);
INSERT INTO liste_velo_commande VALUES (21,19,3);
INSERT INTO liste_velo_commande VALUES (57,3,3);
INSERT INTO liste_velo_commande VALUES (19,10,4);
INSERT INTO liste_velo_commande VALUES (2,2,6);
INSERT INTO liste_velo_commande VALUES (28,19,5);
INSERT INTO liste_velo_commande VALUES (55,7,1);
INSERT INTO liste_velo_commande VALUES (56,15,3);
INSERT INTO liste_velo_commande VALUES (10,2,3);
INSERT INTO liste_velo_commande VALUES (29,14,3);
INSERT INTO liste_velo_commande VALUES (79,5,6);
INSERT INTO liste_velo_commande VALUES (42,13,3);
INSERT INTO liste_velo_commande VALUES (64,17,5);
INSERT INTO liste_velo_commande VALUES (13,6,4);
INSERT INTO liste_velo_commande VALUES (31,16,5);
INSERT INTO liste_velo_commande VALUES (78,1,4);
INSERT INTO liste_velo_commande VALUES (13,3,1);
INSERT INTO liste_velo_commande VALUES (36,8,2);
INSERT INTO liste_velo_commande VALUES (27,2,5);
INSERT INTO liste_velo_commande VALUES (74,4,5);
INSERT INTO liste_velo_commande VALUES (27,4,4);
INSERT INTO liste_velo_commande VALUES (41,20,6);
INSERT INTO liste_velo_commande VALUES (22,13,1);
INSERT INTO liste_velo_commande VALUES (78,12,3);
INSERT INTO liste_velo_commande VALUES (69,8,1);
INSERT INTO liste_velo_commande VALUES (22,9,3);
INSERT INTO liste_velo_commande VALUES (4,4,2);
INSERT INTO liste_velo_commande VALUES (39,1,2);
INSERT INTO liste_velo_commande VALUES (54,11,5);
INSERT INTO liste_velo_commande VALUES (7,15,4);
INSERT INTO liste_velo_commande VALUES (55,17,6);
INSERT INTO liste_velo_commande VALUES (67,2,5);
INSERT INTO liste_velo_commande VALUES (69,3,5);
INSERT INTO liste_velo_commande VALUES (37,8,1);
INSERT INTO liste_velo_commande VALUES (42,7,1);
INSERT INTO liste_velo_commande VALUES (16,16,2);
INSERT INTO liste_velo_commande VALUES (46,10,6);
INSERT INTO liste_velo_commande VALUES (28,4,1);
INSERT INTO liste_velo_commande VALUES (20,18,3);
INSERT INTO liste_velo_commande VALUES (63,10,1);
INSERT INTO liste_velo_commande VALUES (66,14,5);
INSERT INTO liste_velo_commande VALUES (41,10,5);
INSERT INTO liste_velo_commande VALUES (30,20,2);
INSERT INTO liste_velo_commande VALUES (75,4,4);
INSERT INTO liste_velo_commande VALUES (76,18,6);
INSERT INTO liste_velo_commande VALUES (23,2,4);
INSERT INTO liste_velo_commande VALUES (7,7,1);
INSERT INTO liste_velo_commande VALUES (22,8,5);
INSERT INTO liste_velo_commande VALUES (30,17,6);
INSERT INTO liste_velo_commande VALUES (45,10,5);
INSERT INTO liste_velo_commande VALUES (35,19,2);
INSERT INTO liste_velo_commande VALUES (6,9,3);
INSERT INTO liste_velo_commande VALUES (6,10,5);
INSERT INTO liste_velo_commande VALUES (27,6,1);
INSERT INTO liste_velo_commande VALUES (3,11,4);
INSERT INTO liste_velo_commande VALUES (45,19,5);
INSERT INTO liste_velo_commande VALUES (58,4,5);
INSERT INTO liste_velo_commande VALUES (55,1,3);
INSERT INTO liste_velo_commande VALUES (43,2,1);
INSERT INTO liste_velo_commande VALUES (44,5,2);
INSERT INTO liste_velo_commande VALUES (58,8,2);
INSERT INTO liste_velo_commande VALUES (75,13,5);
INSERT INTO liste_velo_commande VALUES (44,3,4);
INSERT INTO liste_velo_commande VALUES (2,11,3);
INSERT INTO liste_velo_commande VALUES (42,11,3);
INSERT INTO liste_velo_commande VALUES (58,2,4);
INSERT INTO liste_velo_commande VALUES (64,12,5);
INSERT INTO liste_velo_commande VALUES (53,6,5);
INSERT INTO liste_velo_commande VALUES (72,10,5);
INSERT INTO liste_velo_commande VALUES (46,19,5);
INSERT INTO liste_velo_commande VALUES (35,18,4);
INSERT INTO liste_velo_commande VALUES (4,2,1);
INSERT INTO liste_velo_commande VALUES (44,13,6);
INSERT INTO liste_velo_commande VALUES (44,19,5);
INSERT INTO liste_velo_commande VALUES (30,7,4);
INSERT INTO liste_velo_commande VALUES (60,20,6);
INSERT INTO liste_velo_commande VALUES (28,9,6);
INSERT INTO liste_velo_commande VALUES (25,2,5);
INSERT INTO liste_velo_commande VALUES (14,17,2);
INSERT INTO liste_velo_commande VALUES (30,5,6);
INSERT INTO liste_velo_commande VALUES (41,5,3);
INSERT INTO liste_velo_commande VALUES (67,19,1);
INSERT INTO liste_velo_commande VALUES (19,14,6);
INSERT INTO liste_velo_commande VALUES (3,6,4);
INSERT INTO liste_velo_commande VALUES (35,9,6);
INSERT INTO liste_velo_commande VALUES (51,7,4);
INSERT INTO liste_velo_commande VALUES (8,2,6);
INSERT INTO liste_velo_commande VALUES (47,9,2);
INSERT INTO liste_velo_commande VALUES (63,9,6);
INSERT INTO liste_velo_commande VALUES (75,10,3);
INSERT INTO liste_velo_commande VALUES (44,8,2);
INSERT INTO liste_velo_commande VALUES (43,13,4);
INSERT INTO liste_velo_commande VALUES (61,7,5);
INSERT INTO liste_velo_commande VALUES (29,13,4);
#select * from liste_velo_commande;


